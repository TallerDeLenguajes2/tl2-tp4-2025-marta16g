using System;
using System.Text.Json;
using EspacioCadeteria;

namespace EspacioAccesoADatosCadeteria
{
    class AccesoADatosCadeteria
    {
        public Cadeteria Obtener(string archivo)
        {
            Cadeteria cadeteria;
            string textoJson = File.ReadAllText(archivo);
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(textoJson);

            return cadeteria;
        }
    }
}