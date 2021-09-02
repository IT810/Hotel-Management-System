using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.ViewModel
{
    public class RoomBookingViewModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? BookingFrom { get; set; }
        public DateTime? BookingTo { get; set; }
        public string AssignRoom { get; set; }
        public decimal RoomPrice { get; set; }
        public int NoOfMembers { get; set; }
        public int NoOfDays { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerPhone { get; set; }
    }
}