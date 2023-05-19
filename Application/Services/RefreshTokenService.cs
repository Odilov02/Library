using Application.Abstaction;
using Application.Interfase;
using Domain.Models;
using Domain.Models.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RefreshTokenService:IRefreshTokenService
    {
        private IAplicationDbContext _db;

        public RefreshTokenService(IAplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(RefreshToken entity)
        {
            try
            {
                await _db.RefreshTokens.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<RefreshToken> entities)
        {
            try
            {
                await _db.RefreshTokens.AddRangeAsync(entities);
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
                RefreshToken? entity = await _db.RefreshTokens.FindAsync(id);
                _db.RefreshTokens.Remove(entity!);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<RefreshToken> GetAll()
        {
            try
            {
                IEnumerable<RefreshToken> entities = _db.RefreshTokens;
                return entities;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public async Task<RefreshToken> GetByIdAsync(int id)
        {
            try
            {
                RefreshToken? entity = await _db.RefreshTokens.FindAsync(id);
                return entity!;
            }
            catch (Exception)
            {

                return null!;
            }

        }

        public async Task<bool> UpdateAsync(RefreshToken entity)
        {
            try
            {
                _db.RefreshTokens.Update(entity);
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

