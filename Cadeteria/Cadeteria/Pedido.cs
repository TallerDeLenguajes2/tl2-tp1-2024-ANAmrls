using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadeteria
{
    internal class Pedido
    {
        private int _number;
        private string _obs;
        private Cliente _cliente;
        private string _state;

        public Pedido(int number, string obs, Cliente cliente, string state)
        {
            _number = number;
            _obs = obs;
            _cliente = cliente;
            _state = state;
        }

        public int Number { get => _number; set => _number = value; }
        public string Obs { get => _obs; set => _obs = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public string State { get => _state; set => _state = value; }

        public void VerDireccionCliente()
        {
            Console.WriteLine($"Dirección del cliente: {Cliente.Address}");
        }

        public void VerDatosCLiente()
        {
            Console.WriteLine("Datos del cliente");
            Cliente.MostrarDatos();
        }
    }
}
