using Domain.Models;
using Domain.Models.Roles;
using Domain.Models.Token;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstaction
{
    public interface IAplicationDbContext
    {
        public DbSet<Author> Authors { get;}
        public DbSet<AuthorBook> AuthorBooks { get;}
        public DbSet<Book> Books { get;}
        public DbSet<Category> Categories { get;}
        public DbSet<Employee> Employees { get;}
        public DbSet<Users> Users { get;}
        public DbSet<RefreshToken> RefreshTokens { get;}
        public DbSet<Permission> Permissions { get;}
        public DbSet<Role> Roles { get;}
        public DbSet<RolePermission> RolePermissions { get;}

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
