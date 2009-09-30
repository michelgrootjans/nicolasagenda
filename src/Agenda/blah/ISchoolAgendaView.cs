using Agenda.Views;

namespace Agenda.Presentation
{
    internal interface ISchoolAgendaView : IView
    {
        ICourse GetCourse(int hour);
    }
}