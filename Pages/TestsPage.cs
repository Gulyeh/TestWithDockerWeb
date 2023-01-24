namespace Task1_0.Pages
{
    public class TestsPage : Form
    {
        public TestsPage() : base(By.XPath("//div[@id='graph']"), "Tests")
        {
        }

        private ILabel projectIdLabel = ElementFactory.GetLabel(By.XPath("//a[contains(@href, 'projectId=')]"), "ProjectID");
        private ILabel testsLoaderIndicator = ElementFactory.GetLabel(By.Id("allTests"), "Tests Loader Indicator");
        private ILabel noTestsLabel = ElementFactory.GetLabel(By.XPath("//td/div[contains(@class, 'alert-danger')]"), "No tests");
        private IEnumerable<ILabel> testsTable = ElementFactory.FindElements<ILabel>(By.XPath("//table[@class='table']/tbody"));
        private By testsLocator = By.XPath(".//tr");
        private By testNameLocator = By.XPath(".//a[contains(@href, 'testId')]");
        private By testMethodLocator = By.XPath(".//td[2]");
        private By startTimeLocator = By.XPath(".//td[4]");
        private By endTimeLocator = By.XPath(".//td[5]");
        private By durationLocator = By.XPath(".//td[6]");
        private By testResultLocator = By.XPath(".//span[contains(@class, 'label label-')]");


        public string GetProjectId() => projectIdLabel.GetAttribute("href").SplitWithoutSpaces('=', 1);

        public bool WaitAndIsCreatedTestDisplayedOnNewTestList(NewTestModel testModel)
        {
            try
            {
                ConditionalWait.WaitFor(_ => !noTestsLabel.State.IsDisplayed);
                IEnumerable<TestModel> testList = GetTestsFromList();
                return testList!.Any(test => test.StartTime.Equals(testModel.StartTime) && test.Name.Equals(testModel.TestName) && test.Method.Equals(testModel.MethodName));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public IEnumerable<TestModel> GetListOfTests() => GetTestsFromList() ?? new List<TestModel>();
        
        public IEnumerable<TestModel> WaitAndGetListOfTests()
        {
            ConditionalWait.WaitFor(_ => testsLoaderIndicator.State.IsClickable);
            return GetTestsFromList();
        }

        private IEnumerable<TestModel> GetTestsFromList()
        {
            if (testsTable is null || testsTable.Count() < 1) return new List<TestModel>();

            //takes whole list and skip first element which is a table header
            var list = testsTable.First().FindChildElements<ILabel>(testsLocator).Skip(1);
            return ConvertListToListOfModels(list);
        }

        private IEnumerable<TestModel> ConvertListToListOfModels(IEnumerable<ILabel>? list)
        {
            var modelList = new List<TestModel>();
            if (list is null) return modelList;

            foreach (var item in list)
            {
                var duration = DriverUtils.GetTextOfFirstChildElement(item, durationLocator);
                var testName = DriverUtils.GetTextOfFirstChildElement(item, testNameLocator);
                var methodName = DriverUtils.GetTextOfFirstChildElement(item, testMethodLocator);
                var status = DriverUtils.GetTextOfFirstChildElement(item, testResultLocator);
                var endTime = DriverUtils.GetTextOfFirstChildElement(item, endTimeLocator);
                var startTime = DriverUtils.GetTextOfFirstChildElement(item, startTimeLocator);

                var newTestModel = new TestModel(duration, methodName, testName, startTime, endTime, status);
                modelList.Add(newTestModel);
            }

            return modelList;
        }
    }
}