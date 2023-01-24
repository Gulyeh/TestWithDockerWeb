namespace Task1_0.Models
{
    public class LinksModel
    {
        public string Url { get; set; }
        public string TokenApi { get; set; }
        public string TestsApi { get; set; }
        public string AddTestApi { get; set; }
        public string AddLogApi { get; set; }
        public string AddScreenshotApi { get; set; }

        public LinksModel()
        {
            Url = string.Empty;
            TokenApi = string.Empty;
            TestsApi = string.Empty;
            AddTestApi = string.Empty;
            AddLogApi = string.Empty;
            AddScreenshotApi = string.Empty;
        }
    }
}