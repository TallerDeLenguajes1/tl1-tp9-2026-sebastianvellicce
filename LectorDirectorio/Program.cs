using System.IO;
using espacioDirectorio;
using EspacioArchivo;
Console.WriteLine("Hello, World!");
string ruta = Directorio.PedirRuta();

Directorio.MostrarDirectorio(ruta);

Archivo.MostrarArchivos(ruta);

Archivo.GenerarCSV(ruta);


