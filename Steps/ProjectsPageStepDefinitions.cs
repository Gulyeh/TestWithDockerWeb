namespace Task1_0.Steps
{
    [Binding]
    public class ProjectsPageStepDefinitions : BaseSteps
    {
        private readonly ScenarioContext scenarioContext;

        public ProjectsPageStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [Then(@"Projects page is opened")]
        public void ThenProjectsPageIsOpened()
        {
            Assert.IsTrue(projectsPage.State.IsDisplayed, "Projects Page is not opened");
        }
  
        [Then(@"Footer contains variant number '([^']*)'")]
        public void ThenFooterContainsVariantNumber(string variantNumber)
        {
            Assert.AreEqual(projectsPage.WaitAndGetFooterVersion(), variantNumber, "Specified version does not equal with footer version");
        }

        [When(@"I click on '([^']*)' project in table")]
        public void WhenIClickOnProjectInTable(string projectName)
        {
            projectsPage.ClickProject(projectName);
        }

        [When(@"I click on Add Button on Projects page")]
        public void WhenIClickOnAddButtonOnProjectsPage()
        {
            projectsPage.WaitAndClickAddProjectButton();
        }

        [Then(@"Added project name has appeared on the list")]
        public void ThenAddedProjectNameHasAppearedOnTheList()
        {
            var projectName = scenarioContext[ScenarioKeys.NewProjectName].ToString();
            IEnumerable<IButton> listOfProjects = projectsPage.GetListOfAllProjects();
            Assert.That(listOfProjects.Any(x => x.GetText().Equals(projectName)), "Specified project does not exist on the list");
        }  

        [When(@"I click on added project on the list")]
        public void WhenIClickOnAddedProjectOnTheList()
        {
            var projectName = scenarioContext[ScenarioKeys.NewProjectName].ToString();
            projectsPage.ClickProject(projectName);
        }
    }
}