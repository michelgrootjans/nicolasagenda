using System;

namespace Agenda.Extensions
{
    public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler eventHandler, object sender, EventArgs e)
        {
            if (eventHandler != null)
                eventHandler(sender, e);
        }        
    }
}