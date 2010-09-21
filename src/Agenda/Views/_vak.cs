using System;
using System.Windows.Forms;
using Agendas.Entities;

namespace Agendas.Views
{
    public partial class _vak : UserControl
    {
        public bool HasChanged
        {
            get { return Equals(originalContent, vak.Inhoud); }
        }

        private ILesUur vak;
        private string originalContent;

        public _vak()
        {
            InitializeComponent();
        }

        public void SetVak(ILesUur value)
        {
            vak = value;
            lblNaam.Text = vak.Naam;
            txtContent.Text = vak.Inhoud;
            originalContent = vak.Inhoud;
            lblNaam.Visible = true;
            txtContent.Visible = true;
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            vak.Inhoud = txtContent.Text;
        }
    }
}