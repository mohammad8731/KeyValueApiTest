namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Constants
{
    public interface IConstants
    {
        public abstract class EntityName
        {
            public static string JobOfferPersian = "آگهی";
            public static string JobOfferEnglish = "JobOffer";
            public static string userPersian = "کاربر";
            public static string userEnglish = "user";
        }

        public enum EntityNameEnums
        {
            JobOffer = 1,
            Admin = 2,
            AdminOne = 3,
            User = 5,
            UserImage = 4,
            AboutUsMain = 6,
            JobOfferImage = 7,
            Company = 8,
            Marketer = 18,
            NewsCoverImage = 9,
            NewsImage = 10,
            CompanyLogo = 11,
            CompanyMainPic = 12,
            resumePic = 13,
            Consultant = 14,
            automatic = 15,
            resume = 16,
            jobOffer = 17,
            Cooperator
        }

        public enum LoggerType
        {
            DatabaseExpLogger = 1,
            FileIOExpLogger = 2,
            OtherExpLogger = 3,
            InfoLogger = 4,
            UserLogger = 5,
            MemoryLogger = 6,
            SendingMessageLogger = 7,
            CompanyBalanceLogger = 8,
            PaymentLoggerStp1 = 9,
            PaymentLoggerStp2 = 10,
            PaymentLoggerStp3 = 11,
            PaymentLoggerStp4 = 12,
            BasketThirdPartyConnectionLogger = 13,
            BasketDBOperationFailedLogger = 14,
            BasketBaseExceptionLogger = 15,
            BasketOtherExceptionLogger = 16,
            WalletThirdPartyConnectionLogger = 18,
            WalletDBOperationFailedLogger = 19,
            WalletBaseExceptionLogger = 20,
            WalletOtherExceptionLogger = 21,
            FinancialExpLogger = 17,
        }
    }
}