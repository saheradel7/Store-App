using Store.storeClasses;
using Store.StoreClasses;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Store
{
    public partial class Form1 : Form
    {
        Product p2 = new Product();
        Order order = new Order();
        BackupService BU = new BackupService();
        static string myconnstr = ConfigurationManager.ConnectionStrings["constrng"].ConnectionString;



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = p2.Select();
            SellGridView.DataSource = dt;

            SellGridView.Columns[0].Visible = false;
            SellGridView.Columns[4].Visible = false;
            SellGridView.Columns[6].Visible = false;
            SellGridView.Columns[7].Visible = false;

            SellGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SellGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Optionally, allow users to resize columns and rows
            SellGridView.AllowUserToResizeColumns = true;
            SellGridView.AllowUserToResizeRows = true;



        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = SellSearchTb.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM product WHERE Name LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SellGridView.DataSource = dt;
        }


        public void clear()
        {
            SellTb1.Text = string.Empty;
            SellTb2.Text = string.Empty;
            SellTb3.Text = string.Empty;
            SellTb4.Text = string.Empty;
            SellSearchTb.Text = string.Empty;
            QuantityToSellTb.Text = string.Empty;

        }

        private void SellGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            SellTb1.Text = SellGridView.Rows[rowindex].Cells[0].Value.ToString();
            SellTb2.Text = SellGridView.Rows[rowindex].Cells[1].Value.ToString();
            SellTb3.Text = SellGridView.Rows[rowindex].Cells[2].Value.ToString();
            SellTb4.Text = SellGridView.Rows[rowindex].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        { 

            if (!int.TryParse(SellTb1.Text, out int IntProductId) ||
                !decimal.TryParse(SellTb3.Text, out decimal productPrice) ||
                !int.TryParse(SellTb4.Text, out int quantity) ||
                !int.TryParse(QuantityToSellTb.Text, out int quantityToSell))
            {
                MessageBox.Show("Enter Quantity To Sell");
                return;
            }

            if (quantityToSell <= 0 || quantityToSell > quantity)
            {
                MessageBox.Show("Enter Valid Quantity");
                return;
            }

            decimal OrderPrice = (productPrice * quantityToSell);
            p2.ProductId = IntProductId;
            p2.Price = OrderPrice;
            p2.Quantity = (quantity-quantityToSell);

            bool sellingproduct = p2.SellProduct(p2);
            if (sellingproduct)
            {
                order.OrderName = SellTb2.Text;
                order.Price = productPrice;
                order.Quantity = quantityToSell ;
                order.TotalPrice = OrderPrice;
                order.OrderDate = DateTime.Now;

                bool savingOrder = order.Insert(order);
                if (savingOrder)
                {
                    MessageBox.Show("Total Price = " + order.TotalPrice);
                    clear();
                }
                else
                {
                    MessageBox.Show("Error while saving order");
                }
            }
            else
            {
                MessageBox.Show("Error While Selling Product.");
            }

            DataTable dt = p2.Select(); 
            SellGridView.DataSource = dt;
        }


        private void SellGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

 
        private void SellTb4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SellTb3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataTable dt = p2.Select(); // Example: Reload data using your Select method
            SellGridView.DataSource = dt;
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BU.PerformBackup();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}



