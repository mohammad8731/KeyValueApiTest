namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Languages
{
    public class Language
    {
        public Language()
        {
            RequestLanguage = fa_IR;
        }
        public string RequestLanguage { get; set; }
        public static string fa_IR { get; set; } = "fa-IR";
        public static string en_US { get; set; } = "en-US";
        // this bool is true whenever our site is multi languages
        public static bool IsMultiLangActive { get; set; } = true;
        // this bool is true whenever our site is in persian
        public static bool IsJustPersian { get; set; } = false;
        // this bool is true whenever our site is in english
        public static bool IsJustEnglish { get; set; } = false;


        public static string Policy(string requestLanguage)
        {
            if (IsMultiLangActive)
            {
                return requestLanguage;
                //if (requestLanguage == Language.fa_IR)
                //{
                //    return requestLanguage;
                //}
                //else
                //{
                //    return requestLanguage;
                //}
            }
            else if (IsJustPersian)
            {
                return fa_IR;
            }
            else if (IsJustEnglish)
            {
                return en_US;
            }
            return "";
        }

    }
}