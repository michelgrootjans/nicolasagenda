using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Agendas.Views
{
    public partial class MaakTaakView : Form, IMaakTaakView
    {
        private IMaakTaakPresenter presenter;

        public MaakTaakView()
        {
            InitializeComponent();
        }

        private void MaakTaakView_Load(object sender, EventArgs e)
        {
            presenter = new MaakTaakPresenter(this);
            presenter.Initilaize();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
        }

        public List<string> Vakken
        {
            set
            {
                vakken.Items.Clear();
                vakken.DataSource = value;
            }
        }
    }

    internal interface IMaakTaakPresenter
    {
        void Initilaize();
    }

    internal class MaakTaakPresenter : IMaakTaakPresenter
    {
        private readonly IMaakTaakView view;

        public MaakTaakPresenter(IMaakTaakView view)
        {
            this.view = view;
        }

        public void Initilaize()
        {
            view.Vakken = new List<string>{"FRA", "NED"};
        }
    }

    internal interface IMaakTaakView
    {
        List<string> Vakken { set; }
    }
}