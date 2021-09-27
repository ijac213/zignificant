using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;

namespace Zignificant.Data
{
    public class History : IHistory
    {
        private string ConnString;

        public void Delete(int recordId)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("TechHistory_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", recordId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(HistoryUpdateRequest req)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("TechHistory_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", req.Id);
                    cmd.Parameters.AddWithValue("@Date", req.Date);
                    cmd.Parameters.AddWithValue("@Title", req.Title);
                    cmd.Parameters.AddWithValue("@Description", req.Description);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public int Create(HistoryCreateRequest req)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(ConnString))
            { 
                using (SqlCommand cmd = new SqlCommand("TechHistory_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
                    p.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p);
                    cmd.Parameters.AddWithValue("@Date", req.Date);
                    cmd.Parameters.AddWithValue("@Title", req.Title);
                    cmd.Parameters.AddWithValue("@Description", req.Description);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.Parameters["@Id"].Value;
                    conn.Close();
                }
            }
            return result;
        }

        public HistoryResponse GetRecordById(int recordId)
        {
            HistoryResponse resp = new HistoryResponse();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using(SqlCommand cmd = new SqlCommand("TechHistory_SelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", recordId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        resp = Mapper(reader);
                    }
                    conn.Close();
                }
            }       
            return resp;
        }

        public List<HistoryResponse> GetAll()
        {
            List<HistoryResponse> resp = new List<HistoryResponse>();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("TechHistory_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        HistoryResponse br = Mapper(reader);
                        resp.Add(br);
                    }
                    conn.Close();
                }
            }
            return resp;
        }

        private static HistoryResponse Mapper(SqlDataReader reader)
        {
            HistoryResponse br = new HistoryResponse();
            br.Id = reader.GetInt32("Id");
            br.Date = reader.GetDateTime("Date");
            br.Title = reader.GetString("Title");
            br.Description = reader.GetString("Description");
            return br;
        }

        public History(string connString)
        {
            ConnString = connString;
        }
    }
}
