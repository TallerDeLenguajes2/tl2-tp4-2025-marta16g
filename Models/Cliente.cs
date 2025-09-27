using System;
using System.Text.Json.Serialization;

namespace EspacioCliente
{
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private ulong telefono;
        private string datosReferenciaDireccion;

        [JsonPropertyName("Nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [JsonPropertyName("Direccion")]
        public string Direccion { get => direccion; set => direccion = value; }       
        [JsonPropertyName("Telefono")]
        public ulong Telefono { get => telefono; set => telefono = value; }
        [JsonPropertyName("DatosReferenciaDireccion")]
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        
        public Cliente(string nombre, string direccion, ulong telefono, string datosReferenciaDireccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.datosReferenciaDireccion = datosReferenciaDireccion;
        }

    }

}
