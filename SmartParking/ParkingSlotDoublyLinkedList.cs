namespace smartparking
{
    class ParkingSlotDoublyLinkedList
    {
        private ParkingSlotNode? head;
        int TotalSlotCount = 0;
        int BookingSlotCount = 0;

        // Add a parking slot to the linked list
        public void AddSlot(int slotID, double distance)
        {
            // Check if the slot with the given ID already exists
            ParkingSlotNode temp = head;
            while (temp != null)
            {
                if (temp.SlotID == slotID)
                {
                    // Slot ID already exists
                    Console.WriteLine($"Slot with ID {slotID} already exists.");
                    return;  // Exit the method, as no new slot will be added
                }
                temp = temp.Next;
            }

            // If slot does not exist, add a new slot
            ParkingSlotNode newSlot = new ParkingSlotNode(slotID, distance);
            if (head == null)
            {
                // If the list is empty, make the new slot the head
                head = newSlot;
            }
            else
            {
                // If the list is not empty, find the last node and add the new slot
                temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newSlot;
                newSlot.Prev = temp;
            }

            TotalSlotCount++;  // Increment total slot count
        }

        // Sort slots using Merge Sort (by SlotID)
        public void MergeSortSlot_ById()
        {
            head = MergeSort(head, "id");
        }

        // Sort slots using Merge Sort (by Distance)
        public void MergeSortSlot_ByDistance()
        {
            head = MergeSort(head, "distance");
        }

        // Sort slots using Merge Sort (by Price)
        public void MergeSortSlot_ByPrice()
        {
            head = MergeSort(head, "price");
        }

        // General Merge Sort method that accepts a comparison type: "id", "distance", or "price"
        private ParkingSlotNode MergeSort(ParkingSlotNode node, string sortBy)
        {
            if (node == null || node.Next == null) return node;

            ParkingSlotNode middle = GetMiddle(node);
            ParkingSlotNode nextToMiddle = middle.Next;
            middle.Next = null;
            if (nextToMiddle != null) nextToMiddle.Prev = null;

            ParkingSlotNode left = MergeSort(node, sortBy);
            ParkingSlotNode right = MergeSort(nextToMiddle, sortBy);

            return Merge(left, right, sortBy);
        }

        // Find the middle node using the slow and fast pointer approach
        private ParkingSlotNode GetMiddle(ParkingSlotNode node)
        {
            if (node == null) return node;

            ParkingSlotNode slow = node, fast = node;
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        // Merge two sorted sublists into a single sorted list based on the specified property
        private ParkingSlotNode Merge(ParkingSlotNode left, ParkingSlotNode right, string sortBy)
        {
            // Base cases: if one of the lists is empty, return the other list
            if (left == null) return right;
            if (right == null) return left;

            ParkingSlotNode result;

            // Compare based on the specified property
            switch (sortBy.ToLower())
            {
                case "id":
                    if (left.SlotID <= right.SlotID)
                    {
                        result = left;
                        result.Next = Merge(left.Next, right, sortBy);
                        if (result.Next != null) result.Next.Prev = result;
                    }
                    else
                    {
                        result = right;
                        result.Next = Merge(left, right.Next, sortBy);
                        if (result.Next != null) result.Next.Prev = result;
                    }
                    break;

                case "distance":
                    if (left.Distance <= right.Distance)
                    {
                        result = left;
                        result.Next = Merge(left.Next, right, sortBy);
                        if (result.Next != null) result.Next.Prev = result;
                    }
                    else
                    {
                        result = right;
                        result.Next = Merge(left, right.Next, sortBy);
                        if (result.Next != null) result.Next.Prev = result;
                    }
                    break;

                case "price":
                    if (left.Price <= right.Price)
                    {
                        result = left;
                        result.Next = Merge(left.Next, right, sortBy);
                        if (result.Next != null) result.Next.Prev = result;
                    }
                    else
                    {
                        result = right;
                        result.Next = Merge(left, right.Next, sortBy);
                        if (result.Next != null) result.Next.Prev = result;
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid sort property");
            }

            return result;
        }

        // Sort slots using Quick Sort (by SlotID)
        public void QuickSortSlot_ById()
        {
            head = QuickSort(head, "id");
        }

        // Sort slots using Quick Sort (by Distance)
        public void QuickSortSlot_ByDistance()
        {
            head = QuickSort(head, "distance");
        }

        // Sort slots using Quick Sort (by Price)
        public void QuickSortSlot_ByPrice()
        {
            head = QuickSort(head, "price");
        }

        // General Quick Sort method that accepts a comparison type: "id", "distance", or "price"
        private ParkingSlotNode QuickSort(ParkingSlotNode node, string sortBy)
        {
            if (node == null || node.Next == null) return node; // Base case

            ParkingSlotNode pivot = node;
            ParkingSlotNode tail = node;
            while (tail.Next != null) tail = tail.Next;

            ParkingSlotNode left = null, right = null, current = node.Next;

            while (current != null)
            {
                ParkingSlotNode next = current.Next;
                if (CompareNodes(current, pivot, sortBy))
                {
                    current.Next = left;
                    left = current;
                }
                else
                {
                    current.Next = right;
                    right = current;
                }
                current = next;
            }

            left = QuickSort(left, sortBy);
            right = QuickSort(right, sortBy);

            if (left != null)
            {
                ParkingSlotNode leftTail = left;
                while (leftTail.Next != null) leftTail = leftTail.Next;
                leftTail.Next = pivot;
            }

            pivot.Next = right;

            return left ?? pivot;
        }

        // Comparison function for sorting based on the property (SlotID, Distance, or Price)
        private bool CompareNodes(ParkingSlotNode node1, ParkingSlotNode node2, string sortBy) => sortBy.ToLower(System.Globalization.CultureInfo.CurrentCulture) switch
        {
            "id" => node1.SlotID <= node2.SlotID,
            "distance" => node1.Distance <= node2.Distance,
            "price" => node1.Price <= node2.Price,
            _ => throw new ArgumentException("Invalid sort property"),
        };

        // Sort slots using Bubble Sort (by SlotID)
        public void BubbleSortSlot_ById()
        {
            BubbleSort(head, "id");
        }

        // Sort slots using Bubble Sort (by Distance)
        public void BubbleSortSlot_ByDistance()
        {
            BubbleSort(head, "distance");
        }

        // Sort slots using Bubble Sort (by Price)
        public void BubbleSortSlot_ByPrice()
        {
            BubbleSort(head, "price");
        }

        // General Bubble Sort method that accepts a comparison type: "id", "distance", or "price"
        private void BubbleSort(ParkingSlotNode node, string sortBy)
        {
            if (node == null) return;

            bool swapped;
            do
            {
                swapped = false;
                ParkingSlotNode current = node;

                // Traverse the list, compare adjacent elements and swap if necessary
                while (current != null && current.Next != null)
                {
                    if (!CompareNodes(current, current.Next, sortBy))
                    {
                        // Swap nodes
                        SwapNodes(current, current.Next);
                        swapped = true;
                    }
                    current = current.Next;
                }
            }
            while (swapped); // Repeat until no swaps are needed
        }

        // Swap two adjacent nodes
        private void SwapNodes(ParkingSlotNode node1, ParkingSlotNode node2)
        {
            // Swap the slot values (id, distance, and price) between two nodes
            int tempSlotID = node1.SlotID;
            double tempDistance = node1.Distance;
            double tempPrice = node1.Price;

            node1.SlotID = node2.SlotID;
            node1.Distance = node2.Distance;
            node1.Price = node2.Price;

            node2.SlotID = tempSlotID;
            node2.Distance = tempDistance;
            node2.Price = tempPrice;
        }

        // Find the nearest available parking slot
        public ParkingSlotNode FindNearestAvailableSlot()
        {
            ParkingSlotNode temp = head;
            while (temp != null)
            {
                if (!temp.IsBooked)
                {
                    return temp;
                }
                temp = temp.Next;
            }
            return null; // No available slots
        }



        // Remove a vehicle (free up a slot)
        public bool RemoveSlot(int slotID)
        {
            ParkingSlotNode temp = head;

            // Check if the slot with the given ID exists and if it's available (not booked)
            while (temp != null)
            {
                if (temp.SlotID == slotID)
                {
                    // Check if the slot is booked
                    if (temp.IsBooked)
                    {
                        Console.WriteLine("Slot is currently booked. Cannot remove a booked slot.");
                        return false;
                    }

                    // If the slot is not booked, proceed to remove it
                    // (Update the linked list to remove the slot)
                    if (temp.Prev != null)
                    {
                        temp.Prev.Next = temp.Next;  // Update the previous node's next pointer
                    }
                    else
                    {
                        head = temp.Next;  // If it's the first node (head), update the head
                    }

                    if (temp.Next != null)
                    {
                        temp.Next.Prev = temp.Prev;  // Update the next node's prev pointer
                    }

                    TotalSlotCount--;  // Decrease the total slot count
                    Console.WriteLine($"Slot {slotID} has been successfully removed.");
                    return true;
                }
                temp = temp.Next;
            }

            Console.WriteLine("Slot ID does not exist.");
            return false;  // If the slot wasn't found
        }

        // Display all parking slots with availability status
        public void DisplaySlots()
        {
            ParkingSlotNode temp = head;

            Console.WriteLine("\n================================================================================");
            Console.WriteLine("|  Slot ID  |  Distance (m)   |  Price  |  Status    |  UserName   |  VehicleNo  |");
            Console.WriteLine("==================================================================================");

            while (temp != null)
            {
                string status = temp.IsBooked ? "Booked" : "Available";
                string userName = temp.UserName ?? "N/A";  // Default to "N/A" if UserName is null
                string vehicleNo = temp.VehicleNo ?? "N/A";  // Default to "N/A" if VehicleNo is null

                Console.WriteLine($"|    {temp.SlotID,-5}  |     {temp.Distance,-10}  |  {temp.Price,-6:C} |  {status,-8} |  {userName,-10} |  {vehicleNo,-10} |");
                temp = temp.Next;
            }
            Console.WriteLine("==================================================================================");
        }

        public void UserDisplaySlots()
        {
            while (true) // Infinite loop to keep the sorting menu running
            {
                // Check if the head of the list is null (empty list)
                if (head == null)
                {
                    Console.WriteLine("No parking slots available.");
                    return;
                }

                // Ask the user for the sorting criteria
                Console.WriteLine("\n============================================");
                Console.WriteLine("         Sort the Parking Slots by Distance   ");
                Console.WriteLine("============================================");
                Console.WriteLine("1. Merge Sort");
                Console.WriteLine("2. Bubble Sort");
                Console.WriteLine("3. Quick Sort");
                Console.WriteLine("4. Back");
                Console.WriteLine("============================================");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Sort the linked list based on user's choice
                switch (choice)
                {
                    case "1":
                        MergeSortSlot_ByDistance();
                        Console.WriteLine("\nSorted by Distance using Merge Sort.");
                        break;

                    case "2":
                        BubbleSortSlot_ByDistance();
                        Console.WriteLine("\nSorted by Distance using Bubble Sort.");
                        break;

                    case "3":
                        QuickSortSlot_ByDistance();
                        Console.WriteLine("\nSorted by Distance using Quick Sort.");
                        break;

                    case "4":
                        //Console.WriteLine("\nReturning to User Menu...");
                        return; // Exit the sorting menu and go back

                    default:
                        Console.WriteLine("Invalid choice. Sorting by Distance using Merge Sort.");
                        MergeSortSlot_ByDistance(); // Default to Merge Sort
                        break;
                }

                // Now, display the sorted list
                ParkingSlotNode temp = head;

                Console.WriteLine("\n====================================================");
                Console.WriteLine("|  Slot ID  |  Distance (m)   |  Status             |");
                Console.WriteLine("====================================================");

                while (temp != null)
                {
                    string status = temp.IsBooked ? "Booked" : "Available";
                    Console.WriteLine($"|    {temp.SlotID,-5}  |     {temp.Distance,-10}  |  {status,-18} |");
                    temp = temp.Next; // Move to the next node
                }

                Console.WriteLine("====================================================");

                // Optional: Pause before showing the menu again
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }


        public void ShowSlots()
        {
            ParkingSlotNode temp = head;

            Console.WriteLine("\n=============");
            Console.WriteLine("|  Slot ID  |  ");
            Console.WriteLine("===============");

            while (temp != null)
            {
                Console.WriteLine($"|    {temp.SlotID,-5}  |");
                temp = temp.Next;
            }
            Console.WriteLine("===============");
        }

        // Edit the details of an existing parking slot (e.g., distance, price)
        public bool EditSlot(int slotID, double newDistance)
        {
            ParkingSlotNode temp = head;

            // Search for the slot with the provided slotID
            while (temp != null)
            {
                if (temp.SlotID == slotID)
                {
                    Console.WriteLine($"Previous Slot --> Slot {slotID} & Distance {temp.Distance}.");
                    // Update the slot details
                    temp.Distance = newDistance;
                    Console.WriteLine($"Slot {slotID} has been updated.");
                    Console.WriteLine($"After Edit Slot --> Slot {slotID} & New Distance = {newDistance}");
                    return true;
                }
                temp = temp.Next;
            }

            Console.WriteLine($"Slot ID {slotID} does not exist.");
            return false;  // If slot was not found
        }

        // Get total slots count
        public int GetTotalSlots()
        {
            return TotalSlotCount;
        }

        // Get the count of available slots
        public int GetAvailableSlotsCount()
        {
            int AvailableSlots = TotalSlotCount - BookingSlotCount;
            return AvailableSlots;
        }

        // Get the count of booked slots
        public int GetBookedSlotsCount()
        {
            return BookingSlotCount;
        }


        // Book a slot for the user (based on SlotID, UserName, VehicleNo, and Duration)

        // Add a parking slot to the linked list
        public void BookingSlot(int slotID, String UserName, String VehicleNo, double Duration)
        {
            // Check if the slot with the given ID already exists
            ParkingSlotNode temp = head;
            while (temp != null)
            {
                if (temp.SlotID == slotID)
                {
                    // Slot ID already exists
                    Console.WriteLine($"Slot with ID {slotID} already exists.");
                    temp.UserName = UserName;
                    temp.VehicleNo = VehicleNo;
                    temp.Duration = Duration;
                    temp.Price = Duration * 5;
                    temp.IsBooked = true;

                    Console.WriteLine("\n====== Booking Confirmation ======");
                    Console.WriteLine($"Name         : {temp.UserName}");
                    Console.WriteLine($"Vehicle No   : {temp.VehicleNo}");
                    Console.WriteLine($"Slot ID      : {temp.SlotID}");
                    Console.WriteLine($"Price        : ${temp.Price}");
                    Console.WriteLine("===================================\n");
                    return;  // Exit the method, as no new slot will be added
                }
                temp = temp.Next;
            }

            TotalSlotCount++;  // Increment total slot count
        }

    }
}

