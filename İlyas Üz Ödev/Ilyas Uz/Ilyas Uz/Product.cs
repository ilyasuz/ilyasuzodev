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
    public partial class Product : Form
    {
        private string connectionString = "Data Source=DESKTOP-9ASHPL0\\SQLEXPRESS;Initial Catalog=ILYASUZ;Integrated Security=True";

        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
            txtProductSearch.TextChanged += txtProductSearch_TextChanged;
        }
        private void LoadProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAllProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgwProducts.DataSource = dataTable;
                }
            }
        }


        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT CategoryId, CategoryName FROM Categories", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int categoryId = Convert.ToInt32(reader["CategoryId"]);
                                string categoryName = reader["CategoryName"].ToString();

                                cmbCategory.Items.Add(new CategoryItem(categoryId, categoryName));
                            }
                        }
                    }
                }

                if (cmbCategory.Items.Count > 0)
                {
                    cmbCategory.SelectedIndex = 0; // İlk öğeyi seç
                }
                else
                {
                    MessageBox.Show("Kategoriler bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            int stock = Convert.ToInt32(txtStock.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);

            if (cmbCategory.SelectedItem is CategoryItem selectedCategory)
            {
                int categoryId = selectedCategory.CategoryId;
                InsertProduct(productName, stock, price, categoryId);

                MessageBox.Show("Ürün başarıyla eklendi!");
            }
            else
            {
                MessageBox.Show("Lütfen bir kategori seçin.");
            }
            LoadProducts();
        }
        private void InsertProduct(string productName, int stock, decimal price, int categoryId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertProduct", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@Stock", stock);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@CategoryId", categoryId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün eklenirken bir hata oluştu: " + ex.Message);
            }
        }
        public class CategoryItem
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }

            public CategoryItem(int categoryId, string categoryName)
            {
                CategoryId = categoryId;
                CategoryName = categoryName;
            }

            public override string ToString()
            {
                return CategoryName;
            }
        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void SelectComboBoxItemByValue(ComboBox comboBox, int value)
        {
            foreach (CategoryItem item in comboBox.Items)
            {
                if (item.CategoryId == value)
                {
                    comboBox.SelectedItem = item;
                    return;
                }
            }
        }
        private void UpdateProduct(int productId, string productName, int stock, decimal price, int categoryId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ProductId", productId);
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@Stock", stock);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@CategoryId", categoryId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void DeleteProduct(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ProductId", productId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün silinirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgwProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgwProducts.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value);
                string productName = txtProductName.Text;
                int stock = Convert.ToInt32(txtStock.Text);
                decimal price = Convert.ToDecimal(txtPrice.Text);
                int categoryId = (cmbCategory.SelectedItem as CategoryItem)?.CategoryId ?? 0;

                // Güncelleme işlemi
                UpdateProduct(productId, productName, stock, price, categoryId);

                // DataGridView'i güncelle

            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir ürün seçin.");
            }
            LoadProducts();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgwProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgwProducts.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value);

                // Silme işlemi
                DeleteProduct(productId);

                // DataGridView'i güncelle

            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir ürün seçin.");
            }
            LoadProducts();
        }

        private void dgwProducts_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && e.RowIndex < dgwProducts.Rows.Count - 1) // 
            {
                DataGridViewRow selectedRow = dgwProducts.Rows[e.RowIndex];


                txtProductName.Text = selectedRow.Cells["ProductName"].Value.ToString();
                txtStock.Text = selectedRow.Cells["Stock"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["Price"].Value.ToString();


                int categoryId = Convert.ToInt32(selectedRow.Cells["CategoryId"].Value);
                SelectComboBoxItemByValue(cmbCategory, categoryId);
            }
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtProductSearch.Text.Trim();
            FilterProductDataGridView(searchText);
        }
        private void FilterProductDataGridView(string searchText)
        {
            if (dgwProducts.DataSource is DataTable dataTable)
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


