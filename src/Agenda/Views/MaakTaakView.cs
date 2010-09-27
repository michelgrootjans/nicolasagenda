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
            presenter.CreateTaak();
        }

        public List<string> Vakken
        {
            set
            {
                vakken.Items.Clear();
                vakken.DataSource = value;
            }
        }

        public DateTime DateDue
        {
            get { return dateDue.Value; }
        }

        public string SelectedVak
        {
            get { return vakken.SelectedText; }
        }

        public string Inhoud
        {
            get { return txtInhoud.Text; }
        }
    }

    internal interface IMaakTaakPresenter
    {
        void Initilaize();
        void CreateTaak();
    }

    internal interface IMaakTaakView
    {
        List<string> Vakken { set; }
        DateTime DateDue { get; }
        string SelectedVak { get; }
        string Inhoud { get; }
    }
}