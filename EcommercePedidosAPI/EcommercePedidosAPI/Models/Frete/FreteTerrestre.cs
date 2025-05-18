namespace EcommercePedidosAPI.Models.Frete
{
    public class FreteTerrestre : IFreteStrategy
    {
        public decimal Calcular(decimal valorPedido) => valorPedido * 0.05m;
    }
}
