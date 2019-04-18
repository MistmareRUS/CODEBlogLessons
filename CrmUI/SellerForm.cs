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
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }
        public SellerForm(Seller s):this()
        {
            Seller = s;
            textBox1.Text = s.Name;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var s = Seller ?? new Seller();
            s.Name = textBox1.Text ;
            Close();
        }
    }
}
