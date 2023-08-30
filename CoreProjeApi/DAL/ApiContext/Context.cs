using CoreProjeApi.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreProjeApi.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-4QIIH5S; database=CoreProjeApiDB; integrated security=true");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
