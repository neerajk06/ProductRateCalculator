using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using RateCalculatorClient.Models;
using RateCalculatorBAL;
using RateCalculatorClient.RateCalService;

namespace RateCalculatorClient.Controllers
{
    public class ProductSearchController : Controller
    {
        private readonly IProductDetailBAL _productDetailBAL;
        public ProductSearchController(IProductDetailBAL productDetailBAL)
        {
           // _productDetailBAL = productDetailBAL;
        }
        // GET: ProductSearch
        public ActionResult ProductSearch()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ProductSearch(ProductDetailRequestModel model, string returnUrl)
        {
            model.ProductId = Convert.ToInt32(Request.Form["ProductDropDown"]);
            model.ProgramId = Convert.ToInt32(Request.Form["ProgramDropDown"]);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Calling WCF service. 
            RateCalculatorServiceClient proxy = new RateCalculatorServiceClient();
            var res = new ProductDetailResponseModel();
            try
            {
                var result = proxy.GetLowerestProductRate(model.ProductId, model.ProgramId, model.StartDate, model.EndtDate);

                // calling directly from UI without wcf service layer. working fine.
                //var result = _productDetailBAL.GetLowerestProductRate(model.ProductId, model.ProgramId, model.StartDate, model.EndtDate);
                ViewBag.showResult = result != null ? true : false;
                
                if (ViewBag.showResult)
                {
                    res.ProductName = result.ProductName;
                    res.ProgramName = result.ProgramName;
                    res.LowerestRate = result.LowerstProductRate;
                    res.StartDate = result.StartDate;
                    res.EndtDate = result.EndDate;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                proxy.Close();
            }           
           
           
            return View("_SearchResults", res);
        }
    }
}