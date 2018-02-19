using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RateCalculatorRepository
{
    public sealed class MainDbContext : DbContext
    {
        public MainDbContext(bool autoDetectChangesEnabled = true,
            bool lazyLoadingEnabled = false,
            bool proxyCreationEnabled = false,
            bool validateOnSaveEnabled = false,
            bool useDatabaseNullSemantics = false)
            : base("name=DefaultConnection")
        {
            Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
            Configuration.UseDatabaseNullSemantics = useDatabaseNullSemantics;
            

        }
        //public DbSet<ProductDetailsDataEntity> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ProductDetailsConfiguration());
            
        }
    }
}
