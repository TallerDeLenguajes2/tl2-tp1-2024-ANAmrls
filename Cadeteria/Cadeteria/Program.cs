﻿// See https://aka.ms/new-console-template for more information
using SistemaCadeteria;

Cadeteria miCadeteria = CargarDatosCadeteria();
int opcion = 0;
List<Pedido> pedidosSinAsignar = new();

//Gestión de pedidos
do
{
    Console.WriteLine($"\n##### Gestión de pedidos de {miCadeteria.Name} #####\n");
    Console.WriteLine("Seleccione una opción: \n"
                      + "1 - Dar alta a un nuevo pedido\n"
                      + "2 - Asignar pedido a un cadete\n"
                      + "3 - Modificar estado de un pedido\n"
                      + "4 - Reasignar un pedido a un cadete diferente\n"
                      + "5 - Para salir (se muestra el informe de pedidos de la jornada)");

    _ = int.TryParse(Console.ReadLine(), out opcion);

    while (opcion < 1 || opcion > 5)
    {
        Console.WriteLine("Ingrese una opción válida\n");
        _ = int.TryParse(Console.ReadLine(), out opcion);
    }

    switch (opcion)
    {
        case 1: pedidosSinAsignar.Add(AltaPedido()); break;
        case 2: AsignarPedidoACadete(miCadeteria, pedidosSinAsignar); break;
        case 3: CambiarEstadoPedidoDeCadete(miCadeteria); break;
        case 4: ReasignarPedidoDeUnCadete(miCadeteria); break;
        case 5: Informe(miCadeteria); break;
    }
}
while (opcion != 5);

static Cadeteria CargarDatosCadeteria()
{
    Console.WriteLine("----- Cargando datos de la cadeteria... -----\n");
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

static Cliente AltaCliente()
{
    Console.WriteLine("Ingrese los datos del cliente: ");
    Console.WriteLine("Nombre: ");
    string name = Console.ReadLine() ?? "";
    Console.WriteLine("Dirección: ");
    string address = Console.ReadLine() ?? "";
    Console.WriteLine("Número de teléfono: ");
    string phone = Console.ReadLine() ?? "";
    Console.WriteLine("Referencia: ");
    string reference = Console.ReadLine() ?? "";

    Cliente nuevoCliente = new(name, address, phone, reference);
    return nuevoCliente;
}

//alta de pedidos
static Pedido AltaPedido()
{
    Console.WriteLine("Ingrese la información del nuevo pedido:");
    Console.WriteLine("Número de pedido:");

    bool nroPedidoCheck = int.TryParse(Console.ReadLine(), out int number);

    while (!nroPedidoCheck  || number == 0)
    {
        Console.WriteLine("Número de pedido no válido. Ingréselo nuevamente: ");
        nroPedidoCheck = int.TryParse(Console.ReadLine(), result: out number);
    }

    Console.WriteLine("Observaciones");
    string obs = Console.ReadLine() ?? "";
    Cliente nuevoCliente = AltaCliente();

    Pedido nuevoPedido = new(number, obs, nuevoCliente);
    return nuevoPedido;
}

// asignar pedidos a cadete
static void AsignarPedidoACadete(Cadeteria miCadeteria, List<Pedido> pedidosSinAsignar)
{
    Console.WriteLine("Ingrese el número del pedido: ");
    _ = int.TryParse(Console.ReadLine(), out int nroPedido);

    Pedido? pedido = pedidosSinAsignar.Find(x => x.Number == nroPedido);

    if (pedido == null)
    {
        Console.WriteLine($"No existe el pedido número {nroPedido} o ya se encuentra asignado a un cadete\n");
        return;
    }

    Console.WriteLine("Ingrese el ID del cadete al que se le asignará el pedido: ");
    _ = int.TryParse(Console.ReadLine(), out int idCadete);

    if (miCadeteria.AsignarPedido(pedido, idCadete))
    {
        pedidosSinAsignar.Remove(pedido);
        Console.WriteLine("Pedido asignado con éxito");
    }
    else
    {
        Console.WriteLine($"El cadete {idCadete} no se encontró");
    }

}

//cambiar estado de un pedido
static void CambiarEstadoPedidoDeCadete(Cadeteria cadeteria)
{
    Estado nuevoEstado = Estado.Pendiente;

    Console.WriteLine("Ingrese el ID del cadete que tiene el pedido: ");
    _ = int.TryParse(Console.ReadLine(), out int idCadete);

    Cadete? cadete = cadeteria.Cadetes.Find(c => c.Id == idCadete);

    if (cadete == null)
    {
        Console.WriteLine($"El cadete {idCadete} no se encontró");
        return;
    }
    
    Console.WriteLine("Ingrese el número del pedido: ");
    _ = int.TryParse(Console.ReadLine(), out int nroPedido);

    Console.WriteLine("Ingrese el nuevo estado del pedido: \n"
                      + "1 - Entregado\n"
                      + "2 - Pagado");

    _ = int.TryParse(Console.ReadLine(), out int estadoElegido);

    while (estadoElegido < 1 || estadoElegido > 2)
    {
        Console.WriteLine("Ingrese una opción de estado válida");
        _ = int.TryParse(Console.ReadLine(), out estadoElegido);
    }

    if (estadoElegido == 1)
    {
        nuevoEstado = Estado.Entregado;
    }
    else
    {
        nuevoEstado = Estado.Pagado;
    }

    if (cadete.CambiarEstadoPedido(nroPedido, nuevoEstado))
    {
        Console.WriteLine("Estado cambiado con éxito");
    } 
    else
    {
        Console.WriteLine("El pedido no se encontró en el cadete seleccionado");
    }
}

//reasignar pedido a otro cadete
static void ReasignarPedidoDeUnCadete(Cadeteria cadeteria)
{
    Console.WriteLine("Ingrese el número del pedido: ");
    _ = int.TryParse(Console.ReadLine(), out int nroPedido);

    Console.WriteLine("Ingrese el ID del cadete a quien quiere asignar el pedido: ");
    _ = int.TryParse(Console.ReadLine(), out int idCadeteNuevo);

    if (cadeteria.ReasignarPedido(nroPedido, idCadeteNuevo))
    {
        Console.WriteLine($"Pedido reasignado con éxito al cadete {idCadeteNuevo}");
    }
    else
    {
        Console.WriteLine($"No se encontró el pedido número {nroPedido}");
    }
}

//Informe de pedidos
static void Informe(Cadeteria cadeteria)
{
    float totalEnvios = 0;
    float promedioEnvios = 0;

    Console.WriteLine("\n######## Informe de pedidos ########\n");
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

