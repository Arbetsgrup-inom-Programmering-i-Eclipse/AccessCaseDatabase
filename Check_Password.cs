using System;
using System.Windows.Forms;

namespace Check_Password
{
    public partial class Check_Password : System.Windows.Forms.Form
    {
        public string pass { get; private set; }
        public Check_Password()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
            this.ActiveControl = textBox_pass;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            pass = textBox_pass.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
