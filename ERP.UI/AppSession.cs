namespace ERP.UI
{
    public static class AppSession
    {
        public static bool IsAdmin { get; set; }
        public static string CurrentUsername { get; set; } = string.Empty;
    }
}
