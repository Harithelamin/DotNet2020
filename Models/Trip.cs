using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.Models
{
    public partial class Trip
    {
        public int TripID { get; set; }
        [Column(TypeName = "date")]
        public DateTime TripDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime TripTime { get; set; }
        public String Departure { get; set; }
        public String Arrival { get; set; }

        //internal List<TripVM> ToList()        {            throw new NotImplementedException();        }

        public float AdultPrice { get; set; }
        public float StudentPrice { get; set; }
        public float ChildPrice { get; set; }
        public float SeniorPrice { get; set; }
        [NotMapped]
        public virtual Station DepartureStation { get; set; }
        [NotMapped]
        public virtual Station ArrivalStation { get; set; }
        public virtual List<Bestilling> Bestillings { get; set; }

        //public static implicit operator Trip(List<Trip> v)        {            throw new NotImplementedException();        }
    }
}
