using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace RateCalculatorService
{
    [DataContract]
   public class RateCalculatorEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public double ProductRate { get; set; }
        [DataMember]
        public int ProgramId { get; set; }
        [DataMember]
        public double ProgramRate { get; set; }
        [DataMember]
        public string ProgramName { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public double LowerstProductRate { get; set; }
    }
}
