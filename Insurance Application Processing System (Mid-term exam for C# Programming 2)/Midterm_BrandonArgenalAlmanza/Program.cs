using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Midterm_BrandonArgenalAlmanza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestInsurance();
        }
        static void TestInsurance()
        {
            Console.WriteLine($"{new string('-', 34)}Insurance Application{new string('-', 35)}");
            InsuranceOfficer officer1 = new InsuranceOfficer(729);
            officer1.ApplicantList.Add(new Applicant(546, "Alex Du", 19, true, false));
            officer1.ShowAll();
            officer1.AddApplicant(921, "Dolly Lively", 27, false, false);

            officer1.ShowAll();
            officer1.ShowAll(true);
            InsuranceOfficer officer2 = new InsuranceOfficer(498);
            officer2.ApplicantList.Add(new Applicant(576, "Dale", 45, false, true));
            officer2.ShowAll();
            officer2.AddApplicant(847, "Jack Gibbs", 18, false, false);
            officer2.ShowAll();
            officer2.ShowAll(false);
            Console.WriteLine($"{new string('-', 90)}");

        }
    }

    class Applicant
    {
        public int driverID { get; }
        public string name { get; }
        public int age { get; }
        public bool speedingTicket { get; }
        public bool drivingTest { get; }
        public bool eligible { get; set; }

        public double insuranceAmount { get; set; }

        public Applicant(int ID, string name, int age, bool ticket = false, bool test = false)
        {
            this.driverID = ID;
            this.name = name;
            this.age = age;
            this.speedingTicket = ticket;
            this.drivingTest = test;

            FindEligibility();

        }

        public void FindEligibility()
        {
            if (age >= 25)
            {
                if (speedingTicket == true && eligible == true)
                {
                    insuranceAmount = 1000;
                }
                if (speedingTicket == false && eligible == true)
                {
                    insuranceAmount = 500;
                }
            }
            if (age < 25)
            {
                if (speedingTicket == true && drivingTest == true && eligible == true)
                {
                    insuranceAmount = 1500;
                }
                if (speedingTicket == false && drivingTest == true && eligible == true)
                {
                    insuranceAmount = 1000;
                }
            }
            else
            {
                eligible = false;
                insuranceAmount = 0.0;
            }
        }

        public override string ToString()
        {
            return $"Driver ID: {this.driverID} Name: {this.name} Age: {this.age} Speeding Ticket: {this.speedingTicket} Driving Test: {this.drivingTest} Eligible: {this.eligible} Insurance Amount: {this.insuranceAmount:c}";
        }
    }

    class InsuranceOfficer
    {
        public int ID { get; }
        public List<Applicant> ApplicantList { get; }

        private string FileName = "Officer_Applicant.txt";

        public InsuranceOfficer(int ID)
        {
            this.ID = ID;
            ApplicantList = new List<Applicant>();

            try
            {
                using (StreamReader read = new StreamReader(FileName))
                {
                    string dataLine;

                    while ((dataLine = read.ReadLine()) != null)
                    {
                        string[] value = dataLine.Split(',');

                        if (value[0] == this.ID.ToString())
                        {
                            int driverID = Convert.ToInt32(value[1]);
                            string name = value[2];
                            int age = Convert.ToInt32(value[3]);
                            bool speedingTicket = Convert.ToBoolean(value[4]);
                            bool drivingTest = Convert.ToBoolean(value[5]);

                            Applicant NewApplicant = new Applicant(driverID, name, age, speedingTicket, drivingTest);

                            ApplicantList.Add(NewApplicant);
                        }

                    }
                    read.Close();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.Write("File is not found. Check your directory or file name");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddApplicant(int ID, string name, int age, bool ticket = false, bool test = false)
        {
            Applicant newApplicant = new Applicant(ID, name, age, ticket, test);

            ApplicantList.Add(newApplicant);

            Console.WriteLine("\nNew Applicant has been added:");
        }

        public void ShowAll()
        {
            Console.WriteLine($"All Applicants for Officer ID {ID}:");
            foreach (var applicant in ApplicantList)
            {
                Console.WriteLine(applicant.ToString());
            }
        }

        public void ShowAll(bool eligibilityStatus)
        {
            Console.WriteLine($"\nApplicants for Officer ID {ID} with Eligibility Status {eligibilityStatus}:");
            foreach (var applicant in ApplicantList)
            {
                if (applicant.eligible == eligibilityStatus)
                {
                    Console.WriteLine(applicant.ToString());
                }
            }
        }
    }
}
