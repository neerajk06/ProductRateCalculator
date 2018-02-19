using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RateCalculatorRepository;
using RateCalculatorClient.Controllers;
using RateCalculatorBAL;
using RateCalculatorClient.Models;

namespace RateCalculatorClient.Tests.Controllers
{
    [TestClass]
    public class SearchProductTest
    {
        public  IProductRepository MockProductsRepository;
        public SearchProductTest()
        {
            
           
        }
        [TestMethod]
        public void Product_Rate_Search_when_ProductId_ProgramId_DateRange_Given()
        {
            // Arrange
            IList<ProductDetailsDataEntity> products = new List<ProductDetailsDataEntity>
            {
                new ProductDetailsDataEntity {ProductId=1,ProductName="3 Year Closed",ProductRate=2.7,ProgramId=1,ProgramName="Standard",ProgramRate=-0.05,StartDate=new DateTime(2016,09,01),EndDate=new DateTime(2016,09,14) },
                new ProductDetailsDataEntity {ProductId=1,ProductName="3 Year Closed",ProductRate=2.7,ProgramId=2,ProgramName="Quick Close",ProgramRate=-0.1,StartDate=new DateTime(2016,09,01),EndDate=new DateTime(2016,09,14)  },
                new ProductDetailsDataEntity {ProductId=2,ProductName="5 Year Closed",ProductRate=3.04,ProgramId=1,ProgramName="Standard",ProgramRate=-0.05,StartDate=new DateTime(2016,09,01),EndDate=new DateTime(2016,09,14)  },
                new ProductDetailsDataEntity {ProductId=2,ProductName="5 Year Closed",ProductRate=3.04,ProgramId=2,ProgramName="Quick Close",ProgramRate=-0.1,StartDate=new DateTime(2016,09,01),EndDate=new DateTime(2016,09,14)  },
                new ProductDetailsDataEntity {ProductId=1,ProductName="3 Year Closed",ProductRate=2.8,ProgramId=1,ProgramName="Standard",ProgramRate=-0.15,StartDate=new DateTime(2016,09,01),EndDate=new DateTime(2016,09,14)  }

            };

            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>(); 
            mockProductRepository.Setup(mr => mr.GetLowerestProductRate(1,1, new DateTime(2016, 09, 01), new DateTime(2016, 09, 14))).Returns(products);
            IProductDetailBAL _productDetailBAL = new ProductDetailBAL(mockProductRepository.Object);

            // Act
            var result = _productDetailBAL.GetLowerestProductRate(1,1, new DateTime(2016, 09, 01), new DateTime(2016, 09, 14));

            // Assert
            Assert.IsNotNull(result.ProductRate);
            Assert.AreEqual(2.6, result.LowerstProductRate);
        }
        [TestMethod]
        public void Product_Rate_Search_when_ProductId_ProgramId_DateRange_Invalid_Given()
        {
            // Arrange
            IList<ProductDetailsDataEntity> products = new List<ProductDetailsDataEntity>
            {               

            };

            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(mr => mr.GetLowerestProductRate(1, 1, new DateTime(2016, 09, 01), new DateTime(2016, 09, 14))).Returns(products);
            IProductDetailBAL _productDetailBAL = new ProductDetailBAL(mockProductRepository.Object);

            // Act
            var result = _productDetailBAL.GetLowerestProductRate(1, 1, new DateTime(2016, 09, 01), new DateTime(2016, 09, 14));

            // Assert
            Assert.IsNull(result);
            
        }
    }
}
