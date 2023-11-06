using Store.StoreClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class Form3 : Form
    {
        Product pro =new Product();
        Order ord = new Order();
        static string myconnstr = ConfigurationManager.ConnectionStrings["constrng"].ConnectionString;

        public Form3()
        {
            InitializeComponent();

            comboBox1.Items.Add("Name");
            comboBox1.Items.Add("Date");
            comboBox1.SelectedIndex = 0;


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;

            // Populate the ComboBox with month names.
            comboBoxMonth1.Items.AddRange(DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToArray());
            numericUpDownYear1.Minimum = 2000;
            numericUpDownYear1.Maximum = DateTime.Now.Year;
            numericUpDownYear1.Value = DateTime.Now.Year; // Set the initial year.
            comboBoxMonth1.SelectedIndexChanged += UpdateDisplayedDate;
            numericUpDownYear1.ValueChanged += UpdateDisplayedDate;
            UpdateDisplayedDate(this, EventArgs.Empty);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable dt = ord.Select();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Optionally, allow users to resize columns and rows
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;


        }


        private void UpdateDisplayedDate(object sender, EventArgs e)
        {
            // Get the selected month and year.
            int selectedMonth = comboBoxMonth1.SelectedIndex + 1; // Months are 1-based.
            int selectedYear = (int)numericUpDownYear1.Value;

            // Update the displayed date.
            //labelSelectedDate.Text = $"{selectedMonth:00}/{selectedYear:0000}";
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedMonth = comboBoxMonth1.SelectedIndex + 1;
            int selectedYear = (int)numericUpDownYear1.Value;
            string selectedSort = comboBox1.SelectedItem.ToString();
            DataTable dt;
            if (selectedSort == "Name")
            {
                dt = ord.FilterOrderDataByMonthYearOrderByName(selectedMonth, selectedYear);
            }
            else // Default to "Order by Date"
            {
                dt = ord.FilterOrderDataByMonthYear(selectedMonth, selectedYear);
            }

            dataGridView1.DataSource = dt;
            decimal tp = ord.CalculateTotalPriceByMonthYear(selectedMonth, selectedYear);
            textBox1.Text = tp.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedMonth = comboBoxMonth1.SelectedIndex + 1;
            int selectedYear = (int)numericUpDownYear1.Value;
            string selectedSort = comboBox1.SelectedItem.ToString();
            DataTable dt;
            if (selectedSort == "Name")
            {
                dt = pro.FilterProductDataByMonthYearOrderByName(selectedMonth, selectedYear);
            }
            else // Default to "Order by Date"
            {
                dt =pro.FilterProductDataByMonthYear(selectedMonth, selectedYear);
            }

            dataGridView1.DataSource = dt;
            decimal tp = pro.CalculateTotalProductPriceByMonthYear(selectedMonth, selectedYear);
            textBox1.Text = tp.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
