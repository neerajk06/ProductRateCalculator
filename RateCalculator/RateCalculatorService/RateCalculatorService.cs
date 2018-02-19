using RateCalculatorBAL;
using RateCalculatorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace RateCalculatorService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
   public class RateCalculatorService : IRateCalculatorService
    {
        private readonly IProductDetailBAL _productDetailBAL;
        public RateCalculatorService()
        {
            IocContainer();
            _productDetailBAL = container.Resolve<IProductDetailBAL>();
        }

        static IUnityContainer container = new UnityContainer();

        static void IocContainer()
        {
            container.RegisterType<IProductDetailBAL, ProductDetailBAL>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRateCalculatorService, RateCalculatorService>();
        }
        
        public IList<RateCalculatorEntity> GetAllProducts()
        {
            return null;
        }

       public RateCalculatorEntity GetLowerestProductRate(int ProductId, int ProgramId, DateTime StartDate, DateTime EndtDate)
        {
            var returnValue = new RateCalculatorEntity();
            var result = _productDetailBAL.GetLowerestProductRate(ProductId, ProgramId, StartDate, EndtDate);
            if(result!=null)
            {
                returnValue.ProductName = result.ProductName;
                returnValue.ProgramName = result.ProgramName;
                returnValue.LowerstProductRate = result.LowerstProductRate;
                returnValue.StartDate = result.StartDate;
                returnValue.EndDate = result.EndDate;
            }
            return returnValue;
        }
    }
}
