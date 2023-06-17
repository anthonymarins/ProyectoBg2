using ApiBalance.Data;
using ApiBalance.Modelo;
using ApiBalance.Repositorios.Irepositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiBalance.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly BGContext _db;
        internal DbSet<T> _dbSet;

        public Repositorio(BGContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await Save();
        }

        public async Task<T> Get(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter!= null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
