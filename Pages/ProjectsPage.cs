namespace Task1_0.Pages
{
    public class ProjectsPage : Form
    {
        public ProjectsPage() : base(By.XPath("//div[@class='list-group']"), "Projects")
        {
        }

        private IButton addProjectButton = ElementFactory.GetButton(By.XPath("//a[@href='addProject']"), "Add Project");
        private ILabel versionLabel = ElementFactory.GetLabel(By.XPath("//p[contains(@class, 'footer-text')]/span"), "Version");
        private IEnumerable<ILabel> mainProjectsTable = ElementFactory.FindElements<ILabel>(By.XPath("//div[@class='list-group']"));
        private By projectsLocator = By.XPath(".//a[@class='list-group-item']");


        public void WaitAndClickAddProjectButton() => addProjectButton.WaitAndClick();
        
        public string WaitAndGetFooterVersion()
        {
            ConditionalWait.WaitFor(_ => versionLabel.State.IsDisplayed);
            var versionText = versionLabel.GetText().SplitWithoutSpaces(':', 1);
            return versionText;
        }

        public void ClickProject(string? name)
        {
            IButton? requestedProject = FindProjectByName(name);
            requestedProject?.Click();
        }

        public IEnumerable<IButton> GetListOfAllProjects() => GetProjectsList() ?? new List<IButton>();

        private IButton? FindProjectByName(string? name)
        {
            IEnumerable<IButton>? projectList = GetProjectsList();
            if (projectList?.Count() < 1 || projectList is null) return default;

            return projectList.FirstOrDefault(x => x.GetText().Equals(name));
        }

        private IEnumerable<IButton>? GetProjectsList() => mainProjectsTable.FirstOrDefault()?.FindChildElements<IButton>(projectsLocator);     
    }
}