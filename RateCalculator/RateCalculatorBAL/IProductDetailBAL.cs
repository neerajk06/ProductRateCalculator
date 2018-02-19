using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculatorBAL
{
   public interface IProductDetailBAL
    {
        ProductEntityBAL GetLowerestProductRate(int ProductId, int ProgramId, DateTime StartDate, DateTime EndtDate);
        IList<ProductEntityBAL> GetAllProducts();
    }
}
