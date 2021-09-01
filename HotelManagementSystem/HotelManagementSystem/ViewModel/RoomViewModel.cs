using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.ViewModel
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomImage { get; set; }
        public decimal RoomPrice { get; set; }
        public int BookingStatusID { get; set; }
        public int RoomTypeID { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomDescription { get; set; }
        public bool IsActive { get; set; }

        public List<SelectListItem> lobs { get; set; }
        public List<SelectListItem> lort { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}