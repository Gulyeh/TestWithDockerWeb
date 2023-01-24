namespace Task1_0.Steps
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;

        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [When(@"I create a new test with random test name and random method name and random env")]
        public void WhenICreateANewTestWithRandomTestNameAndRandomMethodNameAndRandomEnv()
        {
            const int testNameLength = 10;
            const int methodNameLength = 20;
            const int envLength = 5;

            var projectName = scenarioContext[ScenarioKeys.NewProjectName].ToString();
            scenarioContext[ScenarioKeys.NewTest] = new NewTestModel(projectName, testNameLength, methodNameLength, envLength);     
        }
    }
}