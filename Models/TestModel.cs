namespace Task1_0.Models
{
    public class TestModel : IEquatable<TestModel>
    {
        public string Duration { get; init; }
        public string Method { get; init; }
        public string Name { get; init; }

        private string _startTime = string.Empty;
        public string StartTime
        {
            get => _startTime;
            init
            {
                DateTime.TryParse(value, out DateTime start);
                _startTime = start.ToString(ConfigReader.GetValue<string>(ConfigKeys.timeFormatKey));
            }
        }

        private string _endTime = string.Empty;
        public string EndTime
        {
            get => _endTime;
            init
            {
                DateTime.TryParse(value, out DateTime end);
                _endTime = end.ToString(ConfigReader.GetValue<string>(ConfigKeys.timeFormatKey));
            }
        }

        private string _status = string.Empty;
        public string Status
        {
            get => _status;
            init => _status = value.ToLower();
        }

        public TestModel(string? duration, string? method, string? name, string? startTime, string? endTime, string? status)
        {
            Duration = duration ?? string.Empty;
            Method = method ?? string.Empty;
            Name = name ?? string.Empty;
            Status = status ?? string.Empty;
            StartTime = startTime ?? string.Empty;
            EndTime = endTime ?? string.Empty;
        }

        public bool Equals(TestModel? other) =>
            Duration.Equals(other?.Duration) && Method.Equals(other?.Method) &&
            Name.Equals(other?.Name) && StartTime.Equals(other?.StartTime) &&
            EndTime.Equals(other?.EndTime) && Status.Equals(other?.Status);
    }
}