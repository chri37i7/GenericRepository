using GenericRepository.Tester.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericRepository.Tester.DataAccess
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected NorthwindDbContext context;

        public RepositoryBase(NorthwindDbContext context)
        {
            Context = context;
        }

        public virtual NorthwindDbContext Context
        {
            get
            {
                return context;
            }
            protected set
            {
                context = value;
            }
        }

        public virtual void Add(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public virtual void Delete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual T GetBy(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual void Update(T t)
        {
            context.SaveChanges();
        }
    }

    public class OrderRepository: RepositoryBase<Order>
    {
        public OrderRepository(NorthwindDbContext context) : base(context) { }

        public new Order GetBy(int id)
        {
            return context.Orders.Where(o => o.OrderId == id)
                .Include("Customer")
                .FirstOrDefault();
        }
    }
}