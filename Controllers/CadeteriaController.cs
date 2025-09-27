using System;
using System.Security.Authentication.ExtendedProtection;
using EspacioAccesoADatosCadeteria;
using EspacioAccesoADatosCadetes;
using EspacioAccesoADatosPedidos;
using EspacioCadete;
using EspacioCadeteria;
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

            miCadeteria = ADCadeteria.Obtener();
            miCadeteria.AgregarListaCadetes(ADCadetes.Obtener());
            miCadeteria.AgregarListaPedidos(ADPedidos.Obtener());
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
            //Agregado del guardar en json
            ADPedidos.Guardar(miCadeteria.TraerListaPedidos());

            return Created($"api/cadeteria/AgregarPedido/{pedido.Nro}", pedido);
        }

        [HttpPut("AsignarPedido")]
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            bool exito = miCadeteria.AsignarCadeteAPedido(idPedido, idCadete);
            if (exito)
            {
                //Agregado del guardar en json
                ADPedidos.Guardar(miCadeteria.TraerListaPedidos());

                return Ok($"Cadete {idCadete} asignado al pedido {idPedido} ");
            }
            else
            {
                return BadRequest();  
            }
        }

        [HttpPut("CambiarEstadoPedido")]
        public IActionResult CambiarEstadoPedido(int idPedido, int nuevoEstado)
        {

            bool exito = miCadeteria.CambiarEstadoPedido(idPedido, nuevoEstado);
            //Agregado del guardar en json
            ADPedidos.Guardar(miCadeteria.TraerListaPedidos());

            return Ok($"El pedido {idPedido} pasó a estado {(EnumEstado)nuevoEstado}");

        }

        [HttpPut("CambiarCadetePedido")]
        public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            bool exito = miCadeteria.ReasignarCadeteAPedido(idPedido, idNuevoCadete);
            //Agregado del guardar en json
            ADPedidos.Guardar(miCadeteria.TraerListaPedidos());
            return Ok($"Pedido Número {idPedido} reasignado a cadete {idNuevoCadete}");
        }
    }

}