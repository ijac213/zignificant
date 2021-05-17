using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;
using Zignificant.Repository;

namespace Zignificant.ConsoleApp
{
    class Program
    {
        static string connstring = "Data Source=(local);Initial Catalog=zignifikant;User ID=sa;Password=Password1!";

        static BirthdateRepository _repo = new BirthdateRepository();

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
            int recordId = int.Parse(Console.ReadLine());
            _repo.Delete(recordId);
        }

        private static void UpdateRecord()
        {
            BirthdateUpdateRequest req = new BirthdateUpdateRequest();
            Console.Write("Provide Record ID: ");
            req.Id = int.Parse(Console.ReadLine());
            BirthdateResponse res = _repo.GetRecordById(req.Id);
            Console.Write($"Full Name({res.FullName}): ");
            req.FullName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(req.FullName))
            {
                req.FullName = res.FullName;
            }
            Console.Write($"Date of Birth({res.Dob}): ");
            if (DateTime.TryParse(Console.ReadLine(), out var dob))
            {
                req.Dob = dob;
            }
            else
            {
                req.Dob = res.Dob;
            }
            Console.Write($"Date of Death({res.Dod}): ");
            if (DateTime.TryParse(Console.ReadLine(), out var dod))
            {
                req.Dod = dod;
            }
            else
            {
                req.Dod = res.Dod;
            }
            Console.Write($"Notoriety({res.Notoriety}): ");
            req.Notoriety = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(req.Notoriety))
            {
                req.Notoriety = res.Notoriety;
            }
            _repo.Update(req);
        }

        private static void CreateRecord()
        {
            BirthdateCreateRequest req = new BirthdateCreateRequest();
            Console.Write("Full Name: ");
            req.FullName = Console.ReadLine();
            Console.Write("Date of Birth: ");
            req.Dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Date of Death: ");
            if (DateTime.TryParse(Console.ReadLine(), out var dod))
            {
                req.Dod = dod;
            } 
            Console.Write("Notoriety: ");
            req.Notoriety = Console.ReadLine();
            _repo.Create(req);
        }

        private static void DisplayRecord()
        {
            Console.Write("Provide Record ID: ");
            int recordId = int.Parse(Console.ReadLine());
            GetRecordById(recordId);
            Thread.Sleep(5000);
        }

        private static void GetRecordById(int recordId)
        {
            BirthdateResponse res = _repo.GetRecordById(recordId);
            Console.WriteLine($"Id: {res.Id}");
            Console.WriteLine($"Name: {res.FullName}");
            Console.WriteLine($"DOB: {res.Dob}");
            Console.WriteLine($"DOD: {res.Dod}");
            Console.WriteLine($"Notoriety: {res.Notoriety}");
            Console.WriteLine($"Created At: {res.CreatedAt}");
            Console.WriteLine($"Updated At: {res.UpdatedAt}");
        }

        private static void ListBirthdays()
        {
            List<BirthdateResponse> res = _repo.GetAll();
            foreach (var item in res)
            {
                Console.WriteLine($"{item.Id} - {item.FullName}");
            }
        }
    }
}
