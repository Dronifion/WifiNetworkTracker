using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WlanLocationDLPPoc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //Initial Form1, so that Form2 can update Form1 components.
        private Form1 mainForm = null;
        public Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtId.Text == "lester") && (txtPw.Text == "abcd1234"))
            {
                this.mainForm.SignalTextFrm2 = "Success";
                this.Close();
            }
            else
            {
                this.mainForm.SignalTextFrm2 = "";
                MessageBox.Show("Invalid user ID or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
