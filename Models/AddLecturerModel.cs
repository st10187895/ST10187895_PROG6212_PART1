using System.Data.SqlClient;
using System.Drawing;

namespace ST10187895_PROG6212_PART1.Models
{
    public class AddLecturerModel
    {
        public static string con_string = "Server=tcp:st10187895.database.windows.net,1433;Initial Catalog=ST10187895_PROG6212_POE;Persist Security Info=False;User ID=st10187895;Password=MMcCord23$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);
        public string contractorID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string position { get; set; }

        public double hourlyRate { get; set; }

        public string password { get; set; }

    public int AddNewLecturer(AddLecturerModel l)
        {
            try
            {

                string sql = "INSERT INTO IndependantContractor(contractorID, name, surname, position, hourlyRate, password) VALUES(@contractorID, @name, @surname, @position, @hourlyRate, @password)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@contractorID", l.contractorID);
                cmd.Parameters.AddWithValue("@name", l.name);
                cmd.Parameters.AddWithValue("@surname", l.surname);
                cmd.Parameters.AddWithValue("@position", l.position);
                cmd.Parameters.AddWithValue("@hourlyRate", l.hourlyRate);
                cmd.Parameters.AddWithValue("@password", l.password);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    } 
}
