namespace Task1_0.Utils
{
    public static class ConfigReader
    {
        private static ISettingsFile settingsFile = AqualityServices.Get<ISettingsFile>();
        public static LinksModel GetLinks() => settingsFile.GetValue<LinksModel>(ConfigKeys.linksKey);
        public static T GetValue<T>(string name) => settingsFile.GetValue<T>(name);      
    }
}