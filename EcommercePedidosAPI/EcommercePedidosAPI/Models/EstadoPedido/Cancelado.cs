using EcommercePedidosAPI.Enums;

namespace EcommercePedidosAPI.Models.State
{
    public class Cancelado : IState
    {
        public StateType Tipo => StateType.Cancelado;

        public void Pagar(Pedido pedido)
        {
            throw new InvalidOperationException("Pedido cancelado não pode ser pago.");
        }

        public void Enviar(Pedido pedido)
        {
            throw new InvalidOperationException("Pedido cancelado não pode ser enviado.");
        }

        public void Cancelar(Pedido pedido)
        {
            throw new InvalidOperationException("Pedido já está cancelado.");
        }
    }
}
