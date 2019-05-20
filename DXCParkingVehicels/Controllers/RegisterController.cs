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
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            Employee emp = new Employee();
            emp.EmployeeId = registerViewModel.EmployeeId;
            emp.EmployeeFirstName = registerViewModel.EmployeeFirstName;
            emp.EmployeeLastName = registerViewModel.EmployeeLastName;
            emp.EmployeeGender = registerViewModel.EmployeeGender;
            emp.EmployeeMobileNo = registerViewModel.EmployeeMobileNo;
            emp.EmployeeEmail = registerViewModel.EmployeeEmail;
            emp.EmployeeOfficeAddrs = registerViewModel.EmployeeOfficeAddrs;
            emp.UserName = registerViewModel.UserName;
            emp.Password = registerViewModel.Password;
            emp.ConfirmPassword = registerViewModel.ConfirmPassword;
            emp.VehicleNumber = registerViewModel.VehicleNumber;


            EmployeeRepo objRepo = new EmployeeRepo();
            objRepo.AddEmployee(emp);
            Session["UserName"] = emp.UserName;


            return RedirectToAction("Create","Booking");
           
        }

        public ViewResult Welcome()
        {
            return View();
        }


    }
}