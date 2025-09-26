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
            Pedido pedido1 = new(3, "Traer vuelto de $10mil", EnumEstado.EnProceso, "Paula Navarro", "Bolivar 543", 38170000, "Departamento 8D");
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
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            miCadeteria.AsignarCadeteAPedido(idPedido, idCadete);
            return Ok($"Cadete {idCadete} asignado al pedido {idPedido} ");
        }

        [HttpPut("CambiarEstadoPedido")]
        public IActionResult CambiarEstadoPedido(int idPedido, int nuevoEstado)
        {

            miCadeteria.CambiarEstadoPedido(idPedido, nuevoEstado);

            return Ok($"El pedido {idPedido} pasó a estado {(EnumEstado)nuevoEstado}");

        }

        [HttpPut("CambiarCadetePedido")]
        public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            miCadeteria.ReasignarCadeteAPedido(idPedido, idNuevoCadete);
            return Ok($"Pedido Número {idPedido} reasignado a cadete {idNuevoCadete}");
        }
    }

}