using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RateCalculatorRepository
{
    internal sealed class ProductDetailsConfiguration : EntityTypeConfiguration<ProductDetailsDataEntity>
    {
        internal ProductDetailsConfiguration()
        {
            // Table & Column Mappings
            ToTable("ProductDetails", "dbo");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ProductId).HasColumnName("ProductId");
            Property(t => t.ProductName).HasColumnName("ProductName");
            Property(t => t.ProductRate).HasColumnName("ProductRate");
            Property(t => t.ProgramRate).HasColumnName("ProgramRate");
            Property(t => t.StartDate).HasColumnName("StartDate");
            Property(t => t.EndDate).HasColumnName("EndDate");
            Property(t => t.ProgramName).HasColumnName("ProgramName");            
        }
    }
}
