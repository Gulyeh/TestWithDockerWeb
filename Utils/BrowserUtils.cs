namespace Task1_0.Utils
{
    public static class BrowserUtils
    {
        public static void RefreshPage() => AqualityServices.Browser.Refresh();
        public static void GoToPreviousPage() => AqualityServices.Browser.GoBack();
        public static void NaviagteToUrl(string url) => AqualityServices.Browser.GoTo(url);
        public static void SwitchToTab(int index) => AqualityServices.Browser.Tabs().SwitchToTab(index);
        public static void SwitchToLatestTab() => AqualityServices.Browser.Tabs().SwitchToLastTab();
        public static void CloseCurrentTab() => AqualityServices.Browser.Tabs().CloseTab();
        public static string MakeCurrentPageScreenshot() => Convert.ToBase64String(AqualityServices.Browser.GetScreenshot());
        public static void AddToCookies(string? cookieName, string? cookieValue) => AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookieName, cookieValue));
    }
}