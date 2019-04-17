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
    public partial class Main : Form
    {
        CrmBL.Model.CRMContext db;
        public Main()
        {
            InitializeComponent();
            db = new CrmBL.Model.CRMContext();
        }
              
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalog = new Catalog<Product>(db.Products);
            catalog.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalog = new Catalog<Seller>(db.Sellers);
            catalog.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalog = new Catalog<Customer>(db.Customers);
            catalog.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalog = new Catalog<Check>(db.Checks);
            catalog.Show();
        }

        private void AddProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(form.Product);
                db.SaveChanges();
            }
        }

        private void AddSellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SellerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(form.Seller);
                db.SaveChanges();
            }
        }

        private void AddCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(form.Customer);
                db.SaveChanges();
            }
        }
    }
}
