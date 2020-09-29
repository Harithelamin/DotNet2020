using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ITPE3200_1_20H_nor_way.Models
{
    public class BestillingVM
    {
        // dette er både en domenemodell og en view-modell
        public int id { get; set; }
        public int tripId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Trip Date must be entered")]
        public DateTime Date { get; set; }

        [Display(Name = "NumberOfAdults")]
        [Range(0, 20)]
        [Required(ErrorMessage = "number of passengers shoud be between 0 and 20")]
        public int numberOfAdults { get; set; }

        [Display(Name = "NumberOfStudents")]
        [Range(0, 20)]
        [Required(ErrorMessage = "number of passengers shoud be between 0 and 20")]
        public int numberOfStudents { get; set; }

        [Display(Name = "NumberOfKids")]
        [Range(0, 20)]
        [Required(ErrorMessage = "number of passengers shoud be between 0 and 20")]
        public int numberOfKids { get; set; }

        [Display(Name = "NumberOfSeniors")]
        [Range(0, 20)]
        [Required(ErrorMessage = "number of passengers shoud be between 0 and 20")]
        public int numberOfSeniors { get; set; }

        [Display(Name = "I am in")]
        public int departure { get; set; }
        [NotMapped]
        public IList<SelectListItem> AvailableDeparture { get; set; }

        [Display(Name = "And Going To")]
        public int arrival { get; set; }
        [NotMapped]
        public IList<SelectListItem> AvailableArrival { get; set; }

        [NotMapped]
        [Display(Name = "My Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:mm:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime selectedDate { get; set; }


        [NotMapped]
        [Display(Name = "And MyTime")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime selectedTime { get; set; }


        //betaling steps
        public float totalPrice { get; set; }
        public int kontoNo { get; set; }
        public int pinKode { get; set; }
        public String mobilNo { get; set; }


        public BestillingVM()
        {
            AvailableDeparture = new List<SelectListItem>();
            AvailableArrival = new List<SelectListItem>();
        }
    }
}

