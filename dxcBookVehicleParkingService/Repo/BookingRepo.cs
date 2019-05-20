using dxcBookVehicleParkingService.Interfaces;
using dxcBookVehicleParkingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxcBookVehicleParkingService.Repo
{
    public class BookingRepo:IBooking
    {
        ParkingContext parkingContext = new ParkingContext();
        public void AddBooking(Booking booking)
        {
            parkingContext.Bookings.Add(booking);
            parkingContext.SaveChanges();

        }

        public void DeleteBooking(int id)
        {
            var delbooking = parkingContext.Bookings.Find(id);
            parkingContext.Bookings.Remove(delbooking);
            parkingContext.SaveChanges();
        }

        public void EditBooking(int id, Booking booking)
        {
            var editbooking = parkingContext.Bookings.Find(id);
           
            editbooking.SlotId = booking.SlotId;
            editbooking.BookStartTime = booking.BookStartTime;
            editbooking.BookEndTime = booking.BookEndTime;
            parkingContext.SaveChanges();

        }

        public Booking GetBooking(int id)
        {
            var booking = parkingContext.Bookings.Find(id);
            return booking;
        }

        public List<Booking> GetBookings()
        {
            return parkingContext.Bookings.ToList();
        }

        public List<AreaInfo> GetAreaInfo()
        {
            List<AreaInfo> obj = new List<AreaInfo>();
            List<AreaInfo> AvailAreaInfo = new List<AreaInfo>();
            var d = from n in parkingContext.Slots
                                  select n.Area;
           
            var areas = d.Distinct();

            foreach (var item in areas)
            {
                var bkngs = from b in parkingContext.Bookings
                            where b.Area == item
                            select b;

               
                    var carbkngs = from c in bkngs
                                   where c.Vehicletype.ToUpper() == "CAR"
                                   select c;

                    var bikebkngs = from c in bkngs
                                    where c.Vehicletype.ToUpper() == "BIKE"
                                   select c;

                    obj.Add(new AreaInfo() { Area = item, CarBookings = carbkngs.Count(), BikeBookings = bikebkngs.Count() });
                  
            }
          
            foreach (var item in obj)
            {

                var tcars = from n in parkingContext.Slots
                            where n.Area.ToUpper() == item.Area.ToUpper() &&
                            n.Vehicletype.ToUpper() == "CAR"
                            select n;

                var tbikes= from n in parkingContext.Slots
                            where n.Area.ToUpper() == item.Area.ToUpper() &&
                            n.Vehicletype.ToUpper() == "BIKE"
                            select n;

                int tcarsinslots = tcars.Sum<Slot>(n => n.NumberOfSlotsAvailable);
                int availcarslots = tcarsinslots - item.CarBookings;
               

                int tbikesinslots = tbikes.Sum<Slot>(n => n.NumberOfSlotsAvailable);
                int availbikeslots = tbikesinslots - item.BikeBookings;
                              
                AvailAreaInfo.Add(new AreaInfo() { Area = item.Area, CarBookings = availcarslots, BikeBookings = availbikeslots });


            }



            return AvailAreaInfo;



                                                                
        }



        public List<AreaInfo> GetAreaInfo1()
        {
            List<AreaInfo> obj = new List<AreaInfo>();
            var d = from n in parkingContext.Bookings
                    select n.Area;


            var areas = d.Distinct();


            foreach (var item in areas)
            {
                var bkngs = from b in parkingContext.Bookings
                            where b.Area == item
                            select b;

               
                var carbkngs = from c in bkngs
                               where c.Vehicletype.ToUpper() == "CAR"
                               select c;

                var bikebkngs = from c in bkngs
                                where c.Vehicletype.ToUpper() == "BIKE"
                                select c;

                obj.Add(new AreaInfo() { Area = item, CarBookings = carbkngs.Count(), BikeBookings = bikebkngs.Count() });

              

            }
           
            return obj;

        }
    }
}
