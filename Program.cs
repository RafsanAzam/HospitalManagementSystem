using System;
using System.IO;
using System.Runtime.CompilerServices;
using HospitalManagementSystem.Classes;
using HospitalManagementSystem.Managers;

namespace HospitalManagementSystem
{
    class Program
    {
        private static readonly string credentialsFilePath = "F:\\2023\\Spring - 2023\\.NET Application Development\\Assignment-1\\HospitalManagementSystem\\Data\\credentials.txt"; //path to the file storing user credentials
        static void Main(string[] args)
        {
            AdministratorManagement administratorManagement = new AdministratorManagement();
            DoctorManagement doctorManagement = new DoctorManagement();
            Console.WriteLine("Welcome to the Hospital Management System");

            bool isAuthenticated = false;
            string userRole = null;

            while(!isAuthenticated)
            {
                Console.WriteLine("\nlogin Menu");
                Console.Write("ID: ");
                string userId = Console.ReadLine();

                Console.Write("Enter Password: "); 
                string password = ReadPassword();

                // Validate user credentials and determine their role
                userRole = ValidateCredentials(userId, password);

                if(userRole != null)
                {
                    isAuthenticated = true;
                    Console.WriteLine("\nLogin Successful!");
                }

                else
                {
                    Console.WriteLine("\nInvalid credentials. Please try again.");
                }

            }

            // Navigate to the appropriate menu based on the user's role
            switch (userRole)
            {
             

                case "Doctor":
                    //RunDoctorMenu();
                    break;

                case "Admin":
                    administratorManagement.RunAdministratorMenu();
                    break;

            }


        }

        // *** Function to read password securely ***
        private static string ReadPassword()
        {
            string password = ""; //Initialize an empty string to store the password
            ConsoleKeyInfo key; // declare a variable to store each key press

            do
            {
                key = Console.ReadKey(true); // Read a key from the console without displaying it

                //Check if the key pressed is a printable character or a symbol

                if(char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) )
                {
                    password += key.KeyChar; // Append the character to the password string
                    Console.Write("*"); // Display an asterisk (*) on the screen to mask the character
                }

                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b"); // Erase the last character by moving the cursor back, clearing the character, and moving the cursor back again 
                }

            }

            while (key.Key != ConsoleKey.Enter); // Continue reading keys until the Enter key is pressed

            Console.WriteLine(); // Print a newline to move to the next line after the user presses Enter

            return password; // Return the entered password 
        }

        // *** Function to valiadate user credentials *** 
        private static string ValidateCredentials(string userId,  string password)
        {
            try
            {
                //Read user credentials from the credentials file 
                string[] lines = File.ReadAllLines(credentialsFilePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    // Check if the line has enough parts
                    if (parts.Length == 3)
                    {
                        string storedUserId = parts[0];
                        string storedPassword = parts[1];
                        string userRole = parts[2];

                        // Check if the entered userId and password match the stored credentials
                        if(userId == storedUserId && password == storedPassword)
                        {
                            return userRole; // Return the user's role if credentials are valid 
                        }
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The credentials file '{credentialsFilePath}' was not found.");
            }

            catch (IOException ex)
            {
                Console.WriteLine($"Error reading the credentials file: {ex.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            // Return null if an error occurred or if credentials were not found 
            return null;
        }

        //AdministratorManagement administratorManagement = new AdministratorManagement();
       




    }
}
