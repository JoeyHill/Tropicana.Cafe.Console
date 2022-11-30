using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tropicana.Cafe.Forms.MiscForms
{
    public partial class NumberMealsQuantity : Form
    {
        public int Count = 0;
        public int CurrentMealCount = 0;

        public NumberMealsQuantity()
        {
            InitializeComponent();
        }

        public void SetMaxCount(int Count)
        {
            DebitCounter.Maximum = Count;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(CurrentMealCount < Convert.ToInt32(DebitCounter.Value))
            {
                MessageBox.Show(String.Format("This person only has {0} meals remaining.",DebitCounter.Value), "Error", MessageBoxButtons.OK);
                return;
            }
            if(DebitCounter.Value > 1)
            {
                DialogResult r = MessageBox.Show(String.Format("This will deduct {0} meals from this entry. Are you sure you want to do this?", DebitCounter.Value), "Are you sure?", MessageBoxButtons.OKCancel);
                if(r == DialogResult.Cancel)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
            }
            this.Count = Convert.ToInt32(DebitCounter.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
