using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nikunj_Interview_Cisive.Models
{
    public class CarDetails
    {
        [DisplayName("Car Name")]
        [Required(ErrorMessage = "Please enter car name."), MaxLength(100)]
        public string CarName { get; set; }

        [DisplayName("Car Image")]
        [Required(ErrorMessage = "Please upload car image.")]
        public HttpPostedFileBase CarImageFile { get; set; }
        public string CarImagePath { get; set; }

        [DisplayName("Car Rate(per hour.)")]
        [Required(ErrorMessage = "Please enter car rate.")]
        public float CarRateHourly { get; set; }
        public string CarRegisteredBy { get; set; }

    
    }

    public class Car_Base
    {
        [DisplayName("Car Number")]
        [Required(ErrorMessage = "Please enter car number."), MaxLength(100)]
        public string CarNumber { get; set; }
    }

    public class CarRentingRequest: Car_Base
    {
        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Please enter customer name."), MaxLength(100)]
        public string CustomerName { get; set; }
    }
}