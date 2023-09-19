using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace HospitalManagementSystem
{
    class Program
    {
        private static readonly string credentialsFilePath = "data/credentials.txt"; //path to the file storing user credentials
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hospital Management System");

            bool isAuthenticated = false;
            string userRole = null;

            while(!isAuthenticated)
            {
                Console.WriteLine("\nlogin Menu");
                Console.Write("ID: ");
                string userId = Console.ReadLine();

                Console.Write("Enter Password: ");
                //string password = ReadPassword();

                

            }


        }

        private static string ReadPassword()
        {
            string password = " "; //Initialize an empty string to store the password
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
    }
}
