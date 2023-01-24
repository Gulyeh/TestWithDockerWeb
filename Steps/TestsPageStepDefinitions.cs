namespace Task1_0.Steps
{
    [Binding]
    public class TestsPageStepDefinitions : BaseSteps
    {
        private readonly ScenarioContext scenarioContext;

        public TestsPageStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Then(@"Tests on the first page are ordered by descending by start date")]
        public void ThenTestsOnTheFirstPageAreOrderedByDescendingByStartDate()
        {
            var testList = testsPage.WaitAndGetListOfTests();
            var orderedList = testList.OrderByDescending(test => test.StartTime);
            Assert.AreEqual(orderedList, testList, "List is not in correct order");
        }

        [Then(@"Tests list received from API contain tests displayed on the Test Page")]
        public void ThenTestsListReceivedFromAPIContainTestsDisplayedOnTheTestPage()
        {
            var testsFromAPI = (IEnumerable<TestModel>)scenarioContext[ScenarioKeys.TestsFromApi];
            IEnumerable<TestModel> listOfTestsFromTheTable = testsPage.GetListOfTests();
            Assert.That(listOfTestsFromTheTable.All(pageTest => testsFromAPI.Any(apiTest => pageTest.Equals(apiTest))), "Could not find all of the tests from the list in the tests list from API response");
        }

        [Then(@"Added test is displayed on the list")]
        public void ThenAddedTestIsDisplayedOnTheList()
        {
            var test = (NewTestModel)scenarioContext[ScenarioKeys.NewTest];
            Assert.IsTrue(testsPage.WaitAndIsCreatedTestDisplayedOnNewTestList(test), "Test is not displayed on the list");
        }
    }
}