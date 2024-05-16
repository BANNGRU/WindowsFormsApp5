using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=banngru\\sqlexpress;Initial Catalog=bank2;Integrated Security=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bank2DataSet1.customertable". При необходимости она может быть перемещена или удалена.
            this.customertableTableAdapter.Fill(this.bank2DataSet1.customertable);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 cfrm = new Form6();
            cfrm.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text;
            DateTime dateOfBirth = DateTime.Parse(textBox2.Text);
            string lastName = textBox4.Text;
            string contactInfo = textBox7.Text;
            string address = textBox6.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO customertable (firstname, dateofbirth, lastname, contactinfo, address) VALUES (@FirstName, @DateOfBirth, @LastName, @ContactInfo, @Address)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@ContactInfo", contactInfo);
                    command.Parameters.AddWithValue("@Address", address);
                    command.ExecuteNonQuery();
                }
            }
            this.customertableTableAdapter.Fill(this.bank2DataSet1.customertable);
            MessageBox.Show("Информация успешно добавлена в базу данных!");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int id_customer = int.Parse(textboxDeleteId.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM customertable WHERE id = @Id_customer";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id_customer", id_customer);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Информация успешно удалена из базы данных!");
            this.customertableTableAdapter.Fill(this.bank2DataSet1.customertable);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
