using Application.Interface;
using Domain.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfase
{
    public interface IRolePermissionService:IRepository<RolePermission>
    {
    }
}
