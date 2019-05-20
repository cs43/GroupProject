using dxcBookVehicleParkingService.Interfaces;
using dxcBookVehicleParkingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxcBookVehicleParkingService.Repo
{
    public class EmployeeRepo : IEmployee
    {
        ParkingContext parkingContext = new ParkingContext();

        public void AddEmployee(Employee employee)
        {

            parkingContext.Employees.Add(employee);
            parkingContext.SaveChanges();

        }

        public void DeleteEmployee(int id)
        {
            var delemp = parkingContext.Employees.Find(id);
            parkingContext.Employees.Remove(delemp);
            parkingContext.SaveChanges();
        }

        public void EditEmployee(int id, Employee employee)
        {
            var editemp = parkingContext.Employees.Find(id);
            editemp.EmployeeFirstName = employee.EmployeeFirstName;
            editemp.EmployeeLastName = employee.EmployeeLastName;
            editemp.EmployeeMobileNo = employee.EmployeeMobileNo;
            editemp.EmployeeOfficeAddrs = employee.EmployeeOfficeAddrs;
            editemp.EmployeeEmail = employee.EmployeeEmail;
            editemp.EmployeeGender = employee.EmployeeGender;
            editemp.Password = employee.Password;
            editemp.UserName = employee.UserName;
            editemp.VehicleNumber = employee.VehicleNumber;
            parkingContext.SaveChanges();

        }

        public List<Employee> GetEmployees()
        {
            return parkingContext.Employees.ToList();

        }

        public Employee GetEmployee(int id)
        {
            var emp = parkingContext.Employees.Find(id);
            return emp;
        }

        public bool CheckCredentials(string username,string password)
        {
            var userrec = (from n in parkingContext.Employees
                           where n.UserName == username && n.Password == password
                           select n).FirstOrDefault();

            if(userrec!=null)
            {
                return true;
            }
            return false;
        }
    }
}
