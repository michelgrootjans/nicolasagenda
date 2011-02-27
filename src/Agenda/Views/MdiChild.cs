using System.Windows.Forms;
using Agendas.Infrastructure;

namespace Agendas.Views
{
    public class MdiChild : Form
    {
        protected MdiChild()
        {
            IocContainer.Register(this);
            Closing += (sender, eventArgs) => IocContainer.Unregister(this);
        }

        public bool HasFocus
        {
            get { return Equals(MdiParent.ActiveMdiChild); }
        }
    }
}