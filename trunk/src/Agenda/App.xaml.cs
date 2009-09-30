using System.Windows;
using Agenda.Extensions;
using Agenda.Views;

namespace Agenda
{
    public partial class App : Application
    {
        private static IWindowManager windowManager;

        public App()
        {
            windowManager = ApplicationStartup.Run();
            Startup += OpenStartupWindow;
        }

        private static void OpenStartupWindow(object sender, StartupEventArgs e)
        {
            windowManager.GetViewAt(1.Oktober(2009).At(9, 00)).Show();
        }
    }
}