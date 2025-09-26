using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using EspacioPedido;

namespace EspacioAccesoADatosPedidos
{
    class AccesoADatosPedidos()
    {
        public List<Pedido> Obtener(string archivo)
        {
            List<Pedido> listaPedidosJson = new();
            string textoJson = File.ReadAllText(archivo);
            listaPedidosJson = JsonSerializer.Deserialize<List<Pedido>>(textoJson);

            return listaPedidosJson;
        }

        public void Guardar(List<Pedido> pedidos)
        {
            string textoJson = JsonSerializer.Serialize(pedidos);
            string miArchivo = "Archivos/Pedidos.json";

            File.WriteAllText(miArchivo, textoJson);
        }
    }
}