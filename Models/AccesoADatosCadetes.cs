using System;
using System.Text.Json;
using EspacioCadete;


namespace EspacioAccesoADatosCadetes
{
    class AccesoADatosCadetes
    {
        public List<Cadete> Obtener()
        {
            string archivo = "Archivos/Cadetes.json";
            List<Cadete> listaCadetesJson = new();
            string textoJson = File.ReadAllText(archivo);
            listaCadetesJson = JsonSerializer.Deserialize<List<Cadete>>(textoJson);

            return listaCadetesJson;
            
        }
    }
}