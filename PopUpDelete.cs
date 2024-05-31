using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;

namespace Form2
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        public Form2(ListView.SelectedListViewItemCollection Selection)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
            this.label_Question.Text = "Ta bort " + Selection.Count + " fall från Databasen?";
        }


        private void button_Ja_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void button_Nej_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            return;
        }
    }
}
