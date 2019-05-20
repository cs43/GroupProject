using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxcBookVehicleParkingService.Models
{
    public class Slot
    {
        [Key]
        [Required(ErrorMessage = "please enter Slot Id")]
        public int SlotId { get; set; }

        public string  Area { get; set; }
        
        public int NumberOfSlotsAvailable { get; set; }

        public string Vehicletype { get; set; }
    }
}
