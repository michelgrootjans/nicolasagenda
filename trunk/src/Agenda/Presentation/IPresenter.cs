using Agenda.Views;

namespace Agenda.Presentation
{
    public interface IPresenter
    {
        IView View { get; }
    }
}