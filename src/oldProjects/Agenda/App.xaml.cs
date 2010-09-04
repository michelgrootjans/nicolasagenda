using System;
using Agenda.Presenters;

namespace Agenda
{
    public partial class App
    {
        protected override object CreateRootModel()
        {
            Output.Register(new ConsoleOutputListener());
            return Container.GetInstance<IDagPresenter>();
        }
    }

    public class ConsoleOutputListener : IOutputListener
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}