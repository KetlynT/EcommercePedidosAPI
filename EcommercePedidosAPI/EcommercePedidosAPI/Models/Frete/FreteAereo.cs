namespace EcommercePedidosAPI.Models.Frete
{
    public class FreteAereo : IFreteStrategy
    {
        public decimal Calcular(decimal valorPedido) => valorPedido * 0.10m;
    }
}
