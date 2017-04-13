
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
    public partial class LeftOuterJoin : Form
    {
        public LeftOuterJoin()
        {
            InitializeComponent();
        }

        private void uiLeftOuterJoin_LINQ_Execute_Click(object sender, EventArgs e)
        {

        }

        private void uiLeftOuterJoin_LINQ_Dynamic_Click(object sender, EventArgs e)
        {

        }

        private void uiLeftOuterJoin_LINQ_Click(object sender, EventArgs e)
        {
            string[] categories = new string[]{"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };

            var products = My.GetProductList();

            var q =
                from c in categories
                join p in products on c equals p.Category into ps
                from p in ps.DefaultIfEmpty()
                select new { Category = c, ProductName = p == null ? "(No products)" : p.ProductName };

            foreach (var v in q)
            {
                Console.WriteLine(v.ProductName + ": " + v.Category);
            }
        }
    }
}
