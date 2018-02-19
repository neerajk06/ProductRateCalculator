using RateCalculatorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculatorBAL
{
   public class ProductDetailBAL : IProductDetailBAL
    {
        private readonly IProductRepository _productRepository;
        public ProductDetailBAL(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<ProductEntityBAL> GetAllProducts()
        {
            var productList = _productRepository.GetAllProducts();
            var prodList = new List<ProductEntityBAL>();
            productList.ToList().ForEach(x => {
                var p = new ProductEntityBAL
                {
                    ProductName = x.ProductName,
                    ProgramName = x.ProgramName,
                    ProductRate = x.ProductRate,
                    ProgramRate = x.ProgramRate,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                };
                prodList.Add(p);
            });
            return prodList;
        }
        public ProductEntityBAL GetLowerestProductRate(int ProductId, int ProgramId, DateTime StartDate, DateTime EndtDate)
        {
            var prodList = new List<ProductEntityBAL>();
            try
            {
                var productList = _productRepository.GetLowerestProductRate(ProductId, ProgramId, StartDate, EndtDate);
                productList.ToList().ForEach(x => {
                    var p = new ProductEntityBAL
                    {
                        ProductName = x.ProductName,
                        ProgramName = x.ProgramName,
                        ProductRate = x.ProductRate,
                        ProgramRate = x.ProgramRate,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate
                    };
                    prodList.Add(p);
                });
                if (productList.Any())
                {
                    var product = _calculateRate(prodList);
                    return product;
                }
            }
            catch
            {
                throw;
            }
            
            return null;
        }

        private ProductEntityBAL _calculateRate(List<ProductEntityBAL> productList)
        {
            productList.ToList().ForEach(x =>
            {
                var rate = x.ProductRate + x.ProgramRate;
                x.LowerstProductRate = Math.Round(rate,2);
            });
            var productDetail = productList.Select(x => x).OrderBy(x => x.LowerstProductRate).FirstOrDefault();
            return productDetail;
        }
    }
}
