using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IQueryable<T> entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

    }
}

