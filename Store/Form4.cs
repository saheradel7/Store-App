using Store.storeClasses;
using Store.StoreClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Store
{
    public partial class Form4 : Form
    {
        static string myconnstr = ConfigurationManager.ConnectionStrings["constrng"].ConnectionString;
        Product p4 = new Product();
        BackupService BU = new BackupService();
        public Form4()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;
        }
        public void clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int IntProductId) ||
                !decimal.TryParse(textBox3.Text, out decimal productPrice) ||
                !int.TryParse(textBox4.Text, out int quantity) ||
                !int.TryParse(textBox6.Text, out int quantityToDelete)||
                !int.TryParse(textBox7.Text, out int ResQuantity))
            {
                MessageBox.Show("Enter Quantity To Delete");
                return;
            }

            if (quantityToDelete <= 0 || quantityToDelete > quantity)
            {
                MessageBox.Show("Enter Valid Quantity");
                return;
            }

            p4.ProductId = IntProductId;
            p4.Quantity = quantity - quantityToDelete;
            p4.Price = productPrice;
            p4.TotalPrice = productPrice * quantityToDelete;
            p4.ResQuantity = ResQuantity - quantityToDelete;

            bool success = p4.Delete(p4);
            if (success)
            {
                MessageBox.Show("Item Successfully Deleted.");
                clear();
            }
            else
            {
                MessageBox.Show("Item Was Not Deleted.");
            }

            DataTable dt = p4.Select();
            dataGridView1.DataSource = dt;
            //textBox6.Text = p4.CalculateTotalStorePrice().ToString();


        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable dt = p4.Select();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[6].DisplayIndex = 3;
            dataGridView1.Columns[3].DisplayIndex = 6;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;

            
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
            DataTable dt = p4.Select(); // Example: Reload data using your Select method
            dataGridView1.DataSource = dt;
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BU.PerformBackup();
        }
    }
}














//DELETE BUTTON

//private void deletebtn_Click(object sender, EventArgs e)
//{
//    string productIdString = textBox1.Text;
//    string name = textBox2.Text;
//    string priceString = textBox3.Text;
//    string quantityString = textBox4.Text;

//    if (string.IsNullOrWhiteSpace(productIdString) || string.IsNullOrWhiteSpace(name) ||
//        string.IsNullOrWhiteSpace(priceString) || string.IsNullOrWhiteSpace(quantityString))
//    {
//        MessageBox.Show("All fields are required for deletion.");
//        return; // Exit the method without performing the delete
//    }

//    if (!int.TryParse(productIdString, out int productId))
//    {
//        MessageBox.Show("Invalid Product ID entered.");
//        return; // Exit the method without performing the delete
//    }

//    if (!decimal.TryParse(priceString, out decimal price))
//    {
//        MessageBox.Show("Invalid Price entered.");
//        return; // Exit the method without performing the delete
//    }

//    if (!int.TryParse(quantityString, out int quantity))
//    {
//        MessageBox.Show("Invalid Quantity entered.");
//        return; // Exit the method without performing the delete
//    }

//    p.ProductId = productId;
//    p.Quantity = quantity;
//    bool success = p.Delete(productId, p);
//    if (success)
//    {
//        MessageBox.Show("Item Successfully Deleted.");
//        clear();
//    }
//    else
//    {
//        MessageBox.Show("Item Was Not Deleted.");
//    }

//    DataTable dt = p.Select();
//    dataGridView1.DataSource = dt;
//    textBox6.Text = p.CalculateTotalStorePrice().ToString();
//}