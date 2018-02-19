using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateCalculatorClient.Models
{
    public class ProductDetailRequestModel
    {
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [Display(Name = "Program")]
        public int ProgramId { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndtDate { get; set; }
    }
}