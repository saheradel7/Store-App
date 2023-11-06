using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Store.StoreClasses
{
    internal class Order
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["constrng"].ConnectionString;

        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Insert(Order o)
        {
            bool isSuccess = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(myconnstrng))
                {
                    conn.Open();
                    string sql = "INSERT INTO [order] (Name, Price, TotalPrice ,Quantity, OrderDate) VALUES (@Name, @Price, @TotalPrice ,@Quantity, @OrderDate)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", o.OrderName);
                        cmd.Parameters.AddWithValue("@Price", o.Price);
                        cmd.Parameters.AddWithValue("@TotalPrice", o.TotalPrice);
                        cmd.Parameters.AddWithValue("@Quantity", o.Quantity);
                        cmd.Parameters.AddWithValue("@OrderDate", o.OrderDate);

                        int rows = cmd.ExecuteNonQuery();
                        isSuccess = rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Insert method: " + ex.Message);
            }

            return isSuccess;
        }
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM [order]";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in Select method: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable FilterOrderDataByMonthYear(int mm, int yy)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                try
                {
                    conn.Open();

                    // Construct a SQL query to filter records by month and year.
                    string sql = "SELECT * FROM [order] WHERE DATEPART(Month, OrderDate) = @Month AND DATEPART(Year, OrderDate) = @Year";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Month", mm);
                        cmd.Parameters.AddWithValue("@Year", yy);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in FilterDataByMonthYear method: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable FilterOrderDataByMonthYearOrderByName(int mm, int yy)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                try
                {
                    conn.Open();

                    // Construct a SQL query to filter records by month and year and order by name in descending alphabetical order.
                    string sql = "SELECT * FROM [order] WHERE DATEPART(Month, OrderDate) = @Month AND DATEPART(Year, OrderDate) = @Year " +
                                 "ORDER BY [Name] ASC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Month", mm);
                        cmd.Parameters.AddWithValue("@Year", yy);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in FilterOrderDataByMonthYearOrderByName method: " + ex.Message);
                }
            }
            return dt;
        }
        public decimal CalculateTotalPriceByMonthYear(int mm, int yy)
        {
            decimal totalOrderPrice = 0;
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                try
                {
                    conn.Open();

                    // Construct an SQL query to calculate the sum of TotalPrice for a specific month and year.
                    string sql = "SELECT SUM(TotalPrice) FROM [order] WHERE DATEPART(Month, OrderDate) = @Month AND DATEPART(Year, OrderDate) = @Year";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Month", mm);
                        cmd.Parameters.AddWithValue("@Year", yy);

                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalOrderPrice = Convert.ToDecimal(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in CalculateTotalPriceByMonthYear method: " + ex.Message);
                }
            }
            return totalOrderPrice;
        }




    }
}