using SSInventory.Models;
using SSInventory.Models.Shared;
using System.Data.SqlClient;

namespace SSInventory.ViewModels
{
    public class ViewParty
    {

        public List<Party> GetAllPartyData()
        {
            List<Party> party = new List<Party>();

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllParty", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Party Party1 = new Party();
                        Party1.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                        Party1.varName = Convert.ToString(reader["varName"]);

                        Party1.varDescription = Convert.ToString(reader["varDescription"]);
                        Party1.isActive = Convert.ToBoolean(reader["isActive"]);
                        party.Add(Party1);
                    }

                }
            }


            return party;
        }

        public void updateParty(Party party)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_PartyUpdate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", party.intSeqId);
                    cmd.Parameters.AddWithValue("@varName", party.varName);
                    cmd.Parameters.AddWithValue("@varDescription", party.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", party.isActive);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AddParty(Party party)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_PartyAdd", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@varName", party.varName);
                    cmd.Parameters.AddWithValue("@varDescription", party.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", party.isActive);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public Party getPartyByid(int intPartyid)
        {
            Party party = new Party();
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_PartyGetById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intPartyid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    party.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                    party.varName = reader["varName"].ToString();
                    party.varDescription = reader["varDescription"].ToString();
                    party.isActive = Convert.ToBoolean(reader["isActive"]);




                }
            }
            return party;
        }

        public void DeleteParty(int intPartyid)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_PartyDeleteById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intPartyid);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
