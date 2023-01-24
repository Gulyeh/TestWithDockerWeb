namespace Task1_0.Utils
{
    public static class RandomUtils
    {
        public static string GenerateRandomText(int length)
        {
            var regexPattern = "^([1-9][0-9]|100)$"; //number from 1 to 100
            var randomizer = RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum()).Generate();
            int.TryParse(RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex { Pattern = regexPattern }).Generate(), out int randomNumber);
            var randomText = randomizer?.Substring(randomNumber, length).TrimStart().TrimEnd();
            return randomText is null ? string.Empty : randomText;
        }
    }
}