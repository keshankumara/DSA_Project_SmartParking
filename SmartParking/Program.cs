
using System;
using System.Diagnostics;
using smartparking;


namespace SmartParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("            Welcome to Smart Parking System              ");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("=========================================================");
            Console.WriteLine("");

            // Initialize the parking system
            ParkingSlotDoublyLinkedList parkingSystem = new ParkingSlotDoublyLinkedList();

            // Adding parking slots for demonstration

            //Console.WriteLine("\n=============================================");
            Console.WriteLine("                        Parks Types                      ");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine(" 1. Car Park (Default)");
            Console.WriteLine(" 2. Bike Park");
            Console.WriteLine(" 3. Other Vehicles Park");
            Console.WriteLine("");
            //Console.WriteLine("=========================================================");

            Console.WriteLine("");
            Console.WriteLine(" If You change default Park ");
            Console.WriteLine("         1. Yes ");
            Console.WriteLine("         2. No");
            Console.WriteLine("");
            Console.Write(" Enter Your Selection : ");
            int ChangePark = Convert.ToInt32(Console.ReadLine());

            if (ChangePark == 1)
            {
                Console.WriteLine("");
                Console.Write(" Enter Your Selection Park (1-3) : ");
                int ParkTime = Convert.ToInt32(Console.ReadLine());

                if (ParkTime == 1)
                {
                    AddSampleSlots_Car(parkingSystem);
                }

                else if (ParkTime == 2)
                {
                    AddSampleSlots_Bike(parkingSystem);
                }

                else if (ParkTime == 2)
                {
                    AddSampleSlots_Other(parkingSystem);
                }
            }

            else
            {
                AddSampleSlots_Car(parkingSystem);
            }


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
                    Console.WriteLine(" Exiting... Thank you for using Smart Parking!");
                    break;
                }
            }
        }

        // Function to handle Admin Login (password check)
        static bool AdminLogin()
        {
            string correctPassword = "123"; // Set admin password 
            Console.WriteLine("");
            Console.Write(" Enter Admin Password: ");
            string inputPassword = Console.ReadLine();
            Console.WriteLine("");
            return inputPassword == correctPassword;
        }

        // Display the main menu for the user
        static void DisplayMainMenu()
        {
            Console.WriteLine("\n=========================================================");
            Console.WriteLine("                 Main Menu - Choose an Option         ");
            Console.WriteLine("=========================================================");
            Console.WriteLine("     1. User Section");
            Console.WriteLine("     2. Admin Section");
            Console.WriteLine("     3. Exit");
            Console.WriteLine("");
            //Console.WriteLine("=========================================================");
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

        // Small Data Set (50 Slots)
        static void AddSampleSlots_Car(ParkingSlotDoublyLinkedList parkingSystem)
        {
            parkingSystem.AddSlot(137, 22.3);
            parkingSystem.AddSlot(121, 15.2);
            parkingSystem.AddSlot(143, 18.7);
            parkingSystem.AddSlot(109, 20.6);
            parkingSystem.AddSlot(126, 13.5);
            parkingSystem.AddSlot(115, 17.8);
            parkingSystem.AddSlot(103, 21.3);
            parkingSystem.AddSlot(148, 12.9);
            parkingSystem.AddSlot(122, 10.2);
            parkingSystem.AddSlot(138, 16.1);
            parkingSystem.AddSlot(117, 23.4);
            parkingSystem.AddSlot(105, 25.0);
            parkingSystem.AddSlot(111, 14.8);
            parkingSystem.AddSlot(140, 19.5);
            parkingSystem.AddSlot(104, 24.0);
            parkingSystem.AddSlot(114, 26.7);
            parkingSystem.AddSlot(119, 11.5);
            parkingSystem.AddSlot(127, 28.2);
            parkingSystem.AddSlot(136, 30.6);
            parkingSystem.AddSlot(149, 32.3);
            parkingSystem.AddSlot(120, 29.4);
            parkingSystem.AddSlot(108, 13.1);
            parkingSystem.AddSlot(125, 18.0);
            parkingSystem.AddSlot(110, 19.0);
            parkingSystem.AddSlot(118, 27.5);
            parkingSystem.AddSlot(106, 22.0);
            parkingSystem.AddSlot(132, 31.8);
            parkingSystem.AddSlot(116, 34.5);
            parkingSystem.AddSlot(142, 21.9);
            parkingSystem.AddSlot(123, 33.0);
            parkingSystem.AddSlot(130, 23.1);
            parkingSystem.AddSlot(131, 29.9);
            parkingSystem.AddSlot(124, 25.9);
            parkingSystem.AddSlot(128, 35.2);
            parkingSystem.AddSlot(141, 36.1);
            parkingSystem.AddSlot(133, 40.0);
            parkingSystem.AddSlot(134, 39.5);
            parkingSystem.AddSlot(129, 41.7);
            parkingSystem.AddSlot(107, 38.3);
            parkingSystem.AddSlot(139, 44.1);
            parkingSystem.AddSlot(145, 42.2);
            parkingSystem.AddSlot(144, 47.8);
            parkingSystem.AddSlot(135, 45.0);
            parkingSystem.AddSlot(146, 50.5);
            parkingSystem.AddSlot(151, 49.1);
            parkingSystem.AddSlot(152, 48.4);
        }

        // Large Data Set (100 Slots)
        static void AddSampleSlots_Bike(ParkingSlotDoublyLinkedList parkingSystem)
        {
            parkingSystem.AddSlot(467, 28.4);
            parkingSystem.AddSlot(462, 10.7);
            parkingSystem.AddSlot(535, 25.3);
            parkingSystem.AddSlot(588, 34.8);
            parkingSystem.AddSlot(575, 31.2);
            parkingSystem.AddSlot(463, 22.1);
            parkingSystem.AddSlot(593, 39.0);
            parkingSystem.AddSlot(505, 16.3);
            parkingSystem.AddSlot(523, 43.5);
            parkingSystem.AddSlot(501, 19.9);
            parkingSystem.AddSlot(584, 26.6);
            parkingSystem.AddSlot(582, 27.4);
            parkingSystem.AddSlot(407, 21.8);
            parkingSystem.AddSlot(435, 23.7);
            parkingSystem.AddSlot(586, 35.1);
            parkingSystem.AddSlot(512, 25.6);
            parkingSystem.AddSlot(461, 38.7);
            parkingSystem.AddSlot(548, 32.3);
            parkingSystem.AddSlot(598, 22.8);
            parkingSystem.AddSlot(570, 26.9);
            parkingSystem.AddSlot(553, 29.2);
            parkingSystem.AddSlot(537, 31.5);
            parkingSystem.AddSlot(519, 17.5);
            parkingSystem.AddSlot(563, 33.0);
            parkingSystem.AddSlot(561, 36.2);
            parkingSystem.AddSlot(475, 34.0);
            parkingSystem.AddSlot(572, 22.3);
            parkingSystem.AddSlot(540, 38.3);
            parkingSystem.AddSlot(502, 21.1);
            parkingSystem.AddSlot(516, 45.8);
            parkingSystem.AddSlot(579, 20.4);
            parkingSystem.AddSlot(532, 30.4);
            parkingSystem.AddSlot(565, 28.0);
            parkingSystem.AddSlot(518, 36.1);
            parkingSystem.AddSlot(549, 19.6);
            parkingSystem.AddSlot(560, 47.0);
            parkingSystem.AddSlot(573, 33.5);
            parkingSystem.AddSlot(550, 31.1);
            parkingSystem.AddSlot(562, 39.4);
            parkingSystem.AddSlot(525, 22.5);
            parkingSystem.AddSlot(551, 31.9);
            parkingSystem.AddSlot(534, 28.7);
            parkingSystem.AddSlot(545, 18.7);
            parkingSystem.AddSlot(539, 48.9);
            parkingSystem.AddSlot(566, 38.4);
            parkingSystem.AddSlot(504, 20.7);
            parkingSystem.AddSlot(536, 44.6);
            parkingSystem.AddSlot(578, 47.3);
            parkingSystem.AddSlot(576, 42.0);
            parkingSystem.AddSlot(648, 19.8);
        }


        // Medium Data Set (100 Slots)
        static void AddSampleSlots_Other(ParkingSlotDoublyLinkedList parkingSystem)
        {
            parkingSystem.AddSlot(370, 10.3);
            parkingSystem.AddSlot(229, 13.5);
            parkingSystem.AddSlot(342, 21.2);
            parkingSystem.AddSlot(199, 15.6);
            parkingSystem.AddSlot(248, 17.4);
            parkingSystem.AddSlot(319, 18.5);
            parkingSystem.AddSlot(266, 20.8);
            parkingSystem.AddSlot(303, 25.0);
            parkingSystem.AddSlot(278, 23.7);
            parkingSystem.AddSlot(315, 30.9);
            parkingSystem.AddSlot(358, 28.1);
            parkingSystem.AddSlot(289, 14.0);
            parkingSystem.AddSlot(359, 34.4);
            parkingSystem.AddSlot(321, 31.3);
            parkingSystem.AddSlot(233, 27.8);
            parkingSystem.AddSlot(317, 36.2);
            parkingSystem.AddSlot(214, 16.6);
            parkingSystem.AddSlot(276, 29.5);
            parkingSystem.AddSlot(274, 18.2);
            parkingSystem.AddSlot(300, 38.5);
            parkingSystem.AddSlot(267, 19.1);
            parkingSystem.AddSlot(256, 22.4);
            parkingSystem.AddSlot(243, 26.6);
            parkingSystem.AddSlot(269, 33.0);
            parkingSystem.AddSlot(322, 12.7);
            parkingSystem.AddSlot(233, 25.3);
            parkingSystem.AddSlot(240, 35.4);
            parkingSystem.AddSlot(206, 37.0);
            parkingSystem.AddSlot(223, 40.1);
            parkingSystem.AddSlot(261, 41.2);
            parkingSystem.AddSlot(227, 29.3);
            parkingSystem.AddSlot(310, 48.5);
            parkingSystem.AddSlot(295, 46.7);
            parkingSystem.AddSlot(271, 44.1);
            parkingSystem.AddSlot(297, 50.4);
            parkingSystem.AddSlot(220, 39.9);
            parkingSystem.AddSlot(305, 43.0);
            parkingSystem.AddSlot(312, 42.5);
            parkingSystem.AddSlot(229, 41.5);
            parkingSystem.AddSlot(284, 30.7);
            parkingSystem.AddSlot(268, 24.9);
            parkingSystem.AddSlot(211, 19.3);
            parkingSystem.AddSlot(224, 31.1);
            parkingSystem.AddSlot(250, 32.8);
            parkingSystem.AddSlot(337, 27.2);
            parkingSystem.AddSlot(330, 30.1);
            parkingSystem.AddSlot(307, 14.4);
            parkingSystem.AddSlot(234, 22.9);
            parkingSystem.AddSlot(344, 33.4);
            parkingSystem.AddSlot(309, 36.6);
            parkingSystem.AddSlot(243, 35.7);
            parkingSystem.AddSlot(348, 40.0);
            parkingSystem.AddSlot(273, 28.3);
            parkingSystem.AddSlot(213, 44.2);
            parkingSystem.AddSlot(277, 37.9);
            parkingSystem.AddSlot(225, 29.4);
            parkingSystem.AddSlot(249, 24.8);
            parkingSystem.AddSlot(257, 13.8);
            parkingSystem.AddSlot(305, 38.4);
            parkingSystem.AddSlot(228, 21.4);
            parkingSystem.AddSlot(285, 45.6);
            parkingSystem.AddSlot(298, 49.3);
            parkingSystem.AddSlot(232, 17.9);
            parkingSystem.AddSlot(240, 39.7);
            parkingSystem.AddSlot(335, 47.9);
            parkingSystem.AddSlot(202, 19.4);
            parkingSystem.AddSlot(236, 27.5);
            parkingSystem.AddSlot(221, 48.2);
            parkingSystem.AddSlot(278, 33.5);
            parkingSystem.AddSlot(222, 32.7);
            parkingSystem.AddSlot(258, 28.9);
            parkingSystem.AddSlot(282, 23.0);
            parkingSystem.AddSlot(316, 41.8);
            parkingSystem.AddSlot(286, 25.5);
            parkingSystem.AddSlot(320, 46.3);
            parkingSystem.AddSlot(285, 39.1);
            parkingSystem.AddSlot(214, 16.2);
            parkingSystem.AddSlot(236, 49.7);
            parkingSystem.AddSlot(298, 41.0);
            parkingSystem.AddSlot(205, 12.8);
            parkingSystem.AddSlot(289, 40.2);
            parkingSystem.AddSlot(225, 34.9);
        }


        // User section - Allows the user to view available slots and make bookings
        static void UserSection(ParkingSlotDoublyLinkedList parkingSystem)
        {
            Console.WriteLine("\n=========================================================");
            Console.WriteLine("            Welcome to the User Section       ");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("     1. Sort available bookings");
            Console.WriteLine("     2. Booking");
            Console.WriteLine("     3. Back");
            Console.WriteLine("");
            //Console.WriteLine("=========================================================");

            int choice = GetValidChoice(1, 3);

            switch (choice)
            {
                case 1:
                    // View all available slots
                    parkingSystem.UserDisplaySlots();
                    break;

                case 2:
                    Console.WriteLine("");
                    Console.Write(" Enter Slot ID : ");
                    int SlotID = Convert.ToInt32(Console.ReadLine());
                    Console.Write(" Enter User Name : ");
                    string UserName = Console.ReadLine();
                    Console.Write(" Enter Vehicle No : ");
                    string VehicleNo = Console.ReadLine();
                    Console.Write(" Enter Parking Duration(Hours) : ");
                    double Duration = Convert.ToInt32(Console.ReadLine());
                    parkingSystem.BookingSlot(SlotID, UserName, VehicleNo, Duration);
                    Console.WriteLine("");
                    break;

                case 3:
                    // Go back to main menu
                    // Additional user functionalities can be added here, such as booking a slot
                    Console.WriteLine("\n Returning to Main Menu...");
                    break;

                default:
                    Console.WriteLine(" Invalid choice. Returning to Admin Menu...");
                    break;
            }





        }

        // Admin section - Allows the admin to manage parking slots
        static void AdminSection(ParkingSlotDoublyLinkedList parkingSystem)
        {
            Console.WriteLine("\n=========================================================");
            Console.WriteLine("            Admin Section - Smart Parking       ");
            Console.WriteLine("---------------------------------------------------------");

            if (!AdminLogin())
            {
                Console.WriteLine(" Incorrect password. Returning to main menu...\n");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n=========================================================");
                Console.WriteLine("          Admin Menu - Choose an Action      ");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("     1. View Slots");
                Console.WriteLine("     2. Add Slot");
                Console.WriteLine("     3. Remove Slot");
                Console.WriteLine("     4. Edit Slot");
                Console.WriteLine("     5. Back to Main Menu");
                Console.WriteLine("");
                //Console.WriteLine("=========================================================");

                int choice = GetValidChoice(1, 5);

                switch (choice)
                {
                    case 1:
                        // View all slots
                        Console.WriteLine("");
                        Console.WriteLine("     Total Slots: " + parkingSystem.GetTotalSlots());
                        Console.WriteLine("     Available Slots: " + parkingSystem.GetAvailableSlotsCount());
                        Console.WriteLine("     Booked Slots: " + parkingSystem.GetBookedSlotsCount());
                        Console.WriteLine("");
                        parkingSystem.DisplaySlots();
                        Console.WriteLine("");
                        ShowSortingMethodOptions(parkingSystem);
                        break;

                    case 2:
                        // Add a new slot
                        Console.WriteLine("");
                        Console.Write(" Enter Slot ID: ");
                        int slotID = Convert.ToInt32(Console.ReadLine());
                        Console.Write(" Enter Distance: ");
                        double distance = Convert.ToDouble(Console.ReadLine());
                        parkingSystem.AddSlot(slotID, distance);
                        Console.WriteLine("");
                        break;

                    case 3:
                        // Remove a slot
                        Console.WriteLine("");
                        Console.WriteLine("Slots ID's:");
                        parkingSystem.ShowSlots();
                        Console.Write("Enter Slot ID to remove: ");
                        int removeSlotID = Convert.ToInt32(Console.ReadLine());
                        parkingSystem.RemoveSlot(removeSlotID);
                        Console.WriteLine("");
                        break;

                    case 4:
                        // Edit a slot
                        Console.WriteLine("");
                        Console.Write("Enter Slot ID to edit: ");
                        int editID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new Distance: ");
                        double editDistance = Convert.ToDouble(Console.ReadLine());
                        parkingSystem.EditSlot(editID, editDistance);
                        Console.WriteLine("");
                        break;

                    case 5:
                        // Go back to main menu
                        Console.WriteLine("");
                        Console.WriteLine(" Go back to main menu ..");
                        Console.WriteLine("");
                        return;

                    default:
                        Console.WriteLine("");
                        Console.WriteLine(" Invalid choice. Returning to Admin Menu...");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        // Show sorting options for selecting the sorting method (Quick Sort, Merge Sort, Bubble Sort)
        static void ShowSortingMethodOptions(ParkingSlotDoublyLinkedList parkingSystem)
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine("                Choose Sorting Method        ");
            Console.WriteLine("=============================================");
            Console.WriteLine(" 1. Merge Sort");
            Console.WriteLine(" 2. Quick Sort");
            Console.WriteLine(" 3. Bubble Sort");
            Console.WriteLine(" 4. Back ");
            Console.WriteLine("=============================================");

            int sortMethodChoice = GetValidChoice(1, 4);

            switch (sortMethodChoice)
            {
                case 1:
                    // Merge Sort selected
                    ShowMergeSortOptions(parkingSystem);
                    // Measure time taken by Merge Sort By Distance
                    break;

                case 2:
                    // Quick Sort selected
                    ShowQuickSortOptions(parkingSystem);
                    break;

                case 3:
                    // Bubble Sort selected
                    ShowBubbleSortOptions(parkingSystem);
                    break;

                case 4:
                    // Return to Admin Menu
                    Console.WriteLine("Go back ..");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Returning to Admin Menu...");
                    break;
            }
        }

        // Show merge sort options for sorting slots
        static void ShowMergeSortOptions(ParkingSlotDoublyLinkedList parkingSystem)
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine("                  Merge Sort                 ");
            Console.WriteLine("=============================================");
            Console.WriteLine(" 1. Sort By ID");
            Console.WriteLine(" 2. Sort By Distance");
            Console.WriteLine(" 3. Sort By Price");
            Console.WriteLine(" 4. Back ");
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

                    Console.WriteLine($"Merge Sort (By ID) executed in: {stopwatch.ElapsedTicks} ticks");
                    parkingSystem.DisplaySlots();
                    break;

                case 2:
                    // Measure time taken by Merge Sort By Distance
                    stopwatch.Start();
                    parkingSystem.MergeSortSlot_ByDistance();
                    stopwatch.Stop();

                    Console.WriteLine($"Merge Sort (By Distance) executed in: {stopwatch.ElapsedTicks} ticks");
                    parkingSystem.DisplaySlots();
                    break;

                case 3:
                    // Measure time taken by Merge Sort By Price
                    stopwatch.Start();
                    parkingSystem.MergeSortSlot_ByPrice();
                    stopwatch.Stop();

                    Console.WriteLine($"Merge Sort (By Price) executed in: {stopwatch.ElapsedTicks} ticks");
                    parkingSystem.DisplaySlots();
                    break;


                case 4:
                    // Return to Admin Menu
                    Console.WriteLine("Go back to main menu ..");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Returning to Admin Menu...");
                    break;
            }
        }

        // Show quick sort options for sorting slots
        static void ShowQuickSortOptions(ParkingSlotDoublyLinkedList parkingSystem)
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine("                  Quick Sort                 ");
            Console.WriteLine("=============================================");
            Console.WriteLine(" 1. Sort By ID");
            Console.WriteLine(" 2. Sort By Distance");
            Console.WriteLine(" 3. Sort By Price");
            Console.WriteLine(" 4. Back to Admin Menu");
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
                    Console.WriteLine($"Quick Sort (By ID) executed in: {stopwatch.ElapsedTicks} ticks");
                    parkingSystem.DisplaySlots();
                    break;

                case 2:
                    // Measure time taken by Quick Sort By Distance
                    stopwatch.Start();
                    parkingSystem.QuickSortSlot_ByDistance();
                    stopwatch.Stop();
                    Console.WriteLine($"Quick Sort (By Distance) executed in: {stopwatch.ElapsedTicks} ticks");
                    parkingSystem.DisplaySlots();
                    break;

                case 3:
                    // Measure time taken by Quick Sort By Price
                    stopwatch.Start();
                    parkingSystem.QuickSortSlot_ByPrice();
                    stopwatch.Stop();
                    Console.WriteLine($"Quick Sort (By Price) executed in: {stopwatch.ElapsedTicks} ticks");
                    parkingSystem.DisplaySlots();
                    break;

                case 4:
                    // Return to Admin Menu
                    break;

                default:
                    Console.WriteLine("Invalid choice. Returning to Admin Menu...");
                    break;
            }
        }

        // Show bubble sort options for sorting slots
        static void ShowBubbleSortOptions(ParkingSlotDoublyLinkedList parkingSystem)
        {
            Console.WriteLine("\n=========================================================");
            Console.WriteLine("                  Bubble Sort                ");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("     1. Sort By ID");
            Console.WriteLine("     2. Sort By Distance");
            Console.WriteLine("     3. Sort By Price");
            Console.WriteLine("     4. Back to Admin Menu");
            Console.WriteLine("");
            //Console.WriteLine("=========================================================");

            int bubbleSortChoice = GetValidChoice(1, 4);

            Stopwatch stopwatch = new Stopwatch(); // Instantiate the Stopwatch here

            switch (bubbleSortChoice)
            {
                case 1:
                    // Measure time taken by Bubble Sort By ID
                    Console.WriteLine("");
                    stopwatch.Start();
                    parkingSystem.BubbleSortSlot_ById();
                    stopwatch.Stop();
                    Console.WriteLine($" Bubble Sort (By ID) executed in: {stopwatch.ElapsedTicks} ticks");
                    Console.WriteLine("");
                    parkingSystem.DisplaySlots();
                    Console.WriteLine("");
                    break;

                case 2:
                    // Measure time taken by Bubble Sort By Distance
                    stopwatch.Start();
                    parkingSystem.BubbleSortSlot_ByDistance();
                    stopwatch.Stop();
                    Console.WriteLine($" Bubble Sort (By Distance) executed in: {stopwatch.ElapsedTicks} ticks");
                    parkingSystem.DisplaySlots();
                    break;

                case 3:
                    // Measure time taken by Bubble Sort By Price
                    stopwatch.Start();
                    parkingSystem.BubbleSortSlot_ByPrice();
                    stopwatch.Stop();
                    Console.WriteLine($" Bubble Sort (By Price) executed in: {stopwatch.ElapsedTicks} ticks");
                    parkingSystem.DisplaySlots();
                    break;

                case 4:
                    // Return to Admin Menu
                    break;

                default:
                    Console.WriteLine(" Invalid choice. Returning to Admin Menu...");
                    break;
            }
        }


    }
}
