using SSInventory.Models;
using SSInventory.Models.Shared;
using System.Data.SqlClient;

namespace SSInventory.ViewModels
{
    public class ViewUnit
    {
        public List<Unit> GetAllUnitData()
        {
            List<Unit> unit = new List<Unit>();

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllUnit", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Unit Unit1 = new Unit();
                        Unit1.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                        Unit1.varName = Convert.ToString(reader["varName"]);

                        Unit1.varDescription = Convert.ToString(reader["varDescription"]);
                        Unit1.isActive = Convert.ToBoolean(reader["isActive"]);
                        unit.Add(Unit1);
                    }

                }
            }


            return unit;
        }

        public void updateUnit(Unit unit)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UnitUpdate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", unit.intSeqId);
                    cmd.Parameters.AddWithValue("@varName", unit.varName);
                    cmd.Parameters.AddWithValue("@varDescription", unit.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", unit.isActive);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AddUnit(Unit unit)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UnitAdd", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@varName", unit.varName);
                    cmd.Parameters.AddWithValue("@varDescription", unit.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", unit.isActive);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public Unit getUnitByid(int intUnitid)
        {
            Unit unit = new Unit();
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UnitGetById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intUnitid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    unit.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                    unit.varName = reader["varName"].ToString();
                    unit.varDescription = reader["varDescription"].ToString();
                    unit.isActive = Convert.ToBoolean(reader["isActive"]);




                }
            }
            return unit;
        }

        public void DeleteUnit(int intUnitid)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UnitDeleteById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intUnitid);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
