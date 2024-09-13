﻿namespace SistemaCadeteria
{
    public class Cadete
    {
        private int _id;
        private string _name;
        private string _address;
        private string _phone;
        private int _orderCount;
        private List<Pedido> _pedidos;

        public Cadete(int id, string name, string address, string phone)
        {
            _id = id;
            _name = name;
            _address = address;
            _phone = phone;
            _orderCount = 0;
            _pedidos = new List<Pedido>();
        }

        public Cadete()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public int OrderCount { get => _orderCount; set => _orderCount = value; }
        internal List<Pedido> Pedidos { get => _pedidos; set => _pedidos = value; }

        public int JornalACobrar() => _orderCount * 500;

        public void AgregarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }
    }
}
