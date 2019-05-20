using dxcBookVehicleParkingService.Models;
using dxcBookVehicleParkingService.Repo;
using DXCParkingVehicels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXCParkingVehicels.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


          public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
             
            Employee e = new Employee();
            EmployeeRepo employeeRepo = new EmployeeRepo();

            if(employeeRepo.CheckCredentials(loginViewModel.UserName,loginViewModel.Password)==true)
            { 
                Session["UserName"] = e.UserName;               
                return RedirectToAction("Create", "Booking");
            }
            else
            {
                ViewBag.Message = "Invalid UserName or Password";               
                return View("Message");
               
            }
            
        }

    }
}