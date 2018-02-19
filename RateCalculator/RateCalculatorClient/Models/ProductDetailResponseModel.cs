using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateCalculatorClient.Models
{
    public class ProductDetailResponseModel
    {        
        public string ProductName { get; set; }
        public string ProgramName { get; set; }
        public double LowerestRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
    }
}