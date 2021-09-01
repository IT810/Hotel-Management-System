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
            return View(bookingViewModel);
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
