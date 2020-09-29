using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.Models
{
    public partial  class Bestilling
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfKids { get; set; }
        public int NumberOfSeniors { get; set; }
        public int Departure { get; set; }
        public int Arrival { get; set; }
        public int TripID { get; set; }
        //betaling steps
        public float TotalPrice { get; set; }
        public int KontoNo { get; set; }
        public int PinKode { get; set; }
        public String MobilNo { get; set; }
        public bool HarBetalt { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
