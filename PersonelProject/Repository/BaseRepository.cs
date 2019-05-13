using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonelProject.Data;

namespace PersonelProject.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private PersonelContext _db;
        public BaseRepository(PersonelContext db)
        {
            _db = db;
        }
        public void Add(T entity)
        {
            _db.Entry(entity).State = EntityState.Added;
        }

        public async Task<bool> Comit()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public void Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<T> Find(int id)
        {
            return await Set().FindAsync(id);
        }

        public async Task<List<T>> ListAll()
        {
            return await Set().ToListAsync();
        }

        public void Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }
    }
}
