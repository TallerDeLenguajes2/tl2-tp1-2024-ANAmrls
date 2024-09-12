namespace SistemaCadeteria
{
    public class Cliente
    {
        private string _name;
        private string _address;
        private string _phone;
        private string _reference;

        public Cliente(string name, string address, string phone, string reference)
        {
            _name = name;
            _address = address;
            _phone = phone;
            _reference = reference;
        }

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Reference { get => _reference; set => _reference = value; }

        public void MostrarDatos ()
        {
            Console.WriteLine($"Nombre: {this.Name}");
            Console.WriteLine($"Dirección: {this.Address}");
            Console.WriteLine($"Teléfono: {this.Phone}");
            Console.WriteLine($"Referencia: {this.Reference}");
        }
    }
}
