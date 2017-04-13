
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examples.Expressions.Eval.LINQ_Dynamic.Join_Operators
{
    public partial class GroupJoin : Form
    {
        public GroupJoin()
        {
            InitializeComponent();
        }

        private void uiGroupJoin_LINQ_Execute_Click(object sender, EventArgs e)
        {

        }

        private void uiGroupJoin_LINQ_Click(object sender, EventArgs e)
        {

        }

        private void uiGroupJoin__LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            string[] categories = new string[]{"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };

            var products = My.GetProductList();

            var q =  from c in categories  join p in products on c equals p.Category into ps  select new { Category = c, Products = ps };

            foreach (var v in q)
            {
                Console.WriteLine(v.Category + ":");
                foreach (var p in v.Products)
                {
                    Console.WriteLine("   " + p.ProductName);
                }
            }
        }
    }
}
