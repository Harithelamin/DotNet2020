using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.Models
{
    public class TripVM
    {
        // dette er både en domenemodell og en view-modell
        public int id { get; set; }

        [Display(Name = "TripDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd:mm:yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Trip Date må oppgis")]
        public DateTime tripDate { get; set; }

        [Display(Name = "TripTime")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        //[Column(TypeName = "Time")]
        [Required(ErrorMessage = "Trip Date må oppgis")]
        public DateTime tripTime { get; set; }

        [Display(Name = "Departure")]
        [Required(ErrorMessage = "station Name må oppgis")]
        [RegularExpression(@"^(?!^City$)[a-zA-Z ']+$", ErrorMessage = "station Name må oppgis")]
        public String departure { get; set; }

        [Display(Name = "Arrival")]
        [Required(ErrorMessage = "station Name må oppgis")]
        [RegularExpression(@"^(?!^City$)[a-zA-Z ']+$", ErrorMessage = "station Name må oppgis")]
        public String arrival { get; set; }

        [Display(Name = "AdultPrice")]
        [Required(ErrorMessage = "Price må oppgis")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public float adultPrice { get; set; }

        [Display(Name = "StudentPrice")]
        [Required(ErrorMessage = "Price må oppgis")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public float StudentPrice { get; set; }

        [Display(Name = "ChildPrice")]
        [Required(ErrorMessage = "Price må oppgis")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public float childPrice { get; set; }

        [Display(Name = "SeniorPrice")]
        [Required(ErrorMessage = "Price må oppgis")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public float seniorPrice { get; set; }


        //
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public String StringTripDate { get; set; }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public String StringTripTime { get; set; }
    }
}
