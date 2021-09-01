using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.Models;
using HotelManagementSystem.ViewModel;

namespace HotelManagementSystem.Controllers
{
    public class RoomController : Controller
    {
        HotelDBEntities db = new HotelDBEntities();
        // GET: Room
        public ActionResult Index()
        {
            RoomViewModel roomViewModel = new RoomViewModel();
            roomViewModel.lobs = (from obj in db.BookingStatus
                                  select new SelectListItem
                                  {
                                      Text = obj.BookingStatus,
                                      Value = obj.ID.ToString(),
                                  }).ToList();

            roomViewModel.lort = (from obj in db.RoomTypes
                                  select new SelectListItem
                                  {
                                      Text = obj.RoomType1,
                                      Value = obj.ID.ToString(),
                                  }).ToList();

            return View(roomViewModel);
        }

        [HttpPost]
        public ActionResult Index(RoomViewModel obj)
        {
            string a = Guid.NewGuid().ToString();
            string b = a + Path.GetExtension(obj.Image.FileName);

            obj.Image.SaveAs(Server.MapPath("~/RoomImages/" + b));

            Room room = new Room();
            room.RoomNumber = obj.RoomNumber;
            room.RoomPrice = obj.RoomPrice;
            room.RoomCapacity = obj.RoomCapacity;
            room.RoomDescription = obj.RoomDescription;
            room.RoomImage = b;
            room.RoomTypeID = obj.RoomTypeID;
            room.BookingStatusID = obj.BookingStatusID;
            room.IsActive = true;
            db.Rooms.Add(room);
            db.SaveChanges();

            return Json(new { message="Successfully !!!", data = true }, JsonRequestBehavior.AllowGet);       
        }

        public ActionResult GetAllRoom()
        {
            IEnumerable<RoomDetailsViewModel> listOfRoomDetailsViewModel = (
                    from objRoom in db.Rooms 
                    join objBooking in db.BookingStatus on objRoom.BookingStatusID equals objBooking.ID
                    join objRoomType in db.RoomTypes on objRoom.RoomTypeID equals objRoomType.ID
                    select new RoomDetailsViewModel()
                    {
                        RoomNumber = objRoom.RoomNumber,
                        RoomDescription = objRoom.RoomDescription,
                        RoomCapacity = objRoom.RoomCapacity,
                        RoomPrice = objRoom.RoomPrice,
                        BookingStatus = objBooking.BookingStatus,
                        RoomType = objRoomType.RoomType1,
                        RoomImage = objRoom.RoomImage,
                        ID = objRoom.ID,
                    }
                ).ToList();
            return PartialView("_RoomDetailsPartial", listOfRoomDetailsViewModel);
        }
    }
}