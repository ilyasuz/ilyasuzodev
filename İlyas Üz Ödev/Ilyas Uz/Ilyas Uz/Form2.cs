using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ilyas_Uz
{
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=DESKTOP-9ASHPL0\\SQLEXPRESS;Initial Catalog=ILYASUZ;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }
        private void LoadCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CategoryId, CategoryName FROM Categories", connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgwCategories.DataSource = dataTable;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;

            if (!string.IsNullOrEmpty(categoryName))
            {
                InsertCategory(categoryName);
                LoadCategories();
                MessageBox.Show("Kategori başarıyla eklendi!");
            }
            else
            {
                MessageBox.Show("Lütfen bir kategori adı girin.");
            }
            LoadCategories();
        }
        private void InsertCategory(string categoryName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", categoryName);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgwCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgwCategories.SelectedRows[0];
                int categoryId = Convert.ToInt32(selectedRow.Cells["CategoryId"].Value);
                string categoryName = txtCategoryName.Text;

                if (!string.IsNullOrEmpty(categoryName))
                {
                    UpdateCategory(categoryId, categoryName);
                    LoadCategories();
                    MessageBox.Show("Kategori başarıyla güncellendi!");
                }
                else
                {
                    MessageBox.Show("Lütfen bir kategori adı girin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir kategori seçin.");
            }
            LoadCategories();
        }
        private void UpdateCategory(int categoryId, string categoryName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryId", categoryId);
                        command.Parameters.AddWithValue("@CategoryName", categoryName);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgwCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgwCategories.SelectedRows[0];
                int categoryId = Convert.ToInt32(selectedRow.Cells["CategoryId"].Value);

                DeleteCategory(categoryId);
                LoadCategories();
                MessageBox.Show("Kategori başarıyla silindi!");
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir kategori seçin.");
            }
            LoadCategories();
        }
        private void DeleteCategory(int categoryId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryId", categoryId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori silinirken bir hata oluştu: " + ex.Message);
            }
        }

        private void dgwCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.RowIndex < dgwCategories.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = dgwCategories.Rows[e.RowIndex];

                // DataGridView'de tıklanan satırın hücre değerlerini TextBox'lara aktar
                txtCategoryName.Text = selectedRow.Cells["CategoryName"].Value.ToString();
            }
        }

        private void txtCategorySearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtCategorySearch.Text.Trim();
            FilterCategoryDataGridView(searchText);
        }
        private void FilterCategoryDataGridView(string searchText)
        {
            if (dgwCategories.DataSource is DataTable dataTable)
            {
                // Tüm sütunlarda arama işlemini gerçekleştirin ve DataGridView'i güncelleyin
                string filterExpression = string.Join(" OR ", dataTable.Columns
                    .OfType<DataColumn>()
                    .Select(column => $"Convert({column.ColumnName}, 'System.String') LIKE '%{searchText}%'"));

                dataTable.DefaultView.RowFilter = filterExpression;
            }
        }

    }
}
