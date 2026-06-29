using System.Text;
using espacioId3v1Tag;

Console.WriteLine("Hello, World!");

string ruta = @"C:\Users\aguss\OneDrive\Escritorio\TP_TALLER_2DOPARCIAL\tl1-tp9-2026-sebastianvellicce\LectorTagMP3\canciones\Queen  Bohemian Rhapsody (Official Video Remastered).mp3";
Encoding enc = Encoding.GetEncoding("latin1");

using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
using (BinaryReader reader = new BinaryReader(fs))
{
    fs.Seek(-128, SeekOrigin.End);  //Nos posicionamos desde el final, 128 bytes para atrás
    Id3v1Tag tag = new Id3v1Tag();

    // Leer cada campo según la estructura del tag
    tag.Header = enc.GetString(reader.ReadBytes(3));
    
    // Validar que sea un tag ID3v1 real
    if (tag.Header != "TAG")
    {
        Console.WriteLine("El archivo no tiene tag ID3v1.");
        return;
    }
    tag.Titulo = enc.GetString(reader.ReadBytes(30)).TrimEnd('\0').Trim();
    tag.Artista = enc.GetString(reader.ReadBytes(30)).TrimEnd('\0').Trim();
    tag.Album = enc.GetString(reader.ReadBytes(30)).TrimEnd('\0').Trim();
    tag.Anio = enc.GetString(reader.ReadBytes(4)).TrimEnd('\0').Trim();


    // Mostrar la información
    Console.WriteLine("Título:  " + tag.Titulo);
    Console.WriteLine("Artista: " + tag.Artista);
    Console.WriteLine("Álbum:   " + tag.Album);
    Console.WriteLine("Año:     " + tag.Anio);
}