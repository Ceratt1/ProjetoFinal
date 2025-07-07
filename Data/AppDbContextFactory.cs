using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjetoFinal.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql("Server=localhost;Database=projetofinal;Uid=root;Pwd=;", 
                ServerVersion.AutoDetect("Server=localhost;Database=projetofinal;Uid=root;Pwd=;"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}