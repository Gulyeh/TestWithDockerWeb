namespace Task1_0.Pages
{
    public class AddProjectPage : Form
    {
        public AddProjectPage() : base(By.XPath("//form[@id='addProjectForm']"), "Add Project")
        {
        }

        private ITextBox projectNameTextBox = ElementFactory.GetTextBox(By.Id("projectName"), "Project Name");
        private IButton saveProjectButton = ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Save Project");
        private ILabel successAlert = ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'alert-success')]"), "Success Alert");


        public void WaitAndPressSaveProjectButton() => saveProjectButton.WaitAndClick();
        
        public void WaitAndInputProjectName(string? projectName)
        {
            ConditionalWait.WaitFor(_ => projectNameTextBox.State.IsDisplayed);
            projectNameTextBox.ClearAndType(projectName);
        }

        public bool WaitAndIsSuccessAlertWithMessageDisplayed()
        {
            if(!successAlert.State.WaitForDisplayed()) return false;
            var alertText = successAlert.GetText();
            return alertText != string.Empty && alertText is not null;
        }
    }
}