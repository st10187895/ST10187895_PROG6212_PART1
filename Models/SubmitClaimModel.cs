using System.Data.SqlClient;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;


namespace ST10187895_PROG6212_PART1.Models
{
    public class SubmitClaimModel
    {
        public static string con_string = "Server=tcp:st10187895.database.windows.net,1433;Initial Catalog=ST10187895_PROG6212_POE;Persist Security Info=False;User ID=st10187895;Password=MMcCord23$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    
        public static SqlConnection con = new SqlConnection(con_string);


        public string contractorID {  get; set; }
        public double hourlyRate { get; set; }
        public double hoursWorked { get; set; }
        //public double amount {  get; set; }
        public string notes { get; set; }

        public string claimStatus = "pending";
        public string documentPath { get; set; }

        //public double getHourly(string userID)
        //{
        //    SubmitClaimModel userInfo = new SubmitClaimModel();
        //    //List<SubmitClaimModel> contractor = new List<SubmitClaimModel>();
        //    using (SqlConnection con = new SqlConnection(con_string))
        //    {
        //        string sql = "SELECT hourlyRate FROM IndependantContractor WHERE contractorID = @";
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            userInfo.hourlyRate = Convert.ToDouble(reader["hourlyRate"]);
        //        }  
        //        reader.Close();
        //    }
        //    return userInfo.hourlyRate;
        //}
        public int SubmitClaim(SubmitClaimModel c)
        {
            
            try
            {
                string sql = "INSERT INTO CLAIM(contractorID, hoursWorked, hourlyRate, notes, claimStatus, document) VALUES(@contractorID, @hoursWorked, @hourlyRate, @notes, @claimStatus, @documentPath)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@contractorID", c.contractorID);
                cmd.Parameters.AddWithValue("@hoursWorked", c.hoursWorked);
                cmd.Parameters.AddWithValue("@hourlyRate", c.hourlyRate);
                cmd.Parameters.AddWithValue("@notes", c.notes);
                cmd.Parameters.AddWithValue("@claimStatus", c.claimStatus);
                cmd.Parameters.AddWithValue("@documentPath", c.documentPath);
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
