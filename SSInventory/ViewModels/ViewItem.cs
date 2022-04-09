using SSInventory.Models;
using SSInventory.Models.Shared;
using System.Data.SqlClient;

namespace SSInventory.ViewModels
{
    public class ViewItem
    {

        public List<Item> GetAllItemData()
        {
            List<Item> item = new List<Item>();

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllItem", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Item Items = new Item();
                        Items.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                        Items.varName = Convert.ToString(reader["varName"]);

                        Items.varDescription = Convert.ToString(reader["varDescription"]);
                        Items.isActive = Convert.ToBoolean(reader["isActive"]);
                        item.Add(Items);
                    }

                }
            }


            return item;
        }

        public void updateItem(Item item)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ItemUpdate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", item.intSeqId);
                    cmd.Parameters.AddWithValue("@varName", item.varName);
                    cmd.Parameters.AddWithValue("@varDescription", item.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", item.isActive);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AddItem(Item item)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ItemAdd", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@varName", item.varName);
                    cmd.Parameters.AddWithValue("@varDescription", item.varDescription);
                    cmd.Parameters.AddWithValue("@isActive", item.isActive);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public Item getItemByid(int intItemid)
        {
            Item item = new Item();
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ItemGetById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intItemid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    item.intSeqId = Convert.ToInt32(reader["intSeqId"]);
                    item.varName = reader["varName"].ToString();
                    item.varDescription = reader["varDescription"].ToString();
                    item.isActive = Convert.ToBoolean(reader["isActive"]);




                }
            }
            return item;
        }

        public void DeleteItem(int intItemid)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ItemDeleteById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@intSeqId", intItemid);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
