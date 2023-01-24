namespace Task1_0.Steps
{
    [Binding]
    public class BrowserStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;

        public BrowserStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [When(@"I navigate to main url")]
        public void WhenINavigateToMainUrl()
        {
            BrowserUtils.NaviagteToUrl(ConfigReader.GetLinks().Url);
        }

        [When(@"I pass variant token to cookies")]
        public void WhenIPassVariantTokenToCookies()
        {
            var token = scenarioContext[ScenarioKeys.VariantToken].ToString();
            BrowserUtils.AddToCookies(CookiesKeys.tokenKey, token);
        }

        [When(@"I refresh page")]
        public void WhenIRefreshPage()
        {
            BrowserUtils.RefreshPage();
        }

        [When(@"I return to previous page")]
        public void WhenIReturnToPreviousPage()
        {
            BrowserUtils.GoToPreviousPage();
        }

        [When(@"I close currently opened tab")]
        public void WhenICloseCurrentlyOpenedTab()
        {
            BrowserUtils.CloseCurrentTab();
        }

        [When(@"I switch to first tab")]
        public void WhenISwitchToFirstTab()
        {
            BrowserUtils.SwitchToTab(0);
        }

        [When(@"I switch tabs to the latest opened")]
        public void WhenISwitchTabsToTheLatestOpened()
        {
            BrowserUtils.SwitchToLatestTab();
        }
    }
}