namespace SistemaCadeteria
{
    public class AccesoACSV : AccesoADatos
    {
        public AccesoACSV(string filePathCadeteria, string filePathCadetes) : base(filePathCadeteria, filePathCadetes)
        {
        }

        public override List<Cadete> CargarCadetes()
        {
            List<Cadete> cadetes = new();

            string[]? lines = ReadLinesFromFile(FilePathCadetes);

            if (lines == null)
            {
                return cadetes;
            }

            foreach (var line in lines)
            {
                var campos = line.Split(',');

                string id = campos[0];
                string name = campos[1];
                string address = campos[2];
                string phone = campos[3];

                cadetes.Add(new Cadete(int.Parse(id), name, address, phone));
            }
            Console.WriteLine("Listado de cadetes cargado con éxito\n");
            return cadetes;
        }

        public override Cadeteria CargarDatosCadeteria()
        {
            Cadeteria nuevaCadeteria = new();

            string[]? lines = ReadLinesFromFile(FilePathCadeteria);

            if (lines == null)
            {
                return nuevaCadeteria;
            }

            foreach (var line in lines)
            {
                var campos = line.Split(',');

                string nombre = campos[0];
                string telefono = campos[1];

                nuevaCadeteria = new(nombre, telefono);
            }

            nuevaCadeteria.Cadetes = CargarCadetes();

            Console.WriteLine("Datos cargados con éxito\n");
            return nuevaCadeteria;
        }
    }
}
