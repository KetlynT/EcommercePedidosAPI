using EcommercePedidosAPI.Enums;

namespace EcommercePedidosAPI.Models.State
{
    public interface IState
    {
        void Pagar(Pedido pedido);
        void Enviar(Pedido pedido);
        void Cancelar(Pedido pedido);
        StateType Tipo { get; }
    }
}


