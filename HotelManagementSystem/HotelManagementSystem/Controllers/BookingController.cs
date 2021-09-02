using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.Models;
using HotelManagementSystem.ViewModel;

namespace HotelManagementSystem.Controllers
{
    public class BookingController : Controller
    {
        HotelDBEntities db = new HotelDBEntities();
        // GET: Booking
        public ActionResult Index()
        {

            BookingViewModel bookingViewModel = new BookingViewModel();
            bookingViewModel.lors = (
                    from objRoom in db.Rooms
                    where objRoom.BookingStatusID == 2 && objRoom.IsActive == true
                    select new SelectListItem()
                    {
                        Text = objRoom.RoomNumber,
                        Value = objRoom.ID.ToString()
                    }
                ).ToList();
            bookingViewModel.BookingFrom = DateTime.Now;
            bookingViewModel.BookingTo = DateTime.Now.AddDays(1);
            return View(bookingViewModel);
        }

        [HttpPost]
        public ActionResult Index(BookingViewModel bookingViewModel)
        {
            int nod = Convert.ToInt32((bookingViewModel.BookingTo - bookingViewModel.BookingFrom).TotalDays);
            Room room = db.Rooms.FirstOrDefault(x => x.ID == bookingViewModel.AssignRoomID);
            decimal roomprice = room.RoomPrice;
            decimal totalprice = roomprice * nod;

            RoomBooking roomBooking = new RoomBooking();
            roomBooking.CustomerName = bookingViewModel.CustomerName;
            roomBooking.CustomerPhone = bookingViewModel.CustomerPhone;
            roomBooking.CustomerAddress = bookingViewModel.CustomerAddress;
            roomBooking.NoOfMembers = bookingViewModel.NoOfMembers;
            roomBooking.BookingFrom = bookingViewModel.BookingFrom;
            roomBooking.BookingTo = bookingViewModel.BookingTo;
            roomBooking.AssignRoomID = bookingViewModel.AssignRoomID;
            roomBooking.TotalAmount = totalprice;
            db.RoomBookings.Add(roomBooking);
            db.SaveChanges();

            return Json(new { message = "successfully !!!", data = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult GetAllRoomBooking()
        {
            List<RoomBookingViewModel> listOfRoomBooking = (
                    from objRoomBooking in db.RoomBookings
                    join objRoom in db.Rooms on objRoomBooking.AssignRoomID equals objRoom.ID
                    orderby objRoomBooking.ID descending
                    select new RoomBookingViewModel()
                    {
                        CustomerName = objRoomBooking.CustomerName,
                        CustomerAddress = objRoomBooking.CustomerAddress,
                        CustomerPhone = objRoomBooking.CustomerPhone,
                        BookingFrom = objRoomBooking.BookingFrom,
                        BookingTo = objRoomBooking.BookingTo,
                        AssignRoom = objRoom.RoomNumber,
                        TotalAmount = objRoomBooking.TotalAmount,
                        NoOfMembers = objRoomBooking.NoOfMembers,
                        NoOfDays = System.Data.Entity.DbFunctions.DiffDays(objRoomBooking.BookingFrom, objRoomBooking.BookingTo).Value,
                        ID = objRoomBooking.ID,
                        RoomPrice = objRoom.RoomPrice,
                    }
                ).ToList();
            return PartialView("_BookingHistoryPartial", listOfRoomBooking);
        }

        [HttpGet]
        public ActionResult DeleteRoomBookingDetails(int id)
        {
            var result = db.RoomBookings.FirstOrDefault(x => x.ID == id);
            db.RoomBookings.Remove(result);
            db.SaveChanges();
            return Json(new { message = "Deleted Successfully !!!", data = true }, JsonRequestBehavior.AllowGet);
        }

    }
}
