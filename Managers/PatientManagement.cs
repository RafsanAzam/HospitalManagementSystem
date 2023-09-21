using HospitalManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagementSystem.Managers
{
    public class PatientManagement
    {
        private List<Patient> patients;
        private string patientsFilePath = "F:\\2023\\Spring - 2023\\.NET Application Development\\Assignment-1\\HospitalManagementSystem\\Data\\patientList.txt"; //text file for storing doctor data

        public PatientManagement()
        {
            patients = new List<Patient>();
        }

        // *** Function for adding new patient ***

        public void AddPatient(Patient patient)
        {
            patient.Id = GenerateUniquePatientId();


            patients.Add(patient);  //add patient to the list

            SavePatientsToFile(); //Save the updated list to the file

            Console.WriteLine("Patient added successfully!");
        }

        // *** Fuction to list all patients ***
        public void ListPatients()
        {
            foreach (Patient patient in patients)
            {
                Console.WriteLine(patient.ToString());
            }
        }

        // *** Function to list details of a specific patient by ID ***

        public void ListPatientDetails(int patientId)
        {
            var patient = patients.Find(p => p.Id == patientId);

            if (patient != null)
            {
                Console.WriteLine(patient.ToString());
            }
            else
            {
                Console.WriteLine("Patient not found!");
            }
        }

        // *** Function to generate a unique patient ID ***
        private int GenerateUniquePatientId()
        {
            //Find the maximum existing patient ID and add 1
            int maxId = 0;
            foreach (var patient in patients)
            {
                if (patient.Id > maxId)
                {
                    maxId = patient.Id;
                }

            }
            return maxId + 1;
        }

        private void LoadPatientsFromFile()
        {
            if (File.Exists(patientsFilePath))
            {
                // Read the file and create doctor objects
                string[] lines = File.ReadAllLines(patientsFilePath);
                foreach (string line in lines)
                {
                    //Split the line into fields (assuming fields are separated by a delimiter like a comma)
                    string[] fields = line.Split(',');

                    // Check if there are enough fields to create a Doctor object
                    if (fields.Length >= 9)
                    {
                        try
                        {
                            //Parse the fields & create a new Doctor object
                            int id = int.Parse(fields[0].Trim());
                            string Name = fields[1].Trim();
                            string address = fields[2].Trim();
                            string email = fields[3].Trim();
                            int phone = int.Parse(fields[4].Trim());
                            
                            

                            //Create a new patient object
                            Patient patient = new Patient(id, Name, address, email, phone);

                            //add the doctor to the list

                            patients.Add(patient);
                        }

                        catch (FormatException ex)
                        {
                            // handle the format exception if parsing fails for any field
                            Console.WriteLine($"Error parsing patient data: {ex.Message}");
                        }


                    }

                }
            }
        }

        // *** Function to save doctors to the text file ***

        private void SavePatientsToFile()
        {
            //Convert the list of patients to a  list of strings 
            List<string> patientStrings = new List<string>();
            foreach (var patient in patients)
            {
                patientStrings.Add(patient.ToString());
            }

            //Write the list of strings to the file
            File.WriteAllLines(patientsFilePath, patientStrings);

        }


        public static void RunPatientMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nDoctor Menu");
                Console.WriteLine("1. View Patient List");
                Console.WriteLine("2. View Appointments");
                Console.WriteLine("3. Update Patient Records");
                Console.WriteLine("4. Logout");

                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Viewing patient list...");
                        // Implement logic for viewing the patient list
                        break;
                    case "2":
                        Console.WriteLine("Viewing appointments...");
                        // Implement logic for viewing appointments
                        break;
                    case "3":
                        Console.WriteLine("Updating patient records...");
                        // Implement logic for updating patient records
                        break;
                    case "4":
                        running = false; // Exit the doctor menu
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }




    }
}
