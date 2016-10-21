using System;

namespace RedSms
{
    public class RedException : Exception
    {
        public RedException(int code)
            : base(((RedExceptionKind)code).ToString()) { }

        private enum RedExceptionKind
        {
            ServiceUnavailable = 0,
            SignatureNotSpecified = 1,
            LoginNotSpecified = 2,
            TextNotSpecified = 3,
            PhoneNotSpecified = 4,
            SenderNotSpecified = 5,
            IncorrectSignature = 6,
            IncorrectLogin = 7,
            IncorrectSender = 8,
            SenderNotRegistered = 9,
            SenderNotApproved = 10,
            TextContainsForbiddenWords = 11,
            ErrorSendingSms = 12,
            NumberInStoplist = 13,
            TooManyNumbers = 14,
            BaseNotSpecified = 15,
            IncorrectNumber = 16,
            SmsIdNotSpecified = 17,
            UnknownStatus = 18,
            EmptyAnswer = 19,
            NumberAlreadyExists = 20,
            MissingName = 21,
            TemplateAlreadyExists = 22,
            MonthNotSpecified = 23,
            TimestampNotSpecified = 24,
            NoBaseAccess = 25,
            EmptyBase = 26,
            NoValidNumbers = 27,
            NoBeginDate = 28,
            NoEndDate = 29,
            DateNotSpecified = 30
        }
    }
}
