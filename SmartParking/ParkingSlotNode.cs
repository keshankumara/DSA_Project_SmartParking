using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartparking
{

    class ParkingSlotNode
    {
        public int SlotID { get; set; }
        public double Distance { get; set; }
        public String? UserName { get; set; }
        public String? VehicleNo { get; set; }
        public double Price { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsBooked { get; set; }
        public double Duration { get; set; }
        public ParkingSlotNode? Prev { get; set; }  // Pointer to the previous slot
        public ParkingSlotNode? Next { get; set; }  // Pointer to the next slot

        public ParkingSlotNode(int slotID, double distance)
        {
            SlotID = slotID;
            Distance = distance;
            Price = 0.0;
            IsBooked = false;
            UserName = null;
            VehicleNo = null;
            Duration = 0;
            Prev = null;
            Next = null;
        }
    }

}
