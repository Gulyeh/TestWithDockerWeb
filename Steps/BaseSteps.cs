namespace Task1_0.Steps
{
    public abstract class BaseSteps
    {
        private AddProjectPage? _addProjectPage;
        private protected AddProjectPage addProjectPage => _addProjectPage ??= new AddProjectPage();

        private ProjectsPage? _projectPage;
        private protected ProjectsPage projectsPage => _projectPage ??= new ProjectsPage();

        private TestsPage? _testsPage;
        private protected TestsPage testsPage => _testsPage ??= new TestsPage();
    }
}