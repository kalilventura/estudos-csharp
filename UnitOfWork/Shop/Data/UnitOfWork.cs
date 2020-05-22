using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }

        public void Rollback()
        {
        }
    }

    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
