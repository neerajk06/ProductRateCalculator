using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculatorRepository
{
   public class BaseRepository : IDisposable
    {
        protected MainDbContext _dbContext;

        protected BaseRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }

    }
}
