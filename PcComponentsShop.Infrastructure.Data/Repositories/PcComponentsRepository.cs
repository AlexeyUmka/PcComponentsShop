using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Interfaces.Basic_Interfaces;
using PcComponentsShop.Domain.Interfaces.Extended_Interfaces;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public abstract class PcComponentsRepository<T> : IFilteredPcComponentsRepository<T> where T:Good
    {
        protected PcComponentsShopContext db;
        protected DbSet<T> table;

        public PcComponentsRepository(PcComponentsShopContext context, DbSet<T> table)
        {
            this.db = context;
            this.table = table;
        }
        public virtual void Create(T item)
        {
            table.Add(item);
        }

        public virtual void Delete(int id)
        {
            T item = table.Find(id);
            if (item != null)
                table.Remove(item);
        }

        public virtual T GetElement(int id)
        {
            return table.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table;
        }
        public virtual IEnumerable<Good> GetAll(IPcComponentsRepositoryFilter repositoryFIlter)
        {
            return repositoryFIlter.ExecuteAndReturn(table);
        }

        public virtual void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
