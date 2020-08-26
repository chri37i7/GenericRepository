using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Tester.DataAccess
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();

        T GetBy(int id);

        void Update(T t);
        void Add(T t);
        void Delete(T t);
    }
}