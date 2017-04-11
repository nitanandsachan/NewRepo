using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z.Expressions;

namespace Examples.Expressions.Eval.LINQ_Dynamic.Projection_Operators
{
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
        }


        #region Select_Simple_1
        private void uiSelect_Simple_1_LINQ_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsPlusOne = from n in numbers  select n + 1;

            var sb = new StringBuilder();
            sb.AppendLine("Numbers + 1:");

            foreach (var i in numsPlusOne)
            {
                sb.AppendLine(i.ToString());
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiSelect_Simple_1_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsPlusOne = from n in numbers select n + 1;
            var soldOutProducts = numbers.Select(n => "n + 1");

            var sb = new StringBuilder();
            sb.AppendLine("Numbers + 1:");

            foreach (var i in numsPlusOne)
            {
                sb.AppendLine(i.ToString());
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiSelect_Simple_1_LINQ_Execute_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                        
            var numsPlusOne = numbers.Execute<IEnumerable<int>>("Select(n => n +1)");

            var sb = new StringBuilder();
            sb.AppendLine("Numbers + 1:");

            foreach (var i in numsPlusOne)
            {
                sb.AppendLine(i.ToString());
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        #endregion

        #region Where_Simple_1

        private void uiWhere_Simple_1_LINQ_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var lowNums = numbers.Execute<IEnumerable<int>>("Where(n => n + 1)");

            var sb = new StringBuilder();

            sb.AppendLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                sb.AppendLine(x.ToString());
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiWhere_Simple_1_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums = numbers.Where(n => "n < 5");

            var sb = new StringBuilder();

            sb.AppendLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                sb.AppendLine(x.ToString());
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiWhere_Simple_1_LINQ_Execute_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums = numbers.Execute<IEnumerable<int>>("Where(n => n < 5)");

            var sb = new StringBuilder();

            sb.AppendLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                sb.AppendLine(x.ToString());
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        #endregion

        #region Where_Simple_2

        private void uiWhere_Simple_2_LINQ_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var soldOutProducts = products.Where(prod => prod.UnitsInStock == 0);

            var sb = new StringBuilder();

            sb.AppendLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                sb.AppendLine("{0} is sold out!", product.ProductName);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiWhere_Simple_2_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var soldOutProducts = products.Where(prod => "prod.UnitsInStock == 0");

            var sb = new StringBuilder();

            sb.AppendLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                sb.AppendLine("{0} is sold out!", product.ProductName);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiWhere_Simple_2_LINQ_Execute_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var soldOutProducts = products.Execute<IEnumerable<My.Product>>("Where(prod => prod.UnitsInStock == 0)");

            var sb = new StringBuilder();

            sb.AppendLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                sb.AppendLine("{0} is sold out!", product.ProductName);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        #endregion

        #region Where_Simple_3
        private void uiWhere_Simple_3_LINQ_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var expensiveInStockProducts = from prod in products where prod.UnitsInStock > 0 && prod.UnitPrice > 3.00M select prod;

            var sb = new StringBuilder();

            sb.AppendLine("In-stock products that cost more than 3.00:");
            foreach (var product in expensiveInStockProducts)
            {
                sb.AppendLine("{0} is in stock and costs more than 3.00.", product.ProductName);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }
        private void uiWhere_Simple_3_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var expensiveInStockProducts = products.Where(prod => "prod.UnitsInStock > 0 && prod.UnitPrice > 3.00M");

            var sb = new StringBuilder();
            sb.AppendLine("In-stock products that cost more than 3.00:");

            foreach (var product in expensiveInStockProducts)
            {
                sb.AppendLine("{0} is in stock and costs more than 3.00.", product.ProductName);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }
        private void uiWhere_Simple_3_LINQ_Execute_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var expensiveInStockProducts = products.Execute<IEnumerable<My.Product>>("Where(prod => prod.UnitsInStock > 0 && prod.UnitPrice > 3.00M)");

            var sb = new StringBuilder();

            sb.AppendLine("In-stock products that cost more than 3.00:");
            foreach (var product in expensiveInStockProducts)
            {
                sb.AppendLine("{0} is in stock and costs more than 3.00.", product.ProductName);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        #endregion

        #region Where_DrillDown
        private void uiWhere_DrillDown_LINQ_Click(object sender, EventArgs e)
        {
            var customers = My.GetCustomerList();

            var waCustomers = from cust in customers where cust.Region == "WA" select cust;

            var sb = new StringBuilder();

            sb.AppendLine("Customers from Washington and their orders:");
            foreach (var customer in waCustomers)
            {
                sb.AppendLine("Customer {0}: {1}", customer.CustomerID, customer.CompanyName);

                foreach (var order in customer.Orders)
                {
                    sb.AppendLine("  Order {0}: {1}", order.OrderID, order.OrderDate);
                }
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiWhere_DrillDown_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            var customers = My.GetCustomerList();

            var waCustomers = customers.Where(cust => "cust.Region == 'WA'");

            var sb = new StringBuilder();
            sb.AppendLine("Customers from Washington and their orders:");

            foreach (var customer in waCustomers)
            {
                sb.AppendLine("Customer {0}: {1}", customer.CustomerID, customer.CompanyName);

                foreach (var order in customer.Orders)
                {
                    sb.AppendLine("  Order {0}: {1}", order.OrderID, order.OrderDate);
                }
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiWhere_DrillDown_LINQ_Execute_Click(object sender, EventArgs e)
        {
            var customers = My.GetCustomerList();

            var waCustomers = customers.Execute<IEnumerable<My.Customer>>("Where(cust => cust.Region == 'WA')");

            var sb = new StringBuilder();
            sb.AppendLine("Customers from Washington and their orders:");

            foreach (var customer in waCustomers)
            {
                sb.AppendLine("Customer {0}: {1}", customer.CustomerID, customer.CompanyName);
                foreach (var order in customer.Orders)
                {
                    sb.AppendLine("  Order {0}: {1}", order.OrderID, order.OrderDate);
                }
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        #endregion

        #region Where_Indexed
        private void uiWhere_Indexed_LINQ_Click(object sender, EventArgs e)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((digit, index) => digit.Length < index);

            var sb = new StringBuilder();
            sb.AppendLine("Short digits:");

            foreach (var d in shortDigits)
            {
                sb.AppendLine("The word {0} is shorter than its value.", d);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiWhere_Indexed_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where(digit => "digit.Length < digit.index");

            var sb = new StringBuilder();
            sb.AppendLine("Short digits:");

            foreach (var d in shortDigits)
            {
                sb.AppendLine("The word {0} is shorter than its value.", d);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiWhere_Indexed_LINQ_Execute_Click(object sender, EventArgs e)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Execute<IEnumerable<int>>("Where((digit,index) => digit.Length < index)");

            var sb = new StringBuilder();
            sb.AppendLine("Short digits:");

            foreach (var d in shortDigits)
            {
                sb.AppendLine("The word {0} is shorter than its value.", d);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }


        #endregion

        #region Select_Simple_2
        private void uiSelect_Simple_2_LINQ_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var productNames =  from prod in products select prod.ProductName;
            var sb = new StringBuilder();
            sb.AppendLine("Product Names:");
            foreach (var productName in productNames)
            {
                sb.AppendLine(productName);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);

        }
        private void uiSelect_Simple_2_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var productNames = products.Select(prod => "prod.ProductName");

            var sb = new StringBuilder();
            sb.AppendLine("Product Names:");

            foreach (var productName in productNames)
            {
                sb.AppendLine(productName);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }
        private void uiSelect_Simple_2_LINQ_Execute_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var productNames = products.Execute<IEnumerable<My.Product>>("Select(prod => prod.ProductName)");
            
            var sb = new StringBuilder();
            sb.AppendLine("Product Names:");

            foreach (var productName in productNames)
            {
                sb.AppendLine(productName.ProductName);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }


        #endregion

        #region Select_Transformation
        private void uiSelect_Transformation_LINQ_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sb = new StringBuilder();
            var textNums = from n in numbers select strings[n];

            sb.AppendLine("Number strings:");
            foreach (var s in textNums)
            {
                sb.AppendLine(s);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiSelect_Transformation_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sb = new StringBuilder();            
            var textNums = numbers.Select(num => strings[num]);

            sb.AppendLine("Number strings:");
            foreach (var s in textNums)
            {
                sb.AppendLine(s);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiSelect_Transformation_LINQ_Execute_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sb = new StringBuilder();
            var textNums = numbers.Execute<IEnumerable<String>>("Select(num => strings[num]");            

            sb.AppendLine("Number strings:");
            foreach (var s in textNums)
            {
                sb.AppendLine(s);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        #endregion

        #region Select_Indexed
        private void uiSelect_Indexed_LINQ_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

            var sb = new StringBuilder();
            sb.AppendLine("Number: In-place?");

            foreach (var n in numsInPlace)
            {
                sb.AppendLine("{0}: {1}", n.Num, n.InPlace);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiSelect_Indexed_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

            var sb = new StringBuilder();
            sb.AppendLine("Number: In-place?");

            foreach (var n in numsInPlace)
            {
                sb.AppendLine("{0}: {1}", n.Num, n.InPlace);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiSelect_Indexed_LINQ_Execute_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

            var sb = new StringBuilder();
            sb.AppendLine("Number: In-place?");

            foreach (var n in numsInPlace)
            {
                sb.AppendLine("{0}: {1}", n.Num, n.InPlace);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        #endregion

        #region Select_Filtered

        private void uiSelect_Filtered_LINQ_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var lowNums =   from n in numbers  where n < 5  select digits[n];

            var sb = new StringBuilder();
            sb.AppendLine("Numbers < 5:");
            foreach (var num in lowNums)
            {
                sb.AppendLine(num);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }
        private void uiSelect_Filtered_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var lowNums = from n in numbers where n < 5 select digits[n];

            var sb = new StringBuilder();
            sb.AppendLine("Numbers < 5:");
            foreach (var num in lowNums)
            {
                sb.AppendLine(num);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }
        private void uiSelect_Filtered_LINQ_Execute_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var lowNums = from n in numbers where n < 5 select digits[n];

            var sb = new StringBuilder();
            sb.AppendLine("Numbers < 5:");
            foreach (var num in lowNums)
            {
                sb.AppendLine(num);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        #endregion

        private void uiSelect_Anonymous_1_LINQ_Click(object sender, EventArgs e)
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = from word in words select new { Upper = word.ToUpper(), Lower = word.ToLower() };

            var sb = new StringBuilder();
            foreach (var ul in upperLowerWords)
            {
                sb.AppendLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiSelect_Anonymous_1_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = from word in words select new { Upper = word.ToUpper(), Lower = word.ToLower() };

            var sb = new StringBuilder();
            foreach (var ul in upperLowerWords)
            {
                sb.AppendLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiSelect_Anonymous_1_LINQ_Execute_Click(object sender, EventArgs e)
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = from word in words select new { Upper = word.ToUpper(), Lower = word.ToLower() };

            var sb = new StringBuilder();
            foreach (var ul in upperLowerWords)
            {
                sb.AppendLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        private void uiSelect_Anonymous_2_LINQ_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens =  from n in numbers select new { Digit = strings[n], Even = (n % 2 == 0) };

            var sb = new StringBuilder();
            foreach (var d in digitOddEvens)
            {
                sb.AppendLine("The digit {0} is {1}.", d.Digit, d.Even ? "even" : "odd");
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiSelect_Anonymous_2_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens = from n in numbers select new { Digit = strings[n], Even = (n % 2 == 0) };

            var sb = new StringBuilder();
            foreach (var d in digitOddEvens)
            {
                sb.AppendLine("The digit {0} is {1}.", d.Digit, d.Even ? "even" : "odd");
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiSelect_Anonymous_2_LINQ_Execute_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens = from n in numbers select new { Digit = strings[n], Even = (n % 2 == 0) };

            var sb = new StringBuilder();
            foreach (var d in digitOddEvens)
            {
                sb.AppendLine("The digit {0} is {1}.", d.Digit, d.Even ? "even" : "odd");
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }

        private void uiSelect_Anonymous_3_LINQ_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var productInfos = from p in products select new { p.ProductName, p.Category, Price = p.UnitPrice };

            var sb = new StringBuilder();
            sb.AppendLine("Product Info:");
            foreach (var productInfo in productInfos)
            {
                sb.AppendLine("{0} is in the category {1} and costs {2} per unit.", productInfo.ProductName, productInfo.Category, productInfo.Price);
            }

            My.ShowResult(My.LinqResultType.Linq, uiResult, sb);
        }

        private void uiSelect_Anonymous_3_LINQ_Dynamic_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var productInfos = from p in products select new { p.ProductName, p.Category, Price = p.UnitPrice };

            var sb = new StringBuilder();
            sb.AppendLine("Product Info:");
            foreach (var productInfo in productInfos)
            {
                sb.AppendLine("{0} is in the category {1} and costs {2} per unit.", productInfo.ProductName, productInfo.Category, productInfo.Price);
            }

            My.ShowResult(My.LinqResultType.LinqDynamic, uiResult, sb);
        }

        private void uiSelect_Anonymous_3_LINQ_Execute_Click(object sender, EventArgs e)
        {
            var products = My.GetProductList();

            var productInfos = from p in products select new { p.ProductName, p.Category, Price = p.UnitPrice };

            var sb = new StringBuilder();
            sb.AppendLine("Product Info:");
            foreach (var productInfo in productInfos)
            {
                sb.AppendLine("{0} is in the category {1} and costs {2} per unit.", productInfo.ProductName, productInfo.Category, productInfo.Price);
            }

            My.ShowResult(My.LinqResultType.Execute, uiResult, sb);
        }
    }
}
