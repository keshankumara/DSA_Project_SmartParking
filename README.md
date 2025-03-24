# 🚗 Smart Parking System 🚗

The **Smart Parking System** is an advanced console application built with C# to efficiently manage parking slots using cutting-edge data structures and algorithms. It leverages **doubly linked lists** for dynamic data management and implements powerful sorting algorithms like **Bubble Sort**, **Merge Sort**, and **Quick Sort** to keep parking slots well-organized based on **ID**, **distance**, and **price**. 

Designed to make parking management fast, simple, and highly efficient, this system is an excellent demonstration of practical **Data Structures and Algorithms (DSA)** concepts.

---

## 🌟 Key Features

### 🚀 Dynamic Parking Slot Management
- Add, edit, and remove parking slots with ease.
- Store essential slot information such as:
  - **Slot ID** - Uniquely identifies each parking spot.
  - **Distance** - Distance from the entry point.
  - **Price** - Cost per unit time.
  - **Availability** - Whether the slot is booked or free.
  
### 🗃️ Sorting Algorithms with Execution Time
Efficiently sort parking slots to streamline parking management while measuring the **execution time** of each sorting method:
- **Bubble Sort**: Simple yet effective sorting based on slot ID.
- **Merge Sort**: Powerful divide-and-conquer sorting for distance.
- **Quick Sort**: Lightning-fast sorting based on price.

> **Admin Dashboard:** View the **execution time** for each sorting method to evaluate performance and efficiency.

### 📅 Smart Booking System
- **User-Friendly Booking**: Book available parking slots by entering your name, vehicle number, and duration.
- **Pricing Calculation**: Automatically computes the total cost based on the stay duration.
- **Booking Confirmation**: View detailed booking info and slot availability.

### 📊 Real-Time Slot Availability
- Instantly view all available and booked parking slots.
- Clearly see slot details like user name, vehicle number, booking duration, and pricing.
- Efficiently manage high-traffic scenarios with quick sorting and searching.

---

## 🛠️ Getting Started

### Prerequisites
Make sure you have the following installed on your machine:
- [.NET SDK](https://dotnet.microsoft.com/download) (for building and running the application)

### Installation

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/keshankumara/DSA_Project_SmartParking.git
   ```
2. **Navigate to the Project Directory:**
   ```bash
   cd DSA_Project_SmartParking/SmartParking
   ```
3. **Build the Application:**
   ```bash
   dotnet build
   ```
4. **Run the Application:**
   ```bash
   dotnet run
   ```

---

## 💻 How to Use

### Admin Operations:
1. **Add Parking Slot**: Enter slot details to create a new slot.
2. **Edit Parking Slot**: Update existing slot information.
3. **Delete Parking Slot**: Remove a slot from the system.
4. **View All Slots**: Display current slot information.
5. **Sort Slots**: Choose a sorting algorithm to organize slots by ID, distance, or price.
6. **View Sorting Performance**: Check the **execution time** of each sorting algorithm to compare their efficiency.

### User Operations:
1. **View Available Slots**: Check which slots are currently free.
2. **Book a Slot**: Reserve a slot by providing your details.
3. **Booking Confirmation**: Receive feedback on successful booking with calculated pricing.

---

## 🏗️ Project Structure

- **ParkingSlotDoublyLinkedList.cs**: Manages a dynamic list of parking slots.
- **ParkingSlotNode.cs**: Represents each parking slot as a node with relevant details.
- **SortingAlgorithms.cs**: Implements sorting methods (Bubble, Merge, Quick) and measures execution time.
- **Main.cs**: Provides the main program interface and handles user inputs.

---

## 🏎️ Performance Insights
- Easily evaluate and compare the **execution time** of each sorting method.
- Make data-driven decisions on the most efficient algorithm for real-time parking management.

---

## 🤝 Contributing

We welcome contributions to make the Smart Parking System even better! Whether it’s optimizing sorting algorithms, enhancing the UI, or adding new features, your ideas are valuable.

### Steps to Contribute:
1. Fork the repository.
2. Create a new branch for your feature.
3. Make your changes and commit them.
4. Open a pull request for review.

---

## ✉️ Contact

For any questions, suggestions, or feedback, feel free to open an issue or contact the project maintainer directly.

---

🌐 **Explore the power of Data Structures and Algorithms with the Smart Parking System! Experience efficient parking management and performance evaluation like never before!** 🚀
