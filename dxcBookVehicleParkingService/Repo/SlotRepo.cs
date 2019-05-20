using dxcBookVehicleParkingService.Interfaces;
using dxcBookVehicleParkingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxcBookVehicleParkingService.Repo
{
    public class SlotRepo:ISlot
    {
        ParkingContext parkingContext = new ParkingContext();

        public void AddSlot(Slot slot)
        {
            parkingContext.Slots.Add(slot);
            parkingContext.SaveChanges();


        }

        public void DeleteSlot(int id)
        {
            var delslot = parkingContext.Slots.Find(id);
            parkingContext.Slots.Remove(delslot);
            parkingContext.SaveChanges();
        }

        public List<Slot> GetSlots()
        {
            return parkingContext.Slots.ToList();
        }

        public void EditSlot(int id, Slot slot)
        {
            var editslots = parkingContext.Slots.Find(id);
            editslots.SlotId = slot.SlotId;
            editslots.NumberOfSlotsAvailable = slot.NumberOfSlotsAvailable;
            parkingContext.SaveChanges();

        }

        public Slot GetSlot(int id)
        {
            var slot = parkingContext.Slots.Find(id);
            return slot;
        }
    }
}
