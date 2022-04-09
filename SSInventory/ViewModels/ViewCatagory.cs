using System.Data.SqlClient;
using SSInventory.Models;
using SSInventory.Models.Shared;

namespace SSInventory.ViewModels
{
    public class ViewCatagory
    {


        public List<Catagory> GetAllCatagoryData()
        {
            List<Catagory> catagory = new List<Catagory>();

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllCatagorys", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Catagory catagorys = new Catagory();
                        catagorys.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                        catagorys.varName = Convert.ToString(reader["varName"]);

                        catagorys.varDescription = Convert.ToString(reader["varDescription"]);
                        catagorys.isActive = Convert.ToBoolean(reader["isActive"]);
                        catagory.Add(catagorys);
                    }

                }
            }


            return catagory;
        }

        public void updateCatagory(Catagory catagory)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CatagoryUpdate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", catagory.intSeqId);
                    cmd.Parameters.AddWithValue("@varName", catagory.varName);
                    cmd.Parameters.AddWithValue("@varDescription", catagory.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", catagory.isActive);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AddCatagory(Catagory catagory)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CatagoryAdd", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@varName", catagory.varName);
                    cmd.Parameters.AddWithValue("@varDescription", catagory.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", catagory.isActive);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public Catagory getCatagoryByid(int intCatagoryid)
        {
            Catagory catagory = new Catagory();
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CatagoryGetById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intCatagoryid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    catagory.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                    catagory.varName = reader["varName"].ToString();
                    catagory.varDescription = reader["varDescription"].ToString();
                    catagory.isActive = Convert.ToBoolean(reader["isActive"]);




                }
            }
            return catagory;
        }

        public void DeletCatagory(int intCatagoryid)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CatagoryDeleteById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intCatagoryid);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
