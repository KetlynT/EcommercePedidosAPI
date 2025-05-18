using EcommercePedidosAPI.Enums;
using EcommercePedidosAPI.Models.State;

namespace EcommercePedidosAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string TipoFrete { get; set; }
        public decimal ValorFrete { get; set; }

        public StateType Status { get; private set; }

        private IState _state;

        public Pedido()
        {
            DefinirEstado(new AguardandoPagamento());
        }

        internal void DefinirEstado(IState novoEstado)
        {
            _state = novoEstado;
            Status = _state.Tipo;
        }

        public void RestaurarEstado()
        {
            _state = Status switch
            {
                StateType.AguardandoPagamento => new AguardandoPagamento(),
                StateType.Pago => new Pago(),
                StateType.Enviado => new Enviado(),
                StateType.Cancelado => new Cancelado(),
                _ => throw new InvalidOperationException("Estado inválido.")
            };
        }

        public void Pagar() => _state.Pagar(this);
        public void Enviar() => _state.Enviar(this);
        public void Cancelar() => _state.Cancelar(this);
    }
}
