using RateCalculatorBAL;
using RateCalculatorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace RateCalculatorService
{
   public class WcfServiceFactory : Unity.Wcf.UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IProductDetailBAL, ProductDetailBAL>();
            container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
