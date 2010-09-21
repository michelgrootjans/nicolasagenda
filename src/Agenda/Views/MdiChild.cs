using System;
using System.Windows.Forms;
using Agendas.Infrastructure;

namespace Agendas.Views
{
    public abstract class MdiChild<T> : Form
    {
        protected readonly IPresenter<T> presenter;

        protected MdiChild()
        {
            IocContainer.Register(this);
            presenter = CreatePresenter();
            Closing += (sender, eventArgs) => IocContainer.Unregister(this);
            Closing += (sender, eventArgs) => presenter.Dispose();
        }

        protected abstract IPresenter<T> CreatePresenter();
    }

    public interface IPresenter<T> : IDisposable
    {
        void Initialize();
    }
}