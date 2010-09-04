using System.Collections.Generic;

namespace Agenda
{
    public static class Output
    {
        private static readonly List<IOutputListener> listeners = new List<IOutputListener>();

        public static void Write(object message)
        {
            var msg = message == null ? "null message" : message.ToString();
            listeners.ForEach(l => l.Write(msg));
        }

        public static void Register(IOutputListener listener)
        {
            listeners.Add(listener);
        }
    }
}