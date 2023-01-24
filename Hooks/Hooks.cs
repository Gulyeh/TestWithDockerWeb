namespace Task1_0.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            AqualityServices.Browser.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            HttpDriver.Dispose();
            AqualityServices.Browser.Quit();
        }
    }
}