using Store.StoreClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Store
{
    public partial class Form2 : Form
    {

        Product p = new Product(); 
        public Form2()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string productName = textBox2.Text;
            string priceString = textBox3.Text;
            string quantityString = textBox4.Text;

            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(priceString) || string.IsNullOrWhiteSpace(quantityString))
            {
                MessageBox.Show("Please fill in all required fields.");
                return; // Exit the method without performing the insertion
            }

            if (!decimal.TryParse(priceString, out decimal productPrice))
            {
                MessageBox.Show("Invalid Price value entered.");
                return; // Exit the method without performing the insertion
            }

            if (!int.TryParse(quantityString, out int Quantity))
            {
                MessageBox.Show("Invalid Quantity value entered.");
                return; // Exit the method without performing the insertion
            }

            if (Quantity <= 0)
            {
                MessageBox.Show("invalid Quantity");
                return;
            }

            p.ProductName =   productName;
            p.Price =  productPrice;
            p.Quantity = Quantity;
            p.TotalPrice =    productPrice * Quantity;
            p.ResQuantity = Quantity;
            p.ReceivedDate =  DateTime.Now;
            p.IsSold = false;

          
            
            bool success = p.Insert(p);
            if (success)
            {
                MessageBox.Show("Item Successfully Inserted.");
                clear();
            }
            else
            {
                MessageBox.Show("Item Was Not Inserted.");
            }

            DataTable dt = p.Select();
            dataGridView1.DataSource = dt;
            textBox6.Text = p.CalculateTotalStorePrice().ToString();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = p.Select();
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Optionally, allow users to resize columns and rows
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            textBox6.Text = p.CalculateTotalStorePrice().ToString();

        }

        public void clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
           

        }



        private void resetbtn_Click(object sender, EventArgs e)
        {
            clear();
        }

       


        static string myconnstr = ConfigurationManager.ConnectionStrings["constrng"].ConnectionString;


        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox5.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM product WHERE Name LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataTable dt = p.Select(); // Example: Reload data using your Select method
            dataGridView1.DataSource = dt;
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}





