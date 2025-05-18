using Microsoft.EntityFrameworkCore;
using EcommercePedidosAPI.Models;
using System.Collections.Generic;

namespace EcommercePedidosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
