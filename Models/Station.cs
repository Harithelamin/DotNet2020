using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.Models
{
    public partial class Station
    {
        public int StationID { get; set; }
        public String StationName { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual List<Trip> Trips { get; set; }
    }
}
