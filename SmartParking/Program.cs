using System;
using System.Diagnostics;
using smartparking;
using SmartParking;
using System.Diagnostics;


namespace SmartParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("=============================================");
            Console.WriteLine("            Welcome to Smart Parking         ");
            Console.WriteLine("=============================================");
            Console.WriteLine("=============================================");
            Console.WriteLine("");

            // Initialize the parking system
            ParkingSlotDoublyLinkedList parkingSystem = new ParkingSlotDoublyLinkedList();

            // Adding parking slots for demonstration
            AddSampleSlots(parkingSystem);

            // Sort slots based on distance
            // parkingSystem.SortSlots();

            while (true)
            {
                DisplayMainMenu();
                int choice = GetValidChoice(1, 3);  // Ensure valid input for main menu choice

                if (choice == 1)
                {
                    UserSection(parkingSystem);
                }
                else if (choice == 2)
                {
                    AdminSection(parkingSystem);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Exiting... Thank you for using Smart Parking!");
                    break;
                }
            }
        }

        // Function to handle Admin Login (password check)
        static bool AdminLogin()
        {
            string correctPassword = "123"; // Set your admin password here
            Console.Write("Enter Admin Password: ");
            string inputPassword = Console.ReadLine();
            Console.WriteLine("");
            return inputPassword == correctPassword;
        }

        // Display the main menu for the user
        static void DisplayMainMenu()
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine("        Main Menu - Choose an Option         ");
            Console.WriteLine("=============================================");
            Console.WriteLine(" 1. User Section");
            Console.WriteLine(" 2. Admin Section");
            Console.WriteLine(" 3. Exit");
            Console.WriteLine("");
            Console.WriteLine("=============================================");
        }

        // Get a valid choice from the user
        static int GetValidChoice(int min, int max)
        {
            int choice = 0;
            bool validChoice = false;

            // Loop to handle invalid choice and repeat until a valid one is entered
            do
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();
                validChoice = int.TryParse(input, out choice);

                if (!validChoice || choice < min || choice > max)
                {
                    Console.WriteLine($"Invalid choice. Please enter a number between {min} and {max}.");
                }
            } while (!validChoice || choice < min || choice > max);

            return choice;
        }

        // Add sample parking slots for demonstration
        static void AddSampleSlots(ParkingSlotDoublyLinkedList parkingSystem)
        {
            parkingSystem.AddSlot(1, 13.5);
            parkingSystem.AddSlot(2, 4.2);
            parkingSystem.AddSlot(3, 5.0);
            parkingSystem.AddSlot(11, 11.3);
            parkingSystem.AddSlot(12, 12.7);
            parkingSystem.AddSlot(13, 13.5);
            parkingSystem.AddSlot(14, 14.1);
            parkingSystem.AddSlot(15, 15.0);
            parkingSystem.AddSlot(16, 17.8);
            parkingSystem.AddSlot(17, 17.2);
            parkingSystem.AddSlot(18, 18.5);
            parkingSystem.AddSlot(19, 19.7);
            parkingSystem.AddSlot(20, 20.0);
            parkingSystem.AddSlot(21, 21.9);
            parkingSystem.AddSlot(22, 22.5);
            parkingSystem.AddSlot(23, 23.8);
            parkingSystem.AddSlot(24, 24.6);
            parkingSystem.AddSlot(25, 15.0);
            parkingSystem.AddSlot(4, 5.8);
            parkingSystem.AddSlot(5, 6.4);
            parkingSystem.AddSlot(6, 21.1);
            parkingSystem.AddSlot(7, 7.9);
            parkingSystem.AddSlot(8, 8.5);
            parkingSystem.AddSlot(9, 19.2);
            parkingSystem.AddSlot(10, 10.0);
        }

        // User section - Allows the user to view available slots and make bookings
        static void UserSection(ParkingSlotDoublyLinkedList parkingSystem)
        {
            while (true) // Infinite loop to keep the User Section running
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("            Welcome to the User Section       ");
                Console.WriteLine("=============================================");
                Console.WriteLine(" 1. Sort");
                Console.WriteLine(" 2. Booking");
                Console.WriteLine(" 3. Back");
                Console.WriteLine("=============================================");

                int choice = GetValidChoice(1, 3);

                switch (choice)
                {
                    case 1:
                        // View all available slots
                        parkingSystem.UserDisplaySlots();
                        break;

                    case 2:
                        Console.Write("Enter Slot ID: ");
                        int SlotID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter User Name: ");
                        string UserName = Console.ReadLine();
                        Console.Write("Enter Vehicle No: ");
                        string VehicleNo = Console.ReadLine();
                        Console.Write("Enter Parking Duration: ");
                        double Duration = Convert.ToDouble(Console.ReadLine());
                        parkingSystem.BookingSlot(SlotID, UserName, VehicleNo, Duration);
                        break;

                    case 3:
                        // Exit the User Section loop and return to the main menu
                        Console.WriteLine("\nReturning to Main Menu...");
                        return; // Exits the function, breaking out of the loop

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Optional: Pause before showing the menu again
                //Console.WriteLine("\nPress Enter to continue...");
                //Console.ReadLine();
            }
        }


        // Admin section - Allows the admin to manage parking slots
        static void AdminSection(ParkingSlotDoublyLinkedList parkingSystem)
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine("         Admin Section - Smart Parking       ");
            Console.WriteLine("=============================================");

            if (!AdminLogin())
            {
                Console.WriteLine("Incorrect password. Returning to main menu...\n");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("          Admin Menu - Choose an Action      ");
                Console.WriteLine("=============================================");
                Console.WriteLine(" 1. View Slots");
                Console.WriteLine(" 2. Add Slot");
                Console.WriteLine(" 3. Remove Slot");
                Console.WriteLine(" 4. Edit Slot");
                Console.WriteLine(" 5. Back to Main Menu");
                Console.WriteLine("=============================================");

                int choice = GetValidChoice(1, 5);

                switch (choice)
                {
                    case 1:
                        // View all slots
                        Console.WriteLine("Total Slots: " + parkingSystem.GetTotalSlots());
                        Console.WriteLine("Available Slots: " + parkingSystem.GetAvailableSlotsCount());
                        Console.WriteLine("Booked Slots: " + parkingSystem.GetBookedSlotsCount());
                        parkingSystem.DisplaySlots();
                        ShowSortingMethodOptions(parkingSystem);
                        break;

                    case 2:
                        // Add a new slot
                        Console.Write("Enter Slot ID: ");
                        int slotID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Distance: ");
                        double distance = Convert.ToDouble(Console.ReadLine());
                        parkingSystem.AddSlot(slotID, distance);
                        Console.WriteLine("");
                        Console.WriteLine(" New slot added successfully");
                        Console.WriteLine("");
                        break;

                    case 3:
                        // Remove a slot
                        Console.WriteLine("Slots ID's:");
                        parkingSystem.ShowSlots();
                        Console.Write("Enter Slot ID to remove: ");
                        int removeSlotID = Convert.ToInt32(Console.ReadLine());
                        parkingSystem.RemoveSlot(removeSlotID);
                        break;

                    case 4:
                        // Edit a slot
                        Console.Write("Enter Slot ID to edit: ");
                        int editID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new Distance: ");
                        double editDistance = Convert.ToDouble(Console.ReadLine());
                        parkingSystem.EditSlot(editID, editDistance);
                        break;

                    case 5:
                        // Go back to main menu
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Returning to Admin Menu...");
                        break;
                }
            }
        }

        // Show sorting options for selecting the sorting method (Quick Sort, Merge Sort, Bubble Sort)
        static void ShowSortingMethodOptions(ParkingSlotDoublyLinkedList parkingSystem)
        {
            while (true) // Infinite loop to keep the sorting method menu running
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("                Choose Sorting Method        ");
                Console.WriteLine("=============================================");
                Console.WriteLine(" 1. Merge Sort");
                Console.WriteLine(" 2. Quick Sort");
                Console.WriteLine(" 3. Bubble Sort");
                Console.WriteLine(" 4. Back");
                Console.WriteLine("=============================================");

                int sortMethodChoice = GetValidChoice(1, 4);

                switch (sortMethodChoice)
                {
                    case 1:
                        // Merge Sort selected
                        ShowMergeSortOptions(parkingSystem);
                        Console.WriteLine("\nMerge Sort completed.");
                        break;

                    case 2:
                        // Quick Sort selected
                        ShowQuickSortOptions(parkingSystem);
                        Console.WriteLine("\nQuick Sort completed.");
                        break;

                    case 3:
                        // Bubble Sort selected
                        ShowBubbleSortOptions(parkingSystem);
                        Console.WriteLine("\nBubble Sort completed.");
                        break;

                    case 4:
                        // Return to Admin Menu
                        Console.WriteLine("\nReturning to Admin Menu...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Optional: Pause before showing the menu again
                //Console.WriteLine("\nPress Enter to continue...");
                //Console.ReadLine();
            }
        }

        // Show merge sort options for sorting slots
        static void ShowMergeSortOptions(ParkingSlotDoublyLinkedList parkingSystem)
        {
            while (true) // Loop to keep the sorting options active
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("                  Merge Sort                 ");
                Console.WriteLine("=============================================");
                Console.WriteLine(" 1. Sort By ID");
                Console.WriteLine(" 2. Sort By Distance");
                Console.WriteLine(" 3. Sort By Price");
                Console.WriteLine(" 4. Back");
                Console.WriteLine("=============================================");

                int mergeSortChoice = GetValidChoice(1, 4);

                Stopwatch stopwatch = new Stopwatch(); // Instantiate the Stopwatch here

                switch (mergeSortChoice)
                {
                    case 1:
                        // Measure time taken by Merge Sort By ID
                        stopwatch.Start();
                        parkingSystem.MergeSortSlot_ById();
                        stopwatch.Stop();
                        Console.WriteLine($"\nMerge Sort (By ID) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 2:
                        // Measure time taken by Merge Sort By Distance
                        stopwatch.Start();
                        parkingSystem.MergeSortSlot_ByDistance();
                        stopwatch.Stop();
                        Console.WriteLine($"\nMerge Sort (By Distance) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 3:
                        // Measure time taken by Merge Sort By Price
                        stopwatch.Start();
                        parkingSystem.MergeSortSlot_ByPrice();
                        stopwatch.Stop();
                        Console.WriteLine($"\nMerge Sort (By Price) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 4:
                        // Return to Admin Menu
                        Console.WriteLine("\nReturning to Admin Menu...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Optional: Pause before showing the menu again
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        // Show quick sort options for sorting slots
        static void ShowQuickSortOptions(ParkingSlotDoublyLinkedList parkingSystem)
        {
            while (true) // Loop to keep the sorting options active
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("                  Quick Sort                 ");
                Console.WriteLine("=============================================");
                Console.WriteLine(" 1. Sort By ID");
                Console.WriteLine(" 2. Sort By Distance");
                Console.WriteLine(" 3. Sort By Price");
                Console.WriteLine(" 4. Back");
                Console.WriteLine("=============================================");

                int quickSortChoice = GetValidChoice(1, 4);

                Stopwatch stopwatch = new Stopwatch(); // Instantiate the Stopwatch here

                switch (quickSortChoice)
                {
                    case 1:
                        // Measure time taken by Quick Sort By ID
                        stopwatch.Start();
                        parkingSystem.QuickSortSlot_ById();
                        stopwatch.Stop();
                        Console.WriteLine($"\nQuick Sort (By ID) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 2:
                        // Measure time taken by Quick Sort By Distance
                        stopwatch.Start();
                        parkingSystem.QuickSortSlot_ByDistance();
                        stopwatch.Stop();
                        Console.WriteLine($"\nQuick Sort (By Distance) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 3:
                        // Measure time taken by Quick Sort By Price
                        stopwatch.Start();
                        parkingSystem.QuickSortSlot_ByPrice();
                        stopwatch.Stop();
                        Console.WriteLine($"\nQuick Sort (By Price) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 4:
                        // Return to Admin Menu
                        Console.WriteLine("\nReturning to Admin Menu...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Optional: Pause before showing the menu again
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        // Show bubble sort options for sorting slots
        static void ShowBubbleSortOptions(ParkingSlotDoublyLinkedList parkingSystem)
        {
            while (true) // Loop to keep the sorting options active
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("                  Bubble Sort                ");
                Console.WriteLine("=============================================");
                Console.WriteLine(" 1. Sort By ID");
                Console.WriteLine(" 2. Sort By Distance");
                Console.WriteLine(" 3. Sort By Price");
                Console.WriteLine(" 4. Back");
                Console.WriteLine("=============================================");

                int bubbleSortChoice = GetValidChoice(1, 4);

                Stopwatch stopwatch = new Stopwatch(); // Instantiate the Stopwatch here

                switch (bubbleSortChoice)
                {
                    case 1:
                        // Measure time taken by Bubble Sort By ID
                        stopwatch.Start();
                        parkingSystem.BubbleSortSlot_ById();
                        stopwatch.Stop();
                        Console.WriteLine($"\nBubble Sort (By ID) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 2:
                        // Measure time taken by Bubble Sort By Distance
                        stopwatch.Start();
                        parkingSystem.BubbleSortSlot_ByDistance();
                        stopwatch.Stop();
                        Console.WriteLine($"\nBubble Sort (By Distance) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 3:
                        // Measure time taken by Bubble Sort By Price
                        stopwatch.Start();
                        parkingSystem.BubbleSortSlot_ByPrice();
                        stopwatch.Stop();
                        Console.WriteLine($"\nBubble Sort (By Price) executed in: {stopwatch.ElapsedMilliseconds} ms");
                        parkingSystem.DisplaySlots();
                        break;

                    case 4:
                        // Return to Admin Menu
                        Console.WriteLine("\nReturning to Admin Menu...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Optional: Pause before showing the menu again
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

    }
}
