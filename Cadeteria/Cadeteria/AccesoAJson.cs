using System.Text.Json;

namespace SistemaCadeteria
{
    public class AccesoAJson : AccesoADatos
    {
        public AccesoAJson(string filePathCadeteria, string filePathCadetes) : base(filePathCadeteria, filePathCadetes)
        {
        }

        public override List<Cadete> CargarCadetes()
        {
            return LeerJSON<List<Cadete>>(FilePathCadetes);
        }

        public override Cadeteria CargarDatosCadeteria()
        {
            Cadeteria nuevaCadeteria = LeerJSON<Cadeteria>(FilePathCadeteria);
            nuevaCadeteria.Cadetes = CargarCadetes();
            return nuevaCadeteria;
        }

        public static T LeerJSON<T>(string FilePath)
        {
            T datos = default;
            try
            {
                string texto = File.ReadAllText(FilePath);
                datos = JsonSerializer.Deserialize<T>(texto);
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

            return datos;

        }

    }
}
