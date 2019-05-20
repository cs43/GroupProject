using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DXCParkingVehicels.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "please enter employee ID")]
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "please enter FirstName")]
        [DisplayName("First Name")]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "please enter LastName")]
        [DisplayName("Last Name")]
        public string EmployeeLastName { get; set; }

        [Required(ErrorMessage = "please Enter Male/Female")]
            [DisplayName("Male/Female")]
        public string EmployeeGender { get; set; }

        [Required(ErrorMessage = "Please Enter Vehicle Number")]
        [DisplayName("Vehicle Number")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Employee office Address is Required")]
        [DisplayName("Employee Address")]      
        public string EmployeeOfficeAddrs { get; set; }

        [Required(ErrorMessage = "Employee Mobile.No is Required")]
        public string EmployeeMobileNo { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        [Required]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Employee UserName is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "please conform your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}