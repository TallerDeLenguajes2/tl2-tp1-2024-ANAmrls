namespace SistemaCadeteria
{
    public class Cadete
    {
        private int _id;
        private string _name;
        private string _address;
        private string _phone;
        private int _orderCount;

        public Cadete(int id, string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            OrderCount = 0;
        }

        public Cadete()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public int OrderCount { get => _orderCount; set => _orderCount = value; }

        public int MostrarIdCadete() => Id;
        public string MostrarNombreCadete() => Name;
        public string MostrarDireccionCadete() => Address;
        public string MostrarTelefonoCadete() => Phone;
        public int MostrarPedidosEntregados() => OrderCount;

    }
}
