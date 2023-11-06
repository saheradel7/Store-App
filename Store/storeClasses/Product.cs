using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.StoreClasses
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }

        public int ResQuantity { get; set; }
        public DateTime ReceivedDate { get;  set; }
        public bool IsSold { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["constrng"].ConnectionString;

        public DataTable Select()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(myconnstrng))
                {
                    conn.Open();
                    string sql = "SELECT * FROM product WHERE IsSold = 0 ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception here.
                // For example, you can output the error message to the console.
                Console.WriteLine("Error in Select method: " + ex.Message);
            }
            return dt;
        }
        public bool Insert(Product p)
        {
            bool isSuccess = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(myconnstrng))
                {
                    conn.Open();
                    string sql = "INSERT INTO product ([Name], [Price], [Quantity], [Received_Date], [Total], [Received_Quantity], [IsSold]) VALUES(@Name, @Price, @Quantity ,@ReceivedDate,@Total ,@ResQuantity, @IsSold)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name",         p.ProductName);
                        cmd.Parameters.AddWithValue("@Price",        p.Price);
                        cmd.Parameters.AddWithValue("@Quantity",     p.Quantity);
                        cmd.Parameters.AddWithValue("@ReceivedDate", p.ReceivedDate);
                        cmd.Parameters.AddWithValue("@Total",        p.TotalPrice);
                        cmd.Parameters.AddWithValue("@ResQuantity",  p.ResQuantity);
                        cmd.Parameters.AddWithValue("@IsSold",       p.IsSold);

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
        public bool Delete(Product p)
        {

            bool IsSuccess = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(myconnstrng))
                {
                    conn.Open();
                    string sql = "UPDATE [product] SET [Received_Quantity] = @resQuantity, " +
                                 "[Total] = [Total] - @TotalPrice, [Quantity] = @Quantity " +
                                 "WHERE [Id] = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
                        cmd.Parameters.AddWithValue("@TotalPrice", p.TotalPrice);
                        cmd.Parameters.AddWithValue("@resQuantity", p.ResQuantity);
                        cmd.Parameters.AddWithValue("@Id", p.ProductId);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            IsSuccess = true;
                            CheckAndUpdateIsSold(p.ProductId);
                            DeleteRowByIdIfResQuantityIsZeroOrNegative(p.ProductId);

                        }
                        else { IsSuccess = false; }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Insert method: " + ex.Message);
            }

            return IsSuccess;

        }
        public void CheckAndUpdateIsSold(int productId)
        {
            string query = "UPDATE product SET IsSold = CASE WHEN Quantity <= 0 THEN 1 ELSE 0 END WHERE Id = @ProductId";

            using (SqlConnection connection = new SqlConnection(myconnstrng))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductId", productId);
                connection.Open();
                command.ExecuteNonQuery();
             
            }
        }
        public decimal CalculateTotalStorePrice()
        {
            decimal totalStorePrice = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(myconnstrng))
                {
                    conn.Open();
                    string sql = "SELECT Price, Quantity FROM product";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            totalStorePrice += price * quantity;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CalculateTotalStorePrice method: " + ex.Message);
            }
            return totalStorePrice;
        }
        public bool SellProduct(Product p)
        {

            bool IsSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE product SET  Quantity = @QuantityToSell, Total = Total -@TotalUpdate WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TotalUpdate", p.Price);
                cmd.Parameters.AddWithValue("@QuantityToSell", p.Quantity);
                cmd.Parameters.AddWithValue("@Id", p.ProductId);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) {
                    IsSuccess = true;
                    CheckAndUpdateIsSold(p.ProductId);
                }
                else { IsSuccess = false; }

            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return IsSuccess;

        }
        public DataTable FilterProductDataByMonthYear(int mm, int yy)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                try
                {
                    conn.Open();

                    // Construct a SQL query to filter records by month and year.
                    string sql = "SELECT * FROM [product] WHERE DATEPART(Month, Received_Date) = @Month AND DATEPART(Year, Received_Date) = @Year";
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
        public DataTable FilterProductDataByMonthYearOrderByName(int mm, int yy)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                try
                {
                    conn.Open();

                    // Construct a SQL query to filter records by month and year and order by name in descending alphabetical order.
                    string sql = "SELECT * FROM [product] WHERE DATEPART(Month, Received_Date) = @Month AND DATEPART(Year, Received_Date) = @Year ORDER BY [Name] ASC";
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
                    Console.WriteLine("Error in FilterProductDataByMonthYear method: " + ex.Message);
                }
            }
            return dt;
        }
        public decimal CalculateTotalProductPriceByMonthYear(int mm, int yy)
        {
            decimal totalProductPrice = 0;
            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                try
                {
                    conn.Open();

                    // Construct an SQL query to calculate the sum of TotalPrice for a specific month and year.
                    string sql = "SELECT SUM(Total) FROM [product] WHERE DATEPART(Month, Received_Date) = @Month AND DATEPART(Year, Received_Date) = @Year";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Month", mm);
                        cmd.Parameters.AddWithValue("@Year", yy);

                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalProductPrice = Convert.ToDecimal(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in CalculateTotalPriceByMonthYear method: " + ex.Message);
                }
            }
            return totalProductPrice;
        }
        public void DeleteRowByIdIfResQuantityIsZeroOrNegative(int id)
        {

            using (SqlConnection conn = new SqlConnection(myconnstrng))
            {
                try
                {
                    conn.Open();

                    // Construct an SQL query to calculate the sum of TotalPrice for a specific month and year.
                    string sql = "DELETE FROM product WHERE Id = @Id AND Received_Quantity <= 0";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        cmd.ExecuteScalar();
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in CalculateTotalPriceByMonthYear method: " + ex.Message);
                }
            }
        }



    }
}
