using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ilyas_Uz
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product form = new Product();
            form.Show();
            this.Hide(); // LoginForm'u gizle
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide(); // LoginForm'u gizle
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide(); // LoginForm'u gizle
        }
    }
}
