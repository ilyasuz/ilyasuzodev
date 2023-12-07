namespace Ilyas_Uz
{
    partial class Product
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgwProducts = new DataGridView();
            txtStock = new TextBox();
            txtProductName = new TextBox();
            txtPrice = new TextBox();
            CRUD = new GroupBox();
            btnDel = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cmbCategory = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtProductSearch = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgwProducts).BeginInit();
            CRUD.SuspendLayout();
            SuspendLayout();
            // 
            // dgwProducts
            // 
            dgwProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProducts.Location = new Point(24, 43);
            dgwProducts.Name = "dgwProducts";
            dgwProducts.RowTemplate.Height = 25;
            dgwProducts.Size = new Size(1068, 207);
            dgwProducts.TabIndex = 0;
            dgwProducts.CellClick += dgwProducts_CellClick_1;
            dgwProducts.CellContentClick += dgwProducts_CellContentClick;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(229, 61);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 1;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(229, 22);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(100, 23);
            txtProductName.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(229, 99);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 3;
            // 
            // CRUD
            // 
            CRUD.Controls.Add(btnDel);
            CRUD.Controls.Add(btnUpdate);
            CRUD.Controls.Add(btnAdd);
            CRUD.Controls.Add(cmbCategory);
            CRUD.Controls.Add(label4);
            CRUD.Controls.Add(label3);
            CRUD.Controls.Add(label2);
            CRUD.Controls.Add(label1);
            CRUD.Controls.Add(txtProductName);
            CRUD.Controls.Add(txtStock);
            CRUD.Controls.Add(txtPrice);
            CRUD.Location = new Point(24, 256);
            CRUD.Name = "CRUD";
            CRUD.Size = new Size(356, 247);
            CRUD.TabIndex = 5;
            CRUD.TabStop = false;
            CRUD.Text = "Crud";
            // 
            // btnDel
            // 
            btnDel.Location = new Point(254, 206);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(75, 23);
            btnDel.TabIndex = 12;
            btnDel.Text = "Delete";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(159, 206);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(78, 206);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(229, 145);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(100, 23);
            cmbCategory.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(159, 148);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 8;
            label4.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(159, 69);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 7;
            label3.Text = "Stock";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(159, 107);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 6;
            label2.Text = "Price";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 30);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 5;
            label1.Text = "Product Name";
            // 
            // txtProductSearch
            // 
            txtProductSearch.Location = new Point(935, 12);
            txtProductSearch.Name = "txtProductSearch";
            txtProductSearch.Size = new Size(100, 23);
            txtProductSearch.TabIndex = 6;
            txtProductSearch.TextChanged += txtProductSearch_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(880, 15);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 8;
            label5.Text = "Search :";
            // 
            // Product
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 550);
            Controls.Add(label5);
            Controls.Add(txtProductSearch);
            Controls.Add(CRUD);
            Controls.Add(dgwProducts);
            Name = "Product";
            Text = "Product";
            Load += Product_Load;
            ((System.ComponentModel.ISupportInitialize)dgwProducts).EndInit();
            CRUD.ResumeLayout(false);
            CRUD.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgwProducts;
        private TextBox txtStock;
        private TextBox txtProductName;
        private TextBox txtPrice;
        private GroupBox CRUD;
        private ComboBox cmbCategory;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDel;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtProductSearch;
        private Label label5;
    }
}