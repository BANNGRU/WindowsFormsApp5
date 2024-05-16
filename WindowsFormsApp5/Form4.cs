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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bank2DataSet2.reporttable". При необходимости она может быть перемещена или удалена.
            this.reporttableTableAdapter.Fill(this.bank2DataSet2.reporttable);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 cfrm = new Form6();
            cfrm.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form6 cfrm = new Form6();
            cfrm.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
