using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DXCParkingVehicels.ViewModels
{
    public class BookingViewModel
    {

        [Key]
        [Required]
        [DisplayName("Enter Bookingid")]
        public int BookingId { get; set; }

        [Required]
        [DisplayName("Enter Userid")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Enter Slotid")]
        public int SlotId { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        [DisplayName("Enter vehicle number")]
        public string VehicleNumber { get; set; }


        [Required]
        public string Vehicletype { get; set; }

        [Required]
        [DisplayName("Enter starting time")]
        [DataType(DataType.Time)]
        public DateTime BookStartTime { get; set; }

        [Required]
        [DisplayName("Enter Ending time")]
        [DataType(DataType.Time)]
        public DateTime BookEndTime { get; set; }

        


    }
}