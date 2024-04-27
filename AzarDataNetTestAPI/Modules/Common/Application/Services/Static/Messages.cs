using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Languages;

namespace AzarDataNetTestAPI.Modules.Common.Application.Services.Static
{
    public class Messages
    {
        public static string Success { get; set; } = "عملیات با موفقیت انجام شد";
        public static string Failed { get; set; } = "خطلا! لطفا مجددا تلاش کنید";
        public static string NothingFound { get; set; } = "موردی با شناسه شما یافت نشد";
        public static string NotActivated { get; set; } = "شماره تلفن شما هنوز تایید نشده است";
        public static string NotAuthorizes { get; set; } = "شما مجوز این کار را ندارید";

        public static string OnlyOne { get; set; } = "فقط میتوانید یک مورد اضافه نمایید";

        public static string Duplicate { get; set; } = "این مورد قبلا ثبت شده است";

        public static string UpdateEntityStatus { get; set; } = "اصلاح اطلاعات - ";

        public static string AddCoverImage { get; set; } = "اضافه کردن عکس کاور - ";

        public static string RemoveCoverImage { get; set; } = "حذف کردن عکس کاور - ";


        public static string GetEntityNotFoundMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"{EntityName} با این مشخصات یافت نشد";
            var EMessage = $"no such a {EnglishEntityName} found";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetEntityRelationRemoveMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"برای این موجودیت حداقل یک {EntityName} موجود است";
            var EMessage = $"there is at least one {EnglishEntityName} for this entity ";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetUserFoundMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"{EntityName} با این مشخصات در سامانه موجود است لطفا از طریق لاگین وارد سایت شوید";
            var EMessage = $"there is such a  {EnglishEntityName} in system, please enter via login";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }
        public static string GetUserFoundWithSpecificMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"کاربری با این {EntityName} در سامانه موجود است ";
            var EMessage = $"there is such a  user with this{EnglishEntityName} in system";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetMyRequiredMessage(string propName, string EnglishpropName, string language)
        {
            var PMessage = " لطفا " + propName + " خود را وارد نمایید";
            var EMessage = " please enter your " + EnglishpropName;
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }


        public static string GetNotValidMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"{EntityName} نامعتبر است";
            var EMessage = $" {EnglishEntityName} is not valid";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetMaxValideCountMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"شما به حداکثر تعداد مجاز برای {EntityName} رسیده اید";
            var EMessage = $" you reached the maximum count for{EnglishEntityName}";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }


        public static string GetNotValidStringSizeMessage(string EntityName, string EnglishEntityName, int minSize, int maxSize, string language)
        {
            var PMessage = $"طول {EntityName} باید بین {minSize} تا {maxSize} کاراکتر باشد";
            var EMessage = $"size of {EnglishEntityName} characters must be between {minSize} to {maxSize}";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetOperationSuccessFullMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"{EntityName} با موفقیت انجام شد";
            var EMessage = $"{EnglishEntityName} finished successfully";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetOperationFailedMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"خطا در {EntityName} لطفا مجددا تلاش کنید";
            var EMessage = $"Error {EnglishEntityName} please try again";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetCountryNotValidMessage(string language)
        {
            var PMessage = $"کشور شما برای این عمل مجاز نیست";
            var EMessage = $"your region is not valid for this operation";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetSendCodeSuccessfulMessage(string EntityName, string EnglishEntityName, string language)
        {
            var PMessage = $"لطفا کد ارسال شده به {EntityName} خود را در کادر مقابل وارد کنید";
            var EMessage = $"please enter the code sent to your {EnglishEntityName} in the following feild";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetSendCodeTimeLimitMessage(int totalseconds, string language)
        {
            var PMessage = $"باید {totalseconds} ثاینه دیگر برای ارسال مجدد کد صبر کنید";
            var EMessage = $"please try to send code {totalseconds} seconds later ";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetSuccessfulLoginMessage(string language)
        {
            var PMessage = $"شما با موفقیت وارد شدید";
            var EMessage = $"you entered successfully";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetAccountBannedMessage(string language)
        {
            var PMessage = $"حساب کاربری شما مسدود شده است لطفا با ادمین سایت تماس حاصل فرمایید";
            var EMessage = $"your account has been banned , please call website admin";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetWrongPassLimitMessage(string language)
        {
            var PMessage = $"پسورد خود را بیش از حد اشتباه وارد کرده اید ، لطفا دقایقی دیگر تلاش کنید";
            var EMessage = $"you have reached your maximum wrong password entered please try several minutes later";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetLoginLimitMessage(string language)
        {
            var PMessage = "تعداد لاگین های شما به حد مجاز رسیده است، لطفا  دقایقی دیگر تلاش کنید. در صورت تکرار این درخواست 1 دقیقه به صورت صعودی اضافه خواهد شد ";
            var EMessage = "you have reached your maximum login count please try several minutes later";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetNotAllowedMessage(string language)
        {
            var PMessage = "اجازه این کار را ندارید";
            var EMessage = "Not allowed to do this action";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string GetInUseMessage(string entityName, string englishEntityName, string language)
        {
            string pMessage = $"این {entityName} هم اکنون در حال استفاده است";
            string eMessage = $"This {englishEntityName} is in use";

            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        public static string GetAlreadyRegisteredMessage(string language)
        {
            string pMessage = $"شما قبلا در این دوره یکبار  ثبت نام کرده اید";
            string eMessage = $"you have already registerd in this course for onetime";

            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }
        public static string GetAlreadyAddedToBasket(string language, string entityName, string englishEntityName)
        {
            string pMessage = $"شما قبلا این {entityName} را به سبد خود افزوده اید";
            string eMessage = $"you have already added this {englishEntityName} to your basket";

            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }
        public static string GetNotAllowedInThisDurationMessage(string entityName, string englishEntityName, string language)
        {
            string pMessage = $"امکان {entityName} خارج از زمان تعریف شده نیست";
            string eMessage = $"It is not possible to {englishEntityName} outside the defined time";

            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }
        public static string GetCapacityFullMessage(string entityName, string englishEntityName, string language)
        {
            string pMessage = $"ظرفیت {entityName} تکمیل شده است";
            string eMessage = $"capacity of {englishEntityName} has been completed";

            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        public static string GetMaxCapacityAvailableInBasketMessage(byte count, string language)
        {
            string pMessage = $"حدااکثر تعداد سفارش مجاز در سبد {count} تا می باشد";
            string eMessage = $"The maximum number of orders allowed in the basket is {count}";

            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        public static string GetTryLaterMessage(int count, string language)
        {
            string pMessage = $"لطفا {count} دقیقه دیگر تلاش کنید";
            string eMessage = $"please try {count} minutes later";
            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        public static string GetExpiredMessage(string entityName, string englishEntityName, string language)
        {
            string pMessage = $"{entityName} منقضی شده است یا تعداد روز کافی برای این عمل را ندارد";
            string eMessage = $"{englishEntityName} has been expired or doesn't have enough days for this action";
            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        public static string GetAlreadyUsedOffMessage(string language)
        {
            string pMessage = $"کد تخفیفی از قبل برای این مورد به ثبت رسیده ، لطفا وارد درگاه شوید";
            string eMessage = $"a discount code has already been registered for you, please enter the portal";
            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        public static string GetAlreadyExistsMessage(string language)
        {
            string pMessage = $"موجودیتی با این مشخصات در سامانه موجود است";
            string eMessage = $"an entity with this properties already exits in the system";
            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        public static string FillRequiredFeildsMessage(string language)
        {
            string pMessage = $"لطفا فیلد های اجباری را وارد نمایید وسپس اقدام کنید";
            string eMessage = $"please fill required feilds and then try again";
            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        public static string GetWrongRoleMessage(string language)
        {
            string pMessage = $"نقش وارد شده متعلق به شما نیست";
            string eMessage = $"the role entered does not belong to you";
            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        //public static string GetWrongPassMessage(string language)
        //{
        //    var PMessage = "کلمه عبور وارد شده نادر";
        //    var EMessage = "you have reached your maximum login count please try several minutes later";
        //    return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        //}

        public static string GetAddRecordLimitMessage(string entityName, string englishEntityName, short requestCount, string language)
        {
            string pMessage = $"حداکثر تعداد مجاز برای {entityName} {requestCount} میباشد";
            string eMessage = $"The maximum number of {englishEntityName} allowed is {requestCount}";
            return GetMessageBasedOnLanguageSatus(pMessage, eMessage, language);
        }

        //JobOfferRequest
        public static string GetJobOfferRequestNotValidMessage(string language)
        {
            var PMessage = $"امکان آپدیت درخواست پس از رد یا تایید درخواست توسط کارفرما نیست";
            var EMessage = $"It is not possible to update the request after the request is rejected or approved by the employer";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        public static string WaitForAdminConfirmation(string language)
        {
            var PMessage = $"شرکت شما با موفقیت ثیت گردید، لطفا منتظر تایید سامانه بمانید";
            var EMessage = $"Your company has been successfully registered, please wait for system approval";
            return GetMessageBasedOnLanguageSatus(PMessage, EMessage, language);
        }

        private static string GetMessageBasedOnLanguageSatus(string PMessage, string EMessage, string language)
        {
            language = Language.Policy(language);

            if (language == Language.fa_IR)
            {
                return PMessage;
            }
            else
            {
                return EMessage;
            }
        }


    }

}
