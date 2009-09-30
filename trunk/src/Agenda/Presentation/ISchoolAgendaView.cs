using System;
using System.Collections.Generic;
using Agenda.Views;

namespace Agenda.Presentation
{
    internal interface ISchoolAgendaView : IView
    {
        event EventHandler SaveChanges;
        IList<ICourse> Courses { get; }
    }
}