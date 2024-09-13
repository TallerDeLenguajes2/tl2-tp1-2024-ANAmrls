﻿// See https://aka.ms/new-console-template for more information
using SistemaCadeteria;

Cadeteria miCadeteria = cargarDatosCadeteria();

//Gestión de pedidos
Console.WriteLine("Gestión de pedidos\n");
Console.WriteLine("Seleccione una opción");

//alta de pedidos
Pedido pedido1 = altaPedido();
Pedido pedido2 = altaPedido();
Pedido pedido3 = altaPedido();

// asignar pedidos a cadete
Cadete cad1 = miCadeteria.Cadetes.Where(c => c.Id == 3).First();
Cadete cad2 = miCadeteria.Cadetes.Where(c => c.Id == 1).First();
Cadete cad3 = miCadeteria.Cadetes.Where(c => c.Id == 4).First();
Console.WriteLine($"Pedidos cadete 1: {cad1.Pedidos.Count}");
Console.WriteLine($"Pedidos cadete 2: {cad2.Pedidos.Count}");
miCadeteria.AsignarPedido(pedido1, cad1.Id);
Console.WriteLine($"Pedidos cadete 1: {cad1.Pedidos.Count}");
Console.WriteLine($"Pedidos cadete 2: {cad2.Pedidos.Count}");
miCadeteria.AsignarPedido(pedido2, cad2.Id);
Console.WriteLine($"Pedidos cadete 1: {cad1.Pedidos.Count}");
Console.WriteLine($"Pedidos cadete 2: {cad2.Pedidos.Count}");
miCadeteria.AsignarPedido(pedido3, cad1.Id);
Console.WriteLine($"Pedidos cadete 1: {cad1.Pedidos.Count}");
Console.WriteLine($"Pedidos cadete 2: {cad2.Pedidos.Count}");

//cambiar estado de un pedido
Console.WriteLine($"Estado pedido 1: {pedido1.State}");
cad1.PedidoEntregado(1);
Console.WriteLine($"Estado pedido 1: {pedido1.State}");
Console.WriteLine($"Estado pedido 2: {pedido2.State}");
cad2.PedidoEntregado(2);
Console.WriteLine($"Estado pedido 2: {pedido2.State}");

//reasignar pedido a otro cadete
miCadeteria.ReasignarPedido(pedido1.Number, cad2.Id, cad1.Id);
Console.WriteLine($"Pedidos cadete 1: {cad1.Pedidos.Count}");
Console.WriteLine($"Pedidos cadete 2: {cad2.Pedidos.Count}");

//Informe de pedidos

Informe(miCadeteria);

static Cadeteria cargarDatosCadeteria()
{
    Console.WriteLine("Cargando datos de la cadeteria");
    string path = "cadeteria.csv";

    Cadeteria nuevaCadeteria = new();

	try
	{
        var lines = File.ReadAllLines(path);

        foreach (var line in lines)
        {
            var campos = line.Split(',');

            string nombre = campos[0];
            string telefono = campos[1];

            nuevaCadeteria = new(nombre, telefono);
        }
        Console.WriteLine("Datos cargados con éxito\n");
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

    return nuevaCadeteria;
}

static Cliente altaCliente()
{
    Console.WriteLine("Ingrese el nombre del cliente");
    string name = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese la dirección del cliente");
    string address = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese el número de teléfono del cliente");
    string phone = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese una referencia");
    string reference = Console.ReadLine() ?? "";

    Cliente nuevoCliente = new(name, address, phone, reference);
    return nuevoCliente;
}

static Pedido altaPedido()
{
    Console.WriteLine("Ingrese la información del nuevo pedido:");
    Console.WriteLine("Ingrese el número del pedido");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Observaciones");
    string obs = Console.ReadLine() ?? "";
    Cliente nuevoCliente = altaCliente();

    Pedido nuevoPedido = new(number, obs, nuevoCliente);
    return nuevoPedido;
}

static void Informe(Cadeteria cadeteria)
{
    int totalEnvios = 0;
    float promedioEnvios = 0;

    Console.WriteLine("######## Informe de pedidos ########\n");
    foreach (var cadete in cadeteria.Cadetes)
    {
        cadete.MostrarDatosInforme();
        Console.WriteLine("\n");
        totalEnvios += cadete.OrderCount;
    }

    promedioEnvios = totalEnvios / cadeteria.Cadetes.Count;

    Console.WriteLine($"Total Envíos: {totalEnvios}");
    Console.WriteLine($"Promedio de envíos por cadete: {promedioEnvios}");
}

