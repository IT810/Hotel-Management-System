using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModel
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Is required !!!")]
        public string RoomNumber { get; set; }
        public string RoomImage { get; set; }

        [Required(ErrorMessage = "Is required !!!")]
        [Range(500, 10000, ErrorMessage = "min: {1}; max: {2}")]
        public decimal RoomPrice { get; set; }
        public int BookingStatusID { get; set; }
        public int RoomTypeID { get; set; }

        [Required(ErrorMessage = "Is required !!!")]
        [Range(1, 8, ErrorMessage = "min: {1}; max: {2}")]
        public int RoomCapacity { get; set; }

        [Required(ErrorMessage = "Is required !!!")]
        public string RoomDescription { get; set; }
        public bool IsActive { get; set; }

        public List<SelectListItem> lobs { get; set; }
        public List<SelectListItem> lort { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}