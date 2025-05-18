using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EcommercePedidosAPI.Models.Frete
{
    public static class FreteFactory
    {
        private static readonly Dictionary<string, Type> _tipos;

        static FreteFactory()
        {
            _tipos = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    typeof(IFreteStrategy).IsAssignableFrom(t) &&
                    !t.IsInterface && !t.IsAbstract &&
                    t.Name.StartsWith("Frete", StringComparison.OrdinalIgnoreCase))
                .ToDictionary(
                    t => t.Name.Substring("Frete".Length).ToLower(),
                    t => t
                );
        }

        public static IFreteStrategy Obter(string chave)
        {
            if (_tipos.TryGetValue(chave.ToLower(), out var tipo))
            {
                return (IFreteStrategy)Activator.CreateInstance(tipo)!;
            }

            throw new ArgumentException($"Tipo de frete inválido: '{chave}'");
        }

        public static IEnumerable<string> ListarTipos()
        {
            return _tipos.Keys;
        }
    }
}
