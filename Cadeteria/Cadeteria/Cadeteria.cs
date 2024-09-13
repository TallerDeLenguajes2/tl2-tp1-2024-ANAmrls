﻿using System.Collections.Generic;
using System.Linq;

namespace SistemaCadeteria
{
    public class Cadeteria
    {
        private string _name;
        private string _phone;
        private List<Cadete> _cadetes;

        public Cadeteria()
        {
        }

        public Cadeteria(string name, string phone)
        {
            _name = name;
            _phone = phone;
            _cadetes = CargarCadetes();
        }

        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
        internal List<Cadete> Cadetes { get => _cadetes; set => _cadetes = value; }

        private static List<Cadete> CargarCadetes()
        {
            Console.WriteLine("Cargando lista de cadetes");
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

        public void AsignarPedido(Pedido pedido, int idCadete)
        {
            Cadete cadete = Cadetes.FirstOrDefault(c => c.Id == idCadete);

            if (cadete != null)
            {
                cadete.AgregarPedido(pedido);
            }
            else
            {
                Console.WriteLine($"El cadete {idCadete} no se encontró");
            }
        }

        public void ReasignarPedido(int nroPedido, int idCadeteNuevo, int idCadete)
        {
            Cadete cad = Cadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cad != null)
            {
                Pedido pedido = cad.Pedidos.FirstOrDefault(p => p.Number == nroPedido);

                if (pedido != null)
                {
                    cad.Pedidos = cad.Pedidos.FindAll(p => p.Number != nroPedido);
                    AsignarPedido(pedido, idCadeteNuevo);
                }
                else
                {
                    Console.WriteLine($"El pedido {nroPedido} no se encontró");
                }
            }
            else
            {
                Console.WriteLine($"El cadete {idCadete} no se encontró");
            }
        }

    }
}
