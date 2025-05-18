/* PARA CRIAR NOVA OPÇÃO DE FRETE, BASTA USAR O TEMPLATE ABAIXO, COLOCANDO UM NOME NO LUGAR DO TERMO "TEMPLATE" E O PERCENTUAL DE FRETE NO LUGAR DE 0.10m (inserir de forma decimal)
 * 
 * 
namespace EcommercePedidosAPI.Models.Frete
{
    public class FreteTemplate : IFreteStrategy
    {
        public decimal Calcular(decimal valorPedido) => valorPedido * 0.10m;
    }
}
*/