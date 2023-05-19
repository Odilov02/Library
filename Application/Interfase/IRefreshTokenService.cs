using Application.Interface;
using Domain.Models.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfase
{
    public interface IRefreshTokenService:IRepository<RefreshToken>
    {
    }
}
