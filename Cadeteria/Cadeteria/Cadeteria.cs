using System.Linq;

namespace SistemaCadeteria
{
    public class Cadeteria
    {
        private const int Jornal = 500;
        private string _name;
        private string _phone;
        private List<Cadete> _cadetes;
        private List<Pedido> _pedidos;
        //private int _jornal;

        public Cadeteria()
        {
        }

        public Cadeteria(string name, string phone)
        {
            Name = name;
            Phone = phone;
            Cadetes = CargarCadetes();
            Pedidos = new List<Pedido>();
        }

        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public List<Pedido> Pedidos { get => _pedidos; set => _pedidos = value; }
        internal List<Cadete> Cadetes { get => _cadetes; set => _cadetes = value; }
        //public int Jornal { get => _jornal; init => _jornal = value; }

        private static List<Cadete> CargarCadetes()
        {
            Console.WriteLine("----- Cargando lista de cadetes... -----");
            string path = "listadoCadetes.csv";

            List<Cadete> cadetes = new();

            try
            {
                var lines = File.ReadAllLines(path);
                
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

            return cadetes;
        }

        public bool AsignarPedido(int idPedido, int idCadete)
        {            
            Cadete? cadete = Cadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedido? pedido = Pedidos.FirstOrDefault(p => p.Number == idPedido);

            if (cadete != null && pedido != null)
            {
                pedido.IdCadete = idCadete;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int JornalACobrar(int idCadete)
        {
            Cadete? cadete = Cadetes.Find(c => c.Id == idCadete);

            if (cadete == null)
            {
                return 0;
            }

            return cadete.OrderCount * Jornal;
        }

        public void AgregarPedido(Pedido pedido) => Pedidos.Add(pedido);

        public bool CambiarEstadoPedido(int nroPedido, Estado nuevoEstado)
        {
            Pedido? pedido = Pedidos.FirstOrDefault(p => p.Number == nroPedido);

            if (pedido == null)
            {
                return false;
            }

            Cadete? cadete = Cadetes.FirstOrDefault(c => c.Id == pedido.IdCadete);

            if (cadete == null)
            {
                return false;
            }

            if (nuevoEstado == Estado.Entregado)
            {
                ++cadete.OrderCount;
            }
 
            pedido.CambiarEstado(nuevoEstado);

            return true;
        }

    }
}
