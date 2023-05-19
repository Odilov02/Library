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
        public async Task<bool> AddAsync(Employee entity)
        {
            try
            {
            await _db.Employees.AddAsync(entity);
            await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<Employee> entity)
        {
            try
            {
                await _db.Employees.AddRangeAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Employee? entity = await _db.Employees.FindAsync(id);
                _db.Employees.Remove(entity!);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                IEnumerable<Employee> entities = _db.Employees;
                return entities;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                Employee? employee = await _db.Employees.FindAsync(id);
                return employee!;
            }
            catch (Exception)
            {

                return null!;
            }

        }

        public async Task<bool> UpdateAsync(Employee entity)
        {
            try
            {
                _db.Employees.Update(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}