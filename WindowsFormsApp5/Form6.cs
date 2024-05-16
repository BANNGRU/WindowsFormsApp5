using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        Form1 cfrm = new Form1();
            cfrm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 cfrm = new Form2();
            cfrm.Show();
            Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Form4 cfrm = new Form4();
            cfrm.Show();
            Hide();
        }
    }
}
