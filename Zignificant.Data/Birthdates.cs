using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;

namespace Zignificant.Data
{
    public class Birthdates : IBirthdates
    {
        private string ConnString;

        public void Delete(int recordId)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("Birthdates_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", recordId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(BirthdateUpdateRequest req)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("Birthdates_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", req.Id);
                    cmd.Parameters.AddWithValue("@FulName", req.FullName);
                    cmd.Parameters.AddWithValue("@Dob", req.Dob);
                    cmd.Parameters.AddWithValue("@Dod", req.Dod);
                    cmd.Parameters.AddWithValue("@Notoriety", req.Notoriety);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public int Create(BirthdateCreateRequest req)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("BirthDates_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
                    p.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p);
                    cmd.Parameters.AddWithValue("@FulName", req.FullName);
                    cmd.Parameters.AddWithValue("@Dob", req.Dob);
                    cmd.Parameters.AddWithValue("@Dod", req.Dod);
                    cmd.Parameters.AddWithValue("@Notoriety", req.Notoriety);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.Parameters["@Id"].Value;
                    conn.Close();
                }
            }
            return result;
        }

        public BirthdateResponse GetRecordById(int recordId)
        {
            BirthdateResponse resp = new BirthdateResponse();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("BirthDates_SelectById", conn))
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

        public List<BirthdateResponse> GetAll()
        {
            List<BirthdateResponse> resp = new List<BirthdateResponse>();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("BirthDates_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BirthdateResponse br = Mapper(reader);
                        resp.Add(br);
                    }
                    conn.Close();
                }
            }
            return resp;
        }

        private static BirthdateResponse Mapper(SqlDataReader reader)
        {
            BirthdateResponse br = new BirthdateResponse();
            br.Id = reader.GetInt32("Id");
            br.FullName = reader.GetString("FulName");
            br.Dob = reader.GetDateTime("Dob");
            if (!reader.IsDBNull("Dod"))
            {
                br.Dod = reader.GetDateTime("Dod");
            }
            br.Notoriety = reader.GetString("Notoriety");
            br.CreatedAt = reader.GetDateTime("CreatedAt");
            br.UpdatedAt = reader.GetDateTime("UpdatedAt");
            return br;
        }

        public Birthdates(string connString)
        {
            ConnString = connString;
        }
    }
}
