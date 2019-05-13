using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.Repository
{
    public interface IBaseRepository<T> where T:class
    {
        DbSet<T> Set();
        void Add(T entity);
        void Delete(T entity);
        void Save(T entity);
        Task<T> Find(int id);
        Task<bool> Comit();
        Task<List<T>> ListAll();
    }
}
