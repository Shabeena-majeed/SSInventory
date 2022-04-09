using SSInventory.Models;
using SSInventory.Models.Shared;
using System.Data.SqlClient;

namespace SSInventory.ViewModels
{
    public class ViewWearhouse
    {

        public List<Wearhouse> GetAllWearhouseData()
        {
            List<Wearhouse> wearhouses = new List<Wearhouse>();

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllWearhouse", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Wearhouse Wearhouses = new Wearhouse();
                        Wearhouses.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                        Wearhouses.varName = Convert.ToString(reader["varName"]);

                        Wearhouses.varDescription = Convert.ToString(reader["varDescription"]);
                        Wearhouses.isActive = Convert.ToBoolean(reader["isActive"]);
                        wearhouses.Add(Wearhouses);
                    }

                }
            }


            return wearhouses;
        }

        public void updateWearhouse(Wearhouse wearhouse)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WearhouseUpdate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", wearhouse.intSeqId);
                    cmd.Parameters.AddWithValue("@varName", wearhouse.varName);
                    cmd.Parameters.AddWithValue("@varDescription", wearhouse.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", wearhouse.isActive);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AddWearhouse(Wearhouse wearhouse)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_wearhouseAdd", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@varName", wearhouse.varName);
                    cmd.Parameters.AddWithValue("@varDescription", wearhouse.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", wearhouse.isActive);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public Wearhouse getWearhouseByid(int intWearhouseid)
        {
            Wearhouse wearhouse = new Wearhouse();
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WearhouseGetById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intWearhouseid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    wearhouse.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                    wearhouse.varName = reader["varName"].ToString();
                    wearhouse.varDescription = reader["varDescription"].ToString();
                    wearhouse.isActive = Convert.ToBoolean(reader["isActive"]);




                }
            }
            return wearhouse;
        }

        public void DeleteWearhouse(int intWearhouseid)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WearhouseDeleteById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intWearhouseid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
