using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Catalog<T> : Form where T:class
    {
        CRMContext db;
        DbSet<T> set;
        public Catalog(DbSet<T> set,CRMContext db)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }
        private void Catalog_Load(object sender, EventArgs e)
        {
             
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                //var form = new SellerForm();
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    db.Sellers.Add(form.Seller);
                //    db.SaveChanges();
                //}
            }
            else if(typeof(T) == typeof(Seller))
            {

            }
            else if (typeof(T) == typeof(Customer))
            {

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var id= dataGridView1.SelectedRows[0].Cells[0].Value;
            if (typeof(T) == typeof(Product))
            {
                var p=set.Find(id)as Product;
                if (p != null)
                {
                    var form = new ProductForm(p);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        p = form.Product;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var s = set.Find(id) as Seller;
                if (s != null)
                {
                    var form = new SellerForm(s);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        s = form.Seller;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var c = set.Find(id) as Customer;
                if (c != null)
                {
                    var form = new CustomerForm(c);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        c = form.Customer;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
        }
    }
}
