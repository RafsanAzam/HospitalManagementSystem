using System;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DOTNET Hospital Management System");
            Console.WriteLine("Welcome, Jack Doctorson!\n");

            while (true)
            {
                Console.Clear(); // Clear the console to display new data.
                Console.WriteLine("Doctor Menu");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. List doctor details");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. List appointments");
                Console.WriteLine("4. Check particular patient");
                Console.WriteLine("5. List appointments with patient");
                Console.WriteLine("6. Logout");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice (1-7): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Doctor Details");
                        // Add your code to list doctor details here.
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("List of Patients");
                        // Add your code to list patients here.
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("List of Appointments");
                        // Add your code to list appointments here.
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Check Particular Patient");
                        // Add your code to check a particular patient here.
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("List Appointments with a Patient");
                        // Add your code to list appointments with a patient here.
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("Logging out...");
                        // Add your code for logging out here.
                        return; // Exit the program after logging out.
                    case "7":
                        Console.WriteLine("Exiting...");
                        return; // Exit the program.
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-7).");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
