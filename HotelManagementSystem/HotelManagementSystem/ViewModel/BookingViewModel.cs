using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModel
{
    public class BookingViewModel
    {
        [Required(ErrorMessage = "Is required !!!")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Is required !!!")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "Is required !!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingFrom { get; set; }
        [Required(ErrorMessage = "Is required !!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingTo { get; set; }
        [Required(ErrorMessage = "Is required !!!")]
        public int AssignRoomID { get; set; }
        [Required(ErrorMessage = "Is required !!!")]
        public int NoOfMembers { get; set; }
        [Required(ErrorMessage = "Is required !!!")]
        public string CustomerPhone { get; set; }

        public List<SelectListItem> lors { get; set; }

    }
}