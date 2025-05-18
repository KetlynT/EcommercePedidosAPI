using EcommercePedidosAPI.Data;
using EcommercePedidosAPI.Models;
using EcommercePedidosAPI.Models.Frete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EcommercePedidosAPI.Services
{
    public class PedidoService
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> CriarAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<List<Pedido>> ObterTodosAsync()
        {
            var pedidos = await _context.Pedidos.ToListAsync();
            foreach (var p in pedidos)
            {
                p.RestaurarEstado();
            }
            return pedidos;
        }


        public async Task<Pedido?> ObterPorIdAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            pedido?.RestaurarEstado();
            return pedido;
        }


        public async Task AtualizarAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
