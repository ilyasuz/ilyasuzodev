using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;

namespace Ilyas_Uz
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-9ASHPL0\\SQLEXPRESS;Initial Catalog=ILYASUZ;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                // Kullan�c� do�ru ise Form2'yi a�
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide(); // LoginForm'u gizle
            }
            else
            {
                MessageBox.Show("Ge�ersiz kullan�c� ad� veya �ifre.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // TextBox'� �ifre giri�i alan�na d�n��t�rme
            txtPassword.UseSystemPasswordChar = true;

        }
    }
}
