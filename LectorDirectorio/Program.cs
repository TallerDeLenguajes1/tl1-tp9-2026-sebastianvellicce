using System.IO;
Console.WriteLine("Hello, World!");
string ruta;
do
{
    Console.WriteLine("Ingrese la ruta de su directorio\n");
    ruta = Console.ReadLine();
    if(!Directory.Exists(ruta))
    {
        Console.WriteLine("El directorio ingresado no existe. Ingrese uno existente\n");
    }
} while (!Directory.Exists(ruta));

string[] subcarpetas = Directory.GetDirectories(ruta);

foreach (string carpetas in subcarpetas)
{
    DirectoryInfo info = new DirectoryInfo(carpetas);
    Console.WriteLine(info.Name);
}

string[] archivos = Directory.GetFiles(ruta);

// foreach(string archivo in archivos)
// {
//     FileInfo infoArchivo = new FileInfo(archivo);
//     double tamanoKbytes = infoArchivo.Length/1024.0;

//     Console.WriteLine($"Nombre: {infoArchivo.Name}  Tamano:{tamanoKbytes} bytes");
// }
string rutaSalida = @"C:\Users\aguss\OneDrive\Escritorio\TP_TALLER_2DOPARCIAL\tl1-tp9-2026-sebastianvellicce\LectorDirectorio\reporte_archivos.csv" ;
List <string> lineas = new List<string>();
lineas.Add("Nombre, Tamano, Ultima modificacion");
foreach (string archivoL in archivos)
{
    FileInfo infoAEscribir = new FileInfo(archivoL);
    double tamanoKbyte = infoAEscribir.Length/1024.0;
    lineas.Add($"{infoAEscribir.Name}, {tamanoKbyte:F2}KB, {infoAEscribir.LastWriteTime}");
}
File.WriteAllLines(rutaSalida, lineas);