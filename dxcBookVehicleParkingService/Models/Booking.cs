using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxcBookVehicleParkingService.Models
{
    public class Booking
    {
        [Key]
        [Required(ErrorMessage = "please enter Booking Id")]
        public int BookingId { get; set; }

        [Required]
        public int SlotId { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Vehicletype { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime BookStartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime BookEndTime { get; set; }

       
    }
}
