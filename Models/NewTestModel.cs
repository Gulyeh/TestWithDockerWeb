namespace Task1_0.Models
{
    public class NewTestModel
    {
        public string? Id { get; set; }
        public string Sid { get; init; }
        public string ProjectName { get; init; }
        public string TestName { get; init; }
        public string MethodName { get; init; }
        public string Env { get; init; }
        public string StartTime { get; init; }
        

        public NewTestModel(string? projectName, int testNameLength, int methodNameLength, int envLength)
        {
            Sid = Guid.NewGuid().ToString();
            ProjectName = projectName ?? string.Empty;
            TestName = RandomUtils.GenerateRandomText(testNameLength);
            MethodName = RandomUtils.GenerateRandomText(methodNameLength);
            Env = RandomUtils.GenerateRandomText(envLength);
            StartTime = DateTime.Now.ToString(ConfigReader.GetValue<string>(ConfigKeys.timeFormatKey));
        }

        public Dictionary<string, string?> GetUrlParametersDictionary()
        {
            var dictionay = new Dictionary<string, string?>();
            dictionay.Add(ParameterKeys.sidKey, Sid);
            dictionay.Add(ParameterKeys.projectNameKey, ProjectName);
            dictionay.Add(ParameterKeys.testNameKey, TestName);
            dictionay.Add(ParameterKeys.methodNameKey, MethodName);
            dictionay.Add(ParameterKeys.envKey, Env);
            dictionay.Add(ParameterKeys.startTimeKey, StartTime);
            return dictionay;
        }
    }
};