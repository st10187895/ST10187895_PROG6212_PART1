using System.Data.SqlClient;
using System.Drawing;

namespace ST10187895_PROG6212_PART1.Models
{
    public class ManageClaimsModel
    {
        public static string con_string = "Server=tcp:st10187895.database.windows.net,1433;Initial Catalog=ST10187895_PROG6212_POE;Persist Security Info=False;User ID=st10187895;Password=MMcCord23$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);

        public string claimID { get; set; }
        public string newStatus { get; set; }
        public string rejected = "rejected";
        public string approved = "approved";


        public bool UpdateClaim(int claimID, string status)
        {
            try
            {
                string sql = "UPDATE CLAIM SET claimStatus = @action WHERE claimID = @claimID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@claimID", claimID);
                cmd.Parameters.AddWithValue("@action", status);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected > 0;
            }
            catch 
            {
                return false;
            }
        }
        public int ApproveClaim(ManageClaimsModel c)
        {
            try
            {
                string sql = "UPDATE CLAIM SET claimStatus = 'Approved' WHERE claimID = @claimID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@claimID", c.claimID);
                cmd.Parameters.AddWithValue("@newStatus", c.approved);
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

        public int RejectClaim(ManageClaimsModel c)
        {
            try
            {
                string sql = "UPDATE CLAIM SET claimStatus = 'Reject' WHERE claimID = @claimID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@claimID", c.claimID);
                cmd.Parameters.AddWithValue("@newStatus", c.rejected);
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
