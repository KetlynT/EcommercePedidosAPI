using EcommercePedidosAPI.Enums;

namespace EcommercePedidosAPI.Models.State
{
    public class Pago : IState
    {
        public StateType Tipo => StateType.Pago;

        public void Pagar(Pedido pedido)
        {
            throw new InvalidOperationException("Pedido já está pago.");
        }

        public void Enviar(Pedido pedido)
        {
            pedido.DefinirEstado(new Enviado());
        }

        public void Cancelar(Pedido pedido)
        {
            throw new InvalidOperationException("Pedido pago não pode ser cancelado.");
        }
    }
}
