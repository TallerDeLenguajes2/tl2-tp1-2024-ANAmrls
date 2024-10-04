namespace SistemaCadeteria
{
    public class Cliente
    {
        private string _name;
        private string _address;
        private string _phone;
        private string _reference;

        public Cliente()
        {
        }

        public Cliente(string name, string address, string phone, string reference)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Reference = reference;
        }

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Reference { get => _reference; set => _reference = value; }

        public string MostrarNombreCliente() => Name;
        public string MostrarDireccionCliente() => Address;
        public string MostrarTelefonoCliente() => Phone;
        public string MostrarReferenciaCliente() => Reference;
    }
}
