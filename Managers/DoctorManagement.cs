using HospitalManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagementSystem.Managers
{
    public class DoctorManagement
    {
        private List<Doctor> doctors;
        private string doctorsFilePath = "doctors.txt"; //text file for storing doctor data

        public DoctorManagement()
        {
            doctors = new List<Doctor>();
        }

        // *** Function for adding new doctor ***

        public void AddDoctor(Doctor doctor)
        {
            doctor.Id = GenerateUniqueDoctorId();


            doctors.Add(doctor);  //add doctor to the list

            SaveDoctorsToFile(); //Save the updated list to the file

            Console.WriteLine("Doctor added successfully!");
        }

        // *** Fuction to list all doctors ***
        public void ListDoctors()
        {
            foreach( Doctor doctor in doctors)
            {
                Console.WriteLine(doctor.ToString());
            }
        }

        // *** Function to list details of a specific doctor by ID ***

        public void ListDoctorDetails(int doctorId)
        {
            var doctor = doctors.Find(d => d.Id == doctorId);

            if(doctor != null)
            {
                Console.WriteLine(doctor.ToString());
            }
            else
            {
                Console.WriteLine("Doctor not found!");
            }
        }

        // *** Function to generate a unique doctor ID ***
        private int GenerateUniqueDoctorId()
        {
            //Find the maximum existing doctor ID and add 1
            int maxId = 0;
            foreach (var doctor in doctors)
            {
                if (doctor.Id > maxId)
                { 
                    maxId = doctor.Id;
                }

            }
            return maxId + 1;
        }

        private void LoadDoctorsFromFile()
        {
            if(File.Exists(doctorsFilePath))
            {
                // Read the file and create doctor objects
                string[] lines = File.ReadAllLines(doctorsFilePath);
                foreach (string line in lines)
                {
                    //Split the line into fields (assuming fields are separated by a delimiter like a comma)
                    string[] fields = line.Split(',');

                    // Check if there are enough fields to create a Doctor object
                    if(fields.Length >= 9)
                    {
                        try
                        {
                            //Parse the fields & create a new Doctor object
                            string firstName = fields[0].Trim();
                            string lastName = fields[1].Trim();
                            string email = fields[2].Trim();
                            int phone = int.Parse(fields[3].Trim());
                            int streetNumber = int.Parse(fields[4].Trim());
                            int streetName = int.Parse(fields[5].Trim());
                            string city = fields[6].Trim();
                            string state = fields[7].Trim();
                            int id = int.Parse(fields[8].Trim());

                            //Create a new doctor object
                            Doctor doctor = new Doctor(id, firstName, lastName, email, phone, streetNumber, streetName, city, state);

                            //add the doctor to the list

                            doctors.Add(doctor);
                        }

                        catch (FormatException ex)
                        {
                            // handle the format exception if parsing fails for any field
                            Console.WriteLine($"Error parsing doctor data: {ex.Message}");
                        }


                    }

                }
            }
        }

        // *** Function to save doctors to the text file ***

        private void SaveDoctorsToFile()
        {
            //Convert the list of doctors to a  list of strings 
            List<string> doctorStrings = new List<string>();
            foreach (var doctor in doctors)
            {
                doctorStrings.Add(doctor.ToString());
            }

            //Write the list of strings to the file
            File.WriteAllLines(doctorsFilePath, doctorStrings);

        }


    }
}
