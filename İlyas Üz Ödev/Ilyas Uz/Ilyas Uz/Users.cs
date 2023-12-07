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

namespace Ilyas_Uz
{
    public partial class Users : Form
    {
        private string connectionString = "Data Source=DESKTOP-9ASHPL0\\SQLEXPRESS;Initial Catalog=ILYASUZ;Integrated Security=True";
        public Users()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void LoadUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAllUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgwUsers.DataSource = dataTable;
                }
            }
        }
        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                InsertUser(userName, password);
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.");
            }
            LoadUsers();
        }
        private void InsertUser(string userName, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        command.ExecuteNonQuery();
                    }
                }

                LoadUsers(); // Ekleme işleminden sonra DataGridView'i güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgwUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgwUsers.SelectedRows[0].Cells["UserId"].Value);
                string userName = txtUserName.Text;
                string password = txtPassword.Text;

                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    UpdateUser(userId, userName, password);
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir kullanıcı seçin.");
            }
            LoadUsers();
        }
        private void UpdateUser(int userId, string userName, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        command.ExecuteNonQuery();
                    }
                }

                LoadUsers(); // Güncelleme işleminden sonra DataGridView'i güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgwUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgwUsers.SelectedRows[0].Cells["UserId"].Value);
                DeleteUser(userId);
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir kullanıcı seçin.");
            }
            LoadUsers();
        }
        private void DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", userId);

                        command.ExecuteNonQuery();
                    }
                }

                LoadUsers(); // Silme işleminden sonra DataGridView'i güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı silinirken bir hata oluştu: " + ex.Message);
            }

        }

        private void dgwUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.RowIndex < dgwUsers.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = dgwUsers.Rows[e.RowIndex];

                // DataGridView'de tıklanan satırın hücre değerlerini TextBox'lara aktar
                txtUserName.Text = selectedRow.Cells["UserName"].Value.ToString();
                txtPassword.Text = selectedRow.Cells["Password"].Value.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            FilterUserDataGridView(searchText);

        }
        private void FilterUserDataGridView(string searchText)
        {
            if (dgwUsers.DataSource is DataTable dataTable)
            {
                // Sadece "username" sütununda arama işlemini gerçekleştirin ve DataGridView'i güncelleyin
                dataTable.DefaultView.RowFilter = $"Convert(UserName, 'System.String') LIKE '%{searchText}%'";
            }
        }
    }
}
