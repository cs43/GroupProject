using dxcBookVehicleParkingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxcBookVehicleParkingService.Interfaces
{
    public interface ISlot
    {
        List<Slot> GetSlots();
        Slot GetSlot(int id);
        void AddSlot(Slot slot);
        void DeleteSlot(int id);
        void EditSlot(int id, Slot slot);
    }
}
