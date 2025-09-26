using System;
using EspacioAccesoADatosCadeteria;
using EspacioAccesoADatosCadetes;
using EspacioAccesoADatosPedidos;
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
        private Cadeteria miCadeteria;
        private AccesoADatosCadeteria ADCadeteria;
        private AccesoADatosCadetes ADCadetes;
        private AccesoADatosPedidos ADPedidos;

        public CadeteriaController()
        {
            ADCadeteria = new();
            ADCadetes = new();
            ADPedidos = new();

            miCadeteria = ADCadeteria.Obtener("Archivos/Cadeteria.json");
            miCadeteria.AgregarListaCadetes(ADCadetes.Obtener("Archivos/Cadetes.json"));
            miCadeteria.AgregarListaPedidos(ADPedidos.Obtener("Archivos/Cadetes.json"));
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