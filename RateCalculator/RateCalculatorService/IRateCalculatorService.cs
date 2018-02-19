
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculatorService
{
    [ServiceContract]
   public interface IRateCalculatorService
    {
        [OperationContract]
        RateCalculatorEntity GetLowerestProductRate(int ProductId, int ProgramId, DateTime StartDate, DateTime EndtDate);
        [OperationContract]
        IList<RateCalculatorEntity> GetAllProducts();
    }
}
