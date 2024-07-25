namespace Rehber
{
    internal static class Program
    {
        public static MainForm MainFormInstance { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainFormInstance = new MainForm();
            Application.Run(MainFormInstance);

        }
    }
}