using dxcBookVehicleParkingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxcBookVehicleParkingService.Interfaces
{
   
        public interface IBooking
        {
            List<Booking> GetBookings();
            Booking GetBooking(int id);
            void AddBooking(Booking booking);
            void DeleteBooking(int id);
            void EditBooking(int id, Booking booking);
        }
    }

