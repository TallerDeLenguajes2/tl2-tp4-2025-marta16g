using System;
// using System.IO;
using EspacioCadete;
// using EspacioCadete;
using EspacioCadeteria;


namespace EspacioGestorArchivos
{
    public class GestorArchivos
    {
        public static Cadeteria TraerCadeteriaCSV(string archivo = "")
        {
            Cadeteria cadeteria = new("Pepe's Cadetería", "Avenida Belgrano 3425", 4391541, "Alfredo Navarro");
            if (archivo.Length > 0)
            {
                var lineas = File.ReadAllLines(archivo);
                foreach (var linea in lineas)
                {
                    var partes = linea.Split(",");
                    if (partes.Length == 4 && ulong.TryParse(partes[2], out ulong telefono))
                    {
                        cadeteria.Nombre = partes[0];
                        cadeteria.Direccion = partes[1];
                        cadeteria.Telefono = telefono;
                        cadeteria.Titular = partes[3];
                    }
                }
            }
            return cadeteria;
        }

        public static List<Cadete> TraerCadetesCSV(string archivo, Cadeteria cadeteria)
        {
            List<Cadete> cadetes = new();

            var lineas = File.ReadAllLines(archivo);
            foreach (var linea in lineas)
            {
                var partes = linea.Split(",");
                bool parseId = int.TryParse(partes[0], out int id);
                bool parseTelefono = ulong.TryParse(partes[4], out ulong telefono);
                if (partes.Length == 5 && parseId && cadetes.Exists(c => c.Id == id) && parseTelefono)
                {
                    Cadete cadete = new(id, partes[1], partes[2], partes[3], telefono);
                    cadetes.Add(cadete);
                }
            }

            return cadetes;
        }

    }
}