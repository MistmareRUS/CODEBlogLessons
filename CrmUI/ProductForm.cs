using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class ProductForm : Form
    {
        public Product Product{ get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }
        public ProductForm(Product p)
        {
            InitializeComponent();
            Product = p;
            textBox1.Text = p.Name;
            numericUpDown1.Value = p.Price;
            numericUpDown2.Value = p.Count;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var p = Product ?? new Product();
            p.Name = textBox1.Text;
            p.Price = numericUpDown1.Value;
            p.Count =(int)numericUpDown2.Value;
            Close();
        }
    }
}
