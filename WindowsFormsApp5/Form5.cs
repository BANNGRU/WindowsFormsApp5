using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form5 : Form
    {
        private string connectionString = "Data Source=banngru\\sqlexpress;Initial Catalog=bank2;Integrated Security=True;";

        public Form5()
        {
            InitializeComponent();
        }

        public class UserManager
        {
            private string connectionString;

            public UserManager(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public bool AuthenticateUser(string username, string password)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM passwordtable WHERE username = @Username AND password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }

            public void RegisterUser(string username, string password)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO passwordtable (username, password) VALUES (@Username, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            UserManager userManager = new UserManager(connectionString);
            if (userManager.AuthenticateUser(username, password))
            {
                MessageBox.Show("Вы успешно вошли в систему!");
                Form6 cfrm = new Form6();
                cfrm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль!");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            UserManager userManager = new UserManager(connectionString);
            userManager.RegisterUser(username, password);
            MessageBox.Show("Вы успешно зарегистрированы!");
        }
    }
}