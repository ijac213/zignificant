using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Zignificant.ConsoleApp
{
    class Program
    {
        static string connstring = "Data Source=(local);Initial Catalog=zignifikant;User ID=sa;Password=Password1!";

        static void Main(string[] args)
        {
            var action = "";
            while (action != "X" && action != "x")
            {
                Console.Clear();
                Console.WriteLine("Zignificant Birthdays");
                ListBirthdays();
                Console.WriteLine();
                Console.WriteLine("Select Action");
                Console.WriteLine("C - Create Record Information");
                Console.WriteLine("R - Display Record Information");
                Console.WriteLine("U - Update Record Information");
                Console.WriteLine("D - Delete Record Information");
                Console.WriteLine("X - Exit");


                action = Console.ReadLine();
                switch (action)
                {
                    case "c":
                        CreateRecord();
                        break;
                    case "r":
                        DisplayRecord();
                        break;
                    case "u":
                        UpdateRecord();
                        break;
                    case "d":
                        DeleteRecord();
                        break;
                }
            }
        }

        private static void DeleteRecord()
        {
            Console.Write("Provide Record ID: ");
            string recordId = Console.ReadLine();
            using (SqlConnection conn = new SqlConnection(connstring))
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

        private static void UpdateRecord()
        {
            Console.Write("Provide Record ID: ");
            string recordId = Console.ReadLine();
            GetRecordById(recordId);
            Console.Write("Full Name: ");
            var fullname = Console.ReadLine();
            Console.Write("Date of Birth: ");
            var dob = Console.ReadLine();
            Console.Write("Date of Death: ");
            var dod = Console.ReadLine();
            Console.Write("Notoriety: ");
            var notoriety = Console.ReadLine();
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand("Birthdates_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", recordId);
                    cmd.Parameters.AddWithValue("@FulName", fullname);
                    cmd.Parameters.AddWithValue("@Dob", dob);
                    cmd.Parameters.AddWithValue("@Dod", dod);
                    cmd.Parameters.AddWithValue("@Notoriety", notoriety);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        private static void CreateRecord()
        {
            Console.Write("Full Name: ");
            var fullname = Console.ReadLine();
            Console.Write("Date of Birth: ");
            var dob = Console.ReadLine();
            Console.Write("Date of Death: ");
            var dod = Console.ReadLine();
            Console.Write("Notoriety: ");
            var notoriety = Console.ReadLine();
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand("BirthDates_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FulName", fullname);
                    cmd.Parameters.AddWithValue("@Dob", dob);
                    cmd.Parameters.AddWithValue("@Dod", dod);
                    cmd.Parameters.AddWithValue("@Notoriety", notoriety);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private static void DisplayRecord()
        {
            Console.Write("Provide Record ID: ");
            string recordId = Console.ReadLine();
            GetRecordById(recordId);
            Thread.Sleep(5000);
        }

        private static void GetRecordById(string recordId)
        {
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand("BirthDates_SelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", recordId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        string fullname = reader.GetString("FulName");
                        DateTime dob = reader.GetDateTime("Dob");
                        DateTime? dod = null;
                        if (!reader.IsDBNull("Dod"))
                        {
                            dod = reader.GetDateTime("Dod");
                        }
                        string notoriety = reader.GetString("Notoriety");
                        DateTime createdat = reader.GetDateTime("CreatedAt");
                        DateTime updatedat = reader.GetDateTime("UpdatedAt");

                        Console.WriteLine($"Id: {id}");
                        Console.WriteLine($"Name: {fullname}");
                        Console.WriteLine($"DOB: {dob}");
                        Console.WriteLine($"DOD: {dod}");
                        Console.WriteLine($"Notoriety: {notoriety}");
                        Console.WriteLine($"Created At: {createdat}");
                        Console.WriteLine($"Updated At: {updatedat}");
                    }
                    conn.Close();
                }
            }
        }

        private static void ListBirthdays()
        {
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand("BirthDates_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        string fullname = reader.GetString("FulName");
                        DateTime dob = reader.GetDateTime("Dob");
                        DateTime? dod = null;
                        if (!reader.IsDBNull("Dod"))
                        {
                            dod = reader.GetDateTime("Dod");
                        }
                        string notoriety = reader.GetString("Notoriety");
                        DateTime createdat = reader.GetDateTime("CreatedAt");
                        DateTime updatedat = reader.GetDateTime("UpdatedAt");

                        Console.WriteLine($"{id} {fullname}");
                    }
                    conn.Close();
                }
            }
        }
    }
}
