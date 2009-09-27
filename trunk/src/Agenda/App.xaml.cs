using System;
using System.Windows;
using Agenda.Presentation;

namespace Agenda
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
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
            var mainWindow = windowManager.GetViewAt(DateTime.Now);
            mainWindow.Show();
        }
    }
}