namespace Task1_0.Steps
{
    [Binding]
    public class APIStepDefinitions : BaseSteps
    {
        private readonly ScenarioContext scenarioContext;

        public APIStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [When(@"I add the created test to the created project by a POST API request")]
        public async Task WhenIAddTheCreatedTestToTheCreatedProjectByAPOSTAPIRequest()
        {
            var model = (NewTestModel)scenarioContext[ScenarioKeys.NewTest];

            var url = ConfigReader.GetLinks().AddTestApi;
            var response = await HttpUtils.Post<string>(url, model.GetUrlParametersDictionary());

            model.Id = response?.Content;
            scenarioContext[ScenarioKeys.NewTest] = model;
        }

        [Given(@"I send a POST request to an API to generate token of variant number (.*)")]
        public async Task GivenISendAPOSTRequestToAnAPIToGenerateTokenOfVariantNumber(int variantNumber)
        {
            var url = ConfigReader.GetLinks().TokenApi;
            var parameters = new Dictionary<string, string?>();
            parameters.Add(ParameterKeys.variantKey, variantNumber.ToString());
            var response = await HttpUtils.Post(url, parameters);

            scenarioContext[ScenarioKeys.VariantToken] = response?.Content;
        }

        [When(@"I get a list of tests from project using POST API request")]
        public async Task WhenIGetAListOfTestsFromProjectUsingPOSTAPIRequest()
        {
            var url = ConfigReader.GetLinks().TestsApi;
            string projectId = testsPage.GetProjectId();

            var parameters = new Dictionary<string, string?>();
            parameters.Add(ParameterKeys.projectIdKey, projectId);
            var response = await HttpUtils.Post<IEnumerable<TestModel>>(url, parameters);

            scenarioContext[ScenarioKeys.TestsFromApi] = response?.Content;
        }


        [When(@"I send POST API request with screenshot to added test")]
        public async Task WhenISendPOSTAPIRequestWithScreenshotToAddedTest()
        {
            var screenshotBase64 = BrowserUtils.MakeCurrentPageScreenshot();
            var test = (NewTestModel)scenarioContext[ScenarioKeys.NewTest];
            var url = ConfigReader.GetLinks().AddScreenshotApi;

            var parameters = new Dictionary<string, string?>();
            parameters.Add(ParameterKeys.testIdKey, test?.Id);
            parameters.Add(ParameterKeys.contentTypeKey, "image/png");
            parameters.Add(ParameterKeys.contentKey, screenshotBase64);

            var response = await HttpUtils.Post<string>(url, parameters);
        }

        [When(@"I send POST API request with log to added test")]
        public async Task WhenISendPOSTAPIRequestWithLogToAddedTest()
        {
            var url = ConfigReader.GetLinks().AddLogApi;
            var logs = RandomUtils.GenerateRandomText(20);
            var test = (NewTestModel)scenarioContext[ScenarioKeys.NewTest];

            var parameters = new Dictionary<string, string?>();
            parameters.Add(ParameterKeys.testIdKey, test?.Id);
            parameters.Add(ParameterKeys.contentKey, logs);

            var response = await HttpUtils.Post<string>(url, parameters);
        }

    }
}