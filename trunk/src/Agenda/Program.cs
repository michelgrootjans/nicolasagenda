using System;
using System.Windows.Forms;
using Agendas.Infrastructure;
using Agendas.Views;

namespace Agendas
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationStartup.Run();
            Application.Run(new AgendaView());
        }
    }
}
