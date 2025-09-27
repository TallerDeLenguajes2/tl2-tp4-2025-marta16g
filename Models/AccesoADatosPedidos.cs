using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using EspacioPedido;

namespace EspacioAccesoADatosPedidos
{
    class AccesoADatosPedidos()
    {
        public List<Pedido> Obtener()
        {
            string archivo = "Archivos/Pedidos.json";
            List<Pedido> listaPedidosJson = new();
            string textoJson = File.ReadAllText(archivo);
            listaPedidosJson = JsonSerializer.Deserialize<List<Pedido>>(textoJson);

            return listaPedidosJson;
        }

        public void Guardar(List<Pedido> pedidos)
        {
            string textoJson = JsonSerializer.Serialize(pedidos);
            string Archivo = "Archivos/Pedidos.json";

            File.WriteAllText(Archivo, textoJson);
        }
    }
}