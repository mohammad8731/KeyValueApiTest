namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Urls
{
    public class ResourceAddress
    {
        // we should use bellow feilds in any where accessing resourced such as pictures or json files
        public static string LocalAddress { get; set; } = "wwwroot/";
        public static string Resources { get; set; } = "resources/";
        public static string Images { get; set; } = "images/";
        public static string CountriesFile { get; set; } = "countries.json";
        public static string citiesFile { get; set; } = "cities.json";
        public static string FooterFile { get; set; } = "footer.json";
        public static string PublicLinkFile { get; set; } = "publicLink.json";
        public static string PublicLinkLastIndexFile { get; set; } = "publicLinkLastIndex.txt";
        public static string provincesFile { get; set; } = "provinces.json";
        public static string css { get; set; } = "css/";
        public static string AppSettingsFile { get; set; } = "appsettings.json";
        public static string AppSettingsProductionFile { get; set; } = "appsettings.production.json";
        public static string AppSettingsDevelopmentFile { get; set; } = "appsettings.Development.json";
        public static string ExternalAddress { get; set; } = "";
    }
}
