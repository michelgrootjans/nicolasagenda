using System.Windows;
using Agenda.Extensions;
using Agenda.Presentation;
using Agenda.Views;

namespace Agenda
{
    public partial class App : Application
    {
        private static IWindowManager windowManager;

        public App()
        {
            new SchoolAgenda(ApplicationStartup.Run()).Show();
        }
    }
}