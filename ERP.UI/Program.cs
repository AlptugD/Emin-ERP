namespace ERP.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                var userManager = new ERP.BLL.UserManager();
                userManager.EnsureDatabaseCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Veritabanı Bağlantı Durumu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new FormGiris());
        }
    }
}