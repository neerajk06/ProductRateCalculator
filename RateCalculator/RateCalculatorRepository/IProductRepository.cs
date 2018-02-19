using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculatorRepository
{
   public interface IProductRepository
    {
        IList<ProductDetailsDataEntity> GetLowerestProductRate(int ProductId, int ProgramId, DateTime StartDate, DateTime EndtDate);

        IList<ProductDetailsDataEntity> GetAllProducts();
    }
}
