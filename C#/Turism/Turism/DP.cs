using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Turism
{
    public partial class DP : Form
    {
        public DP()
        {
            InitializeComponent();
        }

        public String strNume
        {
            get
            {
                return txtNume.Text.Trim();
            }
        }

        public String strPrenume
        {
            get
            {
                return txtPrenume.Text.Trim();
            }
        }

        public String strCNP
        {
            get
            {
                return txtCNP.Text.Trim();
            }
        }

        public String strJudet
        {
            get
            {
                return cbJudet.Text.Trim();
            }
        }

        public String strDataNasterii
        {
            get
            {
                return dtpDataNasterii.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNume.Text.Trim() == "" || txtPrenume.Text.Trim() == "" || txtCNP.Text.Trim() == "" || cbJudet.Text.Trim() == "")
            {
                MessageBox.Show("Nu ați completat toate informațiile!");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
            else if (txtCNP.Text.Length != 13)
            {
                MessageBox.Show("CNP incorect!");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private void txtCNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }

    }
}
