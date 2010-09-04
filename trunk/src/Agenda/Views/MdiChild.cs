using System.Windows.Forms;
using Agendas.Infrastructure;

namespace Agendas.Views
{
    public class MdiChild : Form
    {
        protected MdiChild()
        {
            IocContainer.Register(this);
            this.Closing += (sender, eventArgs) => IocContainer.Unregister(this);
        }
    }

    
}