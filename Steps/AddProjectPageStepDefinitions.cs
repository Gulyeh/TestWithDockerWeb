namespace Task1_0.Steps
{
    [Binding]
    public class AddProjectPageStepDefinitions : BaseSteps
    {
        private readonly ScenarioContext scenarioContext;

        public AddProjectPageStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [When(@"I enter randomly generated project name")]
        public void WhenIEnterRandomlyGeneratedProjectName()
        {
            const int lengthOfProjectName = 10;
            var generatedName = RandomUtils.GenerateRandomText(lengthOfProjectName);
            addProjectPage.WaitAndInputProjectName(generatedName);
            scenarioContext[ScenarioKeys.NewProjectName] = generatedName;
        }

        [Then(@"Add project page is opened")]
        public void ThenAddProjectPageIsOpened()
        {
            Assert.IsTrue(addProjectPage.State.IsDisplayed, "Add project page is not opened");
        }

        [When(@"I click Save Project button on Add Project Page")]
        public void WhenIClickSaveProjectButtonOnAddProjectPage()
        {
            addProjectPage.WaitAndPressSaveProjectButton();
        }

        [Then(@"Alert with message about successful saving appeared")]
        public void ThenAlertWithMessageAboutSuccessfulSavingAppeared()
        {
            Assert.IsTrue(addProjectPage.WaitAndIsSuccessAlertWithMessageDisplayed(), "Alert with message about successful project saving is not displayed");
        }
    }
}