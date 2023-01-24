namespace Task1_0.Utils
{
    public static class DriverUtils
    {
        public static string? GetTextOfFirstChildElement<T>(T item, By locator) where T : IElement
        {
            return item.FindChildElements<T>(locator).FirstOrDefault()?.GetText();
        }
    }
}