using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopGenericRepository.Models;

namespace CoffeeShopGenericRepository.GenericRepository
{
    public class UnitOfWork : IDisposable
    {
        private CoffeeDBEntities context = new CoffeeDBEntities();

        private GenericRepository<CustomerInfo> customerInfoRepository;

        public GenericRepository<CustomerInfo> CustomerInfoRepository
        {
            get
            {

                if (this.customerInfoRepository == null)
                {
                    this.customerInfoRepository = new GenericRepository<CustomerInfo>(context);
                }
                return customerInfoRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
