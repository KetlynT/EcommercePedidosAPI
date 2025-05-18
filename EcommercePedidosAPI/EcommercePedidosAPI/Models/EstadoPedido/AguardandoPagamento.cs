using EcommercePedidosAPI.Enums;

namespace EcommercePedidosAPI.Models.State
{
    public class AguardandoPagamento : IState
    {
        public StateType Tipo => StateType.AguardandoPagamento;

        public void Pagar(Pedido pedido)
        {
            pedido.DefinirEstado(new Pago());
        }

        public void Enviar(Pedido pedido)
        {
            throw new InvalidOperationException("O pedido precisa estar pago antes de ser enviado.");
        }

        public void Cancelar(Pedido pedido)
        {
            pedido.DefinirEstado(new Cancelado());
        }
    }
}
