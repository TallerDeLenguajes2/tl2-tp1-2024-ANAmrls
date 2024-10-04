namespace SistemaCadeteria
{
    public class AccesoADatos
    {
        protected string _filePathCadeteria;
        protected string _filePathCadetes;

        public string FilePathCadeteria { get => _filePathCadeteria; set => _filePathCadeteria = value; }
        public string FilePathCadetes { get => _filePathCadetes; set => _filePathCadetes = value; }

        public AccesoADatos(string filePathCadeteria, string filePathCadetes)
        {
            FilePathCadeteria = filePathCadeteria;
            FilePathCadetes = filePathCadetes;
        }

        public virtual string[]? ReadLinesFromFile(string filePath)
        {
            string[]? lines = null;
            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Carpeta no encontrada: " + e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Archivo no encontrado: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un problema al intentar abrir el archivo: " + e.Message);
            }

            return lines;
        }

        public virtual List<Cadete> CargarCadetes()
        {
            Console.WriteLine("Sobreescribir");
            return new List<Cadete>();
        }

        public virtual Cadeteria CargarDatosCadeteria()
        {
            Console.WriteLine("Sobreescribir");
            return new Cadeteria();
        }

    }
}
