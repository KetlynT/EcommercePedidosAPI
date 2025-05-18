using EcommercePedidosAPI.Enums;

namespace EcommercePedidosAPI.Models.State
{
    public class Enviado : IState
    {
        public StateType Tipo => StateType.Enviado;

        public void Pagar(Pedido pedido)
        {
            throw new InvalidOperationException("Pedido já foi enviado.");
        }

        public void Enviar(Pedido pedido)
        {
            throw new InvalidOperationException("Pedido já foi enviado.");
        }

        public void Cancelar(Pedido pedido)
        {
            throw new InvalidOperationException("Pedido enviado não pode ser cancelado.");
        }
    }
}
