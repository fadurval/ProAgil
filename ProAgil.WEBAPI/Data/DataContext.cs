using Microsoft.EntityFrameworkCore;
using ProAgil.WEBAPI.Model;

namespace ProAgil.WEBAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Evento> Eventos { get; set; }
    }
}