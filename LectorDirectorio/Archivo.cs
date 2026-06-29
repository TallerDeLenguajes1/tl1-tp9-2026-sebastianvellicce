using System.IO;
using System.Runtime.CompilerServices;
namespace EspacioArchivo
{
    public static class Archivo
    {
        public static void MostrarArchivos(string ruta)
        {
            string[] archivos = Directory.GetFiles(ruta);

            foreach (string archivo in archivos)
            {
                FileInfo infoArchivo = new FileInfo(archivo);
                double tamanoKbytes = infoArchivo.Length / 1024.0;

                Console.WriteLine($"Nombre: {infoArchivo.Name}  Tamano:{tamanoKbytes} bytes");
            }
        }

        public static void GenerarCSV(string ruta)
        {
            string[] archivos = Directory.GetFiles(ruta);
            string rutaSalida = Path.Combine(ruta, "reporte_archivos.csv");
            List<string> lineas = new List<string>();
            lineas.Add("Nombre, Tamano, Ultima modificacion");
            foreach (string archivoL in archivos)
            {
                FileInfo infoAEscribir = new FileInfo(archivoL);
                double tamanoKbyte = infoAEscribir.Length / 1024.0;
                lineas.Add($"{infoAEscribir.Name}, {tamanoKbyte:F2}KB, {infoAEscribir.LastWriteTime}");
            }
            File.WriteAllLines(rutaSalida, lineas);
        }
    }

}


