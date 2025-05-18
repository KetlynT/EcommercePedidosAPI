using Microsoft.AspNetCore.Mvc;
using EcommercePedidosAPI.Models;
using EcommercePedidosAPI.Models.Frete;
using EcommercePedidosAPI.Services;
using System.Threading.Tasks;
using System.Linq;

namespace EcommercePedidosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("tipos-frete")]
        public IActionResult ListarTiposDeFrete()
        {
            var tipos = FreteFactory.ListarTipos();
            return Ok(tipos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido(decimal valor, string tipoFrete)
        {
            IFreteStrategy freteStrategy = FreteFactory.Obter(tipoFrete);

            var pedido = new Pedido
            {
                Valor = valor,
                TipoFrete = tipoFrete,
                ValorFrete = freteStrategy.Calcular(valor)
            };

            var pedidoCriado = await _pedidoService.CriarAsync(pedido);

            return Ok(new
            {
                id = pedidoCriado.Id,
                valor = pedidoCriado.Valor,
                TipoFrete = pedidoCriado.TipoFrete,
                frete = pedidoCriado.ValorFrete,
                status = pedidoCriado.Status
            });
        }

        [HttpGet]
        public async Task<IActionResult> ListarPedidos()
        {
            var pedidos = await _pedidoService.ObterTodosAsync();

            var resultado = pedidos.Select(p => new
            {
                id = p.Id,
                status = p.Status,
                valor = p.Valor,
                tipoFrete = p.TipoFrete,
                valorFrete = p.ValorFrete
            });

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedido(int id)
        {
            var pedido = await _pedidoService.ObterPorIdAsync(id);
            if (pedido == null)
                return NotFound(new { mensagem = "Pedido não encontrado." });

            return Ok(new
            {
                id = pedido.Id,
                status = pedido.Status,
                valor = pedido.Valor,
                tipoFrete = pedido.TipoFrete,
                valorFrete = pedido.ValorFrete
            });
        }

        [HttpPut("{id}/pagar")]
        public async Task<IActionResult> PagarPedido(int id)
        {
            try
            {
                var pedido = await _pedidoService.ObterPorIdAsync(id);
                if (pedido == null)
                    return NotFound(new { mensagem = "Pedido não encontrado." });

                pedido.Pagar();
                await _pedidoService.AtualizarAsync(pedido);

                return Ok(new
                {
                    mensagem = "Pedido foi pago.",
                    status = pedido.Status
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}/enviar")]
        public async Task<IActionResult> EnviarPedido(int id)
        {
            try
            {
                var pedido = await _pedidoService.ObterPorIdAsync(id);
                if (pedido == null)
                    return NotFound(new { mensagem = "Pedido não encontrado." });

                pedido.Enviar();
                await _pedidoService.AtualizarAsync(pedido);

                return Ok(new
                {
                    mensagem = "Pedido enviado.",
                    status = pedido.Status
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}/cancelar")]
        public async Task<IActionResult> CancelarPedido(int id)
        {
            try
            {
                var pedido = await _pedidoService.ObterPorIdAsync(id);
                if (pedido == null)
                    return NotFound(new { mensagem = "Pedido não encontrado." });

                pedido.Cancelar();
                await _pedidoService.AtualizarAsync(pedido);

                return Ok(new
                {
                    mensagem = "Pedido cancelado.",
                    status = pedido.Status
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}