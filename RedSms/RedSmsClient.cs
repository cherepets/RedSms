using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RedSms
{
    public class RedSmsClient
    {
        private const string BaseUrl = "https://lk.redsms.ru/get/send.php?";
        private const string TimestampUrl = "https://lk.redsms.ru/get/timestamp.php";
        private const string ErrorBegin = "{\"error\":";
        private const string ErrorEnd = "}";

        public string Login { get; }
        public string Sender { get; }
        public string ApiKey { get; }

        public RedSmsClient(string login, string sender, string apikey)
        {
            Login = login;
            Sender = sender;
            ApiKey = apikey;
        }

        public async Task SendAsync(Message message)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("login", Login),
                new KeyValuePair<string, string>("sender", Sender),
                new KeyValuePair<string, string>("phone", message.Phone),
                new KeyValuePair<string, string>("text", message.Text),
                new KeyValuePair<string, string>("timestamp", await GetTimestampAsync()),
            }
            .OrderBy(p => p.Key)
            .ToDictionary(p => p.Key, p => p.Value);
            var signature = string.Join(string.Empty, parameters.Select(p => p.Value)) + ApiKey;
            signature = new Md5(signature).ToString();
            parameters["text"] = WebUtility.UrlEncode(message.Text);
            parameters.Add("signature", signature);
            var url = BaseUrl + string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}").ToArray());
            var http = new HttpClient();
            var res = await http.GetAsync(url);
            var content = await res.Content.ReadAsStringAsync();
            if (content.StartsWith(ErrorBegin))
            {
                var code = int.Parse(content.Replace(ErrorBegin, string.Empty).Replace(ErrorEnd, string.Empty));
                throw new RedException(code);
            }
        }

        private async Task<string> GetTimestampAsync()
        {
            var http = new HttpClient();
            var res = await http.GetAsync(TimestampUrl);
            var content = await res.Content.ReadAsStringAsync();
            return content;
        }
    }
}
