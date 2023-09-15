using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuingForm
{
    public partial class CashierWindowQueueForm : Form
    {
        
        public CashierWindowQueueForm()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
            timer.Tick += new EventHandler(timer1_thick_Tick);
            timer.Start();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);

        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();

            foreach (object obj in CashierList) 
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count != 0)
            {
                if (CashierClass.CashierQueue.Contains(CashierClass.CashierQueue.Peek()))
                {
                    string cs = CashierClass.CashierQueue.Peek();

                    CashierClass.CashierQueue.Peek();
                }

                CashierClass.CashierQueue.Dequeue();

                
            }

            else
            {
                MessageBox.Show("The Queue is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void timer1_thick_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }
    }

    
}
