using System.Data;
using System.Data.SqlClient;

namespace ST10187895_PROG6212_PART1.Models
{
    public class ReviewClaimsModel
    {
        public static string con_string = "Server=tcp:st10187895.database.windows.net,1433;Initial Catalog=ST10187895_PROG6212_POE;Persist Security Info=False;User ID=st10187895;Password=MMcCord23$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);

        public int claimID { get; set; }
        public string contractorID { get; set; }
        public string contractorName {  get; set; }
        public double hourlyRate { get; set; }
        public double hoursWorked { get; set; }
        public double totalAmount {  get; set; }
        public string notes { get; set; }

        public string claimStatus = "pending";
        public string documentPath { get; set; }

        public static ReviewClaimsModel GetClaimByID(int CLAIMiD)
        {
            ReviewClaimsModel claim = null;

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT claimID, contractorID, hourlyRate, hoursWorked, totalAmount, notes, claimStatus, document FROM Claim WHERE claimID = @claimID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@claimID", CLAIMiD); // Bind parameter

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claim = new ReviewClaimsModel();
                    claim.claimID = Convert.ToInt32(reader["claimID"]);
                    claim.contractorID = reader["contractorID"].ToString();
                    claim.hourlyRate = Convert.ToDouble(reader["hourlyRate"]);
                    claim.hoursWorked = Convert.ToDouble(reader["hoursWorked"]);
                    claim.notes = reader["notes"].ToString();
                    claim.claimStatus = reader["claimStatus"].ToString();
                    claim.documentPath = reader["document"].ToString();

                }

            }
            return claim;
        }

        public static List<ReviewClaimsModel> Pending_Claims()
        {
            List<ReviewClaimsModel> pendingClaims = new List<ReviewClaimsModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT claimID, contractorID, hourlyRate, hoursWorked, notes, claimStatus, document FROM Claim WHERE claimStatus = 'pending'";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReviewClaimsModel pending = new ReviewClaimsModel();
                    pending.claimID = Convert.ToInt32(reader["claimID"]);
                    pending.contractorID = reader["contractorID"].ToString();
                    pending.hourlyRate = Convert.ToDouble(reader["hourlyRate"]);
                    pending.hoursWorked = Convert.ToDouble(reader["hoursWorked"]);
                    pending.notes = reader["notes"].ToString();
                    pending.claimStatus = reader["claimStatus"].ToString();
                    pending.documentPath = reader["document"].ToString();

                    pendingClaims.Add(pending);
                }

            }
            return pendingClaims;
        }

        public static List<ReviewClaimsModel> Approved_Claims()
        {
            List<ReviewClaimsModel> approved = new List<ReviewClaimsModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT claimID, contractorID, hourlyRate, hoursWorked, notes, claimStatus, document FROM Claim WHERE claimStatus = 'Approved'";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReviewClaimsModel approvedClaim = new ReviewClaimsModel();
                    approvedClaim.claimID = Convert.ToInt32(reader["claimID"]);
                    approvedClaim.contractorID = reader["contractorID"].ToString();
                    approvedClaim.hourlyRate = Convert.ToDouble(reader["hourlyRate"]);
                    approvedClaim.hoursWorked = Convert.ToDouble(reader["hoursWorked"]);
                    approvedClaim.notes = reader["notes"].ToString();
                    approvedClaim.claimStatus = reader["claimStatus"].ToString();
                    approvedClaim.documentPath = reader["document"].ToString();

                    approved.Add(approvedClaim);
                }

            }
            return approved;
        }
        public static List<ReviewClaimsModel> Previous_Claims()
        {
            List<ReviewClaimsModel> claimsHistory = new List<ReviewClaimsModel>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT claimID, contractorID, hourlyRate, hoursWorked, notes, claimStatus, document FROM Claim";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReviewClaimsModel claim = new ReviewClaimsModel();
                    claim.claimID = Convert.ToInt32(reader["claimID"]);
                    claim.contractorID = reader["contractorID"].ToString();
                    claim.hoursWorked = Convert.ToDouble(reader["hoursWorked"]);
                    claim.claimStatus = reader["claimStatus"].ToString();
                    claim.documentPath = reader["document"].ToString();

                    claimsHistory.Add(claim);
                }

            }
            return claimsHistory;
        }
    }
}
