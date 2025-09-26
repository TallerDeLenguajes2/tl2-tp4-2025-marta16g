using System;
using EspacioCadete;
using EspacioCadeteria;
using EspacioGestorArchivos;
using EspacioPedido;
using Microsoft.AspNetCore.Mvc;



namespace EspacioCadeteriaController
{

    [ApiController]
    [Route("api/cadeteria")]
    public class CadeteriaController : ControllerBase
    {
        private static Cadeteria miCadeteria;

        static CadeteriaController()
        {
            miCadeteria = GestorArchivos.TraerCadeteriaCSV("Archivos/Cadeteria.csv");
            miCadeteria.CargarCadetesCSV("Archivos/Cadetes.csv");
            Pedido pedido1 = new(1, "Traer vuelto de $10mil", EnumEstado.EnProceso, "Paula Navarro", "Bolivar 543", 38170000, "Departamento 8D");
            miCadeteria.DarDeAltaPedido(pedido1);
        }

        [HttpGet("Pedidos")]
        public IActionResult GetPedidos()
        {
            return Ok(miCadeteria.TraerListaPedidos());
        }

        [HttpGet("Cadetes")]
        public IActionResult GetCadetes()
        {
            return Ok(miCadeteria.TraerListaCadetes());

        }

        [HttpGet("Informe")]
        public IActionResult GetInforme()
        {
            return Ok(miCadeteria.GenerarInforme());
        }

        [HttpPost("AgregarPedido")]
        public IActionResult AgregarPedido([FromBody] Pedido pedido)
        {
            miCadeteria.DarDeAltaPedido(pedido);
            return Created($"api/cadeteria/AgregarPedido/{pedido.Nro}", pedido);
        }

        [HttpPut("AsignarPedido")]
        public void AsignarPedido(int idPedido, int idCadete)
        {
        }

        [HttpPut("CambiarEstadoPedido")]
        public void CambiarEstadoPedido(int idPedido, int NuevoEstado)
        {
        }

        [HttpPut("CambiarCadetePedido")]
        public void CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
        }
    }

}