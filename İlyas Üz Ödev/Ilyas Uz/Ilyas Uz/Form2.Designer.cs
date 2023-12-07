namespace Ilyas_Uz
{
    partial class Form2
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
            dgwCategories = new DataGridView();
            txtCategoryName = new TextBox();
            label1 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDel = new Button();
            txtCategorySearch = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgwCategories).BeginInit();
            SuspendLayout();
            // 
            // dgwCategories
            // 
            dgwCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwCategories.Location = new Point(42, 42);
            dgwCategories.Name = "dgwCategories";
            dgwCategories.RowTemplate.Height = 25;
            dgwCategories.Size = new Size(708, 150);
            dgwCategories.TabIndex = 0;
            dgwCategories.CellClick += dgwCategories_CellClick;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(153, 227);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(100, 23);
            txtCategoryName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 230);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "Category Name";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(103, 306);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(195, 306);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(285, 306);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(75, 23);
            btnDel.TabIndex = 5;
            btnDel.Text = "Delete";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // txtCategorySearch
            // 
            txtCategorySearch.Location = new Point(630, 13);
            txtCategorySearch.Name = "txtCategorySearch";
            txtCategorySearch.Size = new Size(100, 23);
            txtCategorySearch.TabIndex = 6;
            txtCategorySearch.TextChanged += txtCategorySearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(567, 16);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 7;
            label2.Text = "Search :";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(txtCategorySearch);
            Controls.Add(btnDel);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(txtCategoryName);
            Controls.Add(dgwCategories);
            Name = "Form2";
            Text = "Categories";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgwCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgwCategories;
        private TextBox txtCategoryName;
        private Label label1;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDel;
        private TextBox txtCategorySearch;
        private Label label2;
    }
}