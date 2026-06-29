namespace espacioDirectorio
{
    public static class Directorio
    {
        public static string PedirRuta()
        {
            string ruta;
            do
            {
                Console.WriteLine("Ingrese la ruta de su directorio\n");
                ruta = Console.ReadLine();
                if (!Directory.Exists(ruta))
                {
                    Console.WriteLine("El directorio ingresado no existe. Ingrese uno existente\n");
                }
            } while (!Directory.Exists(ruta));
            return ruta;
        }

        public static void MostrarDirectorio(string ruta)
        {
            string[] subcarpetas = Directory.GetDirectories(ruta);

            foreach (string carpetas in subcarpetas)
            {
                DirectoryInfo info = new DirectoryInfo(carpetas);
                Console.WriteLine(info.Name);
            }
        }
    }
}