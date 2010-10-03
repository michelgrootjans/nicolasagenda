using System;
using System.Windows.Forms;
using Agendas.Entities;

namespace Agendas.Views
{
    public partial class _vak : UserControl
    {
        public bool HasChanged
        {
            get
            {
                if(vak == null)
                    return false;
                return Equals(originalContent, vak.Inhoud) == false;
            }
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

        private void _vak_Load(object sender, EventArgs e)
        {
            if(DesignMode) return;
            lblNaam.Visible = false;
            txtContent.Visible = false;
        }
    }
}