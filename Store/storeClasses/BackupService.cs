using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.storeClasses
{
    internal class BackupService
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["constrng"].ConnectionString;

        public void PerformBackup()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            string backupScript = "BACKUP DATABASE StoreDB TO DISK = 'C:\\Users\\saher\\Desktop\\final\\Store\\BackUp\\backup.bac'";

            try
            {
                using (SqlConnection connection = new SqlConnection(myconnstrng))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(backupScript, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error while backup");
            }
        }
    }
}
