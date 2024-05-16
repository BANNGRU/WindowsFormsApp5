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
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=banngru\\sqlexpress;Initial Catalog=bank2;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bank2DataSet.accounttable". При необходимости она может быть перемещена или удалена.
            this.accounttableTableAdapter.Fill(this.bank2DataSet.accounttable);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 cfrm = new Form6();
            cfrm.Show();
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string accountType = textBox1.Text;
            decimal balance = decimal.Parse(textBox2.Text); // Предполагается, что в текстовом поле вводится число, но вы можете добавить дополнительную проверку
            DateTime dateOpened = DateTime.Parse(textBox3.Text); // Аналогично, предполагается, что в текстовом поле вводится корректная дата
            int idcustomer = int.Parse(textBox4.Text); // Аналогично, предполагается, что в текстовом поле вводится число

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO accounttable (accounttype, balance, dateopened, id_customer) VALUES (@AccountType, @Balance, @DateOpened, @Idcustomer)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountType", accountType);
                command.Parameters.AddWithValue("@Balance", balance);
                command.Parameters.AddWithValue("@DateOpened", dateOpened);
                command.Parameters.AddWithValue("@Idcustomer", idcustomer);
                command.ExecuteNonQuery();
            }
            this.accounttableTableAdapter.Fill(this.bank2DataSet.accounttable);
            MessageBox.Show("Данные успешно добавлены в таблицу!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Получаем значение идентификатора, которое нужно удалить
            int idCustomerToDelete = int.Parse(textBoxIdToDelete.Text);

            // Создаем SQL-запрос для удаления строки с указанным идентификатором из таблицы
            string deleteQuery = "DELETE FROM accounttable WHERE id_customer = @IdCustomerToDelete";

            // Устанавливаем соединение с базой данных и выполняем запрос
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@IdCustomerToDelete", idCustomerToDelete);
                command.ExecuteNonQuery();
            }
            this.accounttableTableAdapter.Fill(this.bank2DataSet.accounttable);

            MessageBox.Show("Запись успешно удалена!");
        }
    }
}


