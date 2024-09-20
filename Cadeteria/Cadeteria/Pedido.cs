namespace SistemaCadeteria
{
    public enum Estado
    {
        Pendiente,
        Entregado,
        Pagado
    }

    public class Pedido
    {
        private int _number;
        private string _obs;
        private Cliente _cliente;
        private Estado _state;
        private int _idCadete;

        public Pedido(int number, string obs, Cliente cliente)
        {
            Number = number;
            Obs = obs;
            Cliente = cliente;
            State = Estado.Pendiente;
            IdCadete = 0;
        }

        public int Number { get => _number; set => _number = value; }
        public string Obs { get => _obs; set => _obs = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public Estado State { get => _state; set => _state = value; }
        public int IdCadete { get => _idCadete; set => _idCadete = value; }

        public void VerDireccionCliente()
        {
            Console.WriteLine($"Dirección del cliente: {Cliente.Address}");
        }

        public void VerDatosCliente()
        {
            Console.WriteLine("Datos del cliente");
            Cliente.MostrarDatos();
        }

        public void CambiarEstado(Estado estado)
        {
            State = estado;
        }
    }
}
