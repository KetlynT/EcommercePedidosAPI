namespace EcommercePedidosAPI.Models.Frete
{
    public interface IFreteStrategy
    {
        decimal Calcular(decimal valorPedido);
    }
}
