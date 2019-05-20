using dxcBookVehicleParkingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxcBookVehicleParkingService.Interfaces
{
   public interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void AddEmployee(Employee e);
        void DeleteEmployee(int id);
        void EditEmployee(int id, Employee e);
    }
}
