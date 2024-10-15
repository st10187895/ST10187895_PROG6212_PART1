using System.Data.SqlClient;
using System.Xml.Linq;

namespace ST10187895_PROG6212_PART1.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:st10187895.database.windows.net,1433;Initial Catalog=ST10187895_PROG6212_POE;Persist Security Info=False;User ID=st10187895;Password=MMcCord23$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public string findUser(string personID, string password)
        {
            string userId = "-1";
            using (SqlConnection connection = new SqlConnection(con_string))
            {
                string sql = "SELECT contractorID FROM IndependantContractor WHERE contractorID = @personID AND password = @password";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@personID", personID);
                cmd.Parameters.AddWithValue("@password", password);
                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = (string)result;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return userId;
        }
    }
}
