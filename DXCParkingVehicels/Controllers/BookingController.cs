using dxcBookVehicleParkingService.Models;
using dxcBookVehicleParkingService.Repo;
using DXCParkingVehicels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DXCParkingVehicels.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            BookingRepo objbookingrepo = new BookingRepo();
            var x = objbookingrepo.GetAreaInfo();

            return View(x.ToList());
            
        }

        [HttpGet]
        public ActionResult BookSlot(string Area,string type, int SlotId)
        {           
            BookingViewModel  objbooking = new BookingViewModel();            
            objbooking.UserId = 1;
            objbooking.Area = Area;
            objbooking.Vehicletype = type;
            objbooking.SlotId = SlotId;
            return View(objbooking);
        }

        [HttpPost]
        public ActionResult BookSlot(BookingViewModel bookingViewModel)
        {
            Booking booking = new Booking();
            booking.Area = bookingViewModel.Area;
            booking.SlotId = bookingViewModel.SlotId;
            booking.UserId = bookingViewModel.UserId;
            booking.Vehicletype = bookingViewModel.Vehicletype;
            booking.BookStartTime = bookingViewModel.BookStartTime;
            booking.BookEndTime = bookingViewModel.BookEndTime;


            ViewBag.SeletecdArea = booking.Area;
            ViewBag.SelectedSlotId = booking.SlotId;
            ViewBag.SelectedVehicleType = booking.Vehicletype;
            ViewBag.SelectedST = booking.BookStartTime;
            ViewBag.SlectedET = booking.BookEndTime;


            BookingRepo bookingRepo = new BookingRepo();
            bookingRepo.AddBooking(booking);
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.UserName = "babuhari1672@gmail.com";
            WebMail.Password = "Password%25";
            WebMail.From = "babuhari1672@gmail.com";
            WebMail.EnableSsl = true;
            string user = Session["EmailId"].ToString();
            string message = "Hi, " + user + "  Thank you for using DXC Slot Booking App - built by DXCians - Congrats and Your slot is booked with " + bookingViewModel.SlotId;
            WebMail.Send(user, "Parking Slot Confirmation", message);

            return View("DisplayMsg");


        }

        public ViewResult DisplayMsg()
        {
            return View();
        }



        }
}