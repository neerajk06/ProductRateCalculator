using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculatorRepository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository() : base(new MainDbContext())
        { }
        public IList<ProductDetailsDataEntity> GetLowerestProductRate(int ProductId, int ProgramId, DateTime StartDate, DateTime EndtDate)
        {
            var returnValue = new List<ProductDetailsDataEntity>();
            try {
                
                IQueryable<ProductDetailsDataEntity> query = _dbContext.Set<ProductDetailsDataEntity>();
                if (ProductId > 0)
                    query = query.Where(p => p.ProductId == ProductId);

                if (ProgramId > 0)
                    query = query.Where(p => p.ProgramId == ProgramId);

                query = query.Where(c => c.StartDate >= StartDate && c.EndDate <= EndtDate);
                query.ToList().ForEach(product =>
                {
                    var p = new ProductDetailsDataEntity
                    {
                        ProductName = product.ProductName,
                        ProgramName = product.ProgramName,
                        ProductRate = product.ProductRate,
                        ProgramRate = product.ProgramRate,
                        StartDate = product.StartDate,
                        EndDate = product.EndDate
                    };
                    returnValue.Add(p);
                });
                return returnValue;

            }
            catch {
                throw;               
            }
            
        }

       public IList<ProductDetailsDataEntity> GetAllProducts()
        {
          return  _dbContext.Set<ProductDetailsDataEntity>().ToList();
        }

    }
}
