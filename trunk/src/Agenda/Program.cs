using System;
using System.Windows.Forms;
using Agendas.Infrastructure;
using Agendas.Views;

namespace Agendas
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationStartup.Run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AgendaView());
        }
    }
}