using System;
// using System.IO;
using EspacioCadete;
// using EspacioCadete;
using EspacioCadeteria;


namespace EspacioGestorArchivos
{
    public class GestorArchivos
    {
        Cadeteria traerCadeteriaCSV(string archivo = "")
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
    }
}