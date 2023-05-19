using Application.Interface;
using Application.Interfase;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IAuthorBookService, AuthorBookService>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IRefreshTokenService, RefreshTokenService>();
            service.AddScoped<IRoleService, RoleService>();
            service.AddScoped<IRolePermissionService, RolePermissionService>();
            service.AddScoped<IRoleUserService, RoleUserService>();
            service.AddScoped<IPermissionService, PermissionService>();

            return service;
        }
    }
}
