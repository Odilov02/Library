using Application.Abstaction;
using Application.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IAplicationDbContext _db;

        public EmployeeService(IAplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> AddAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddRangeAsync(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}