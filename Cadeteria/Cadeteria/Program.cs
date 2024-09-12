// See https://aka.ms/new-console-template for more information
using SistemaCadeteria;

Cadeteria miCadeteria = cargarDatosCadeteria();

//Gestión de pedidos

//TODO dar alta de pedidos
//TODO asignar pedidos a cadete
//TODO cambiar estado de un pedido
//TODO reasignar pedido a otro cadete

//Informe de pedidos
/*TODO mostrar informe de peidods al finalizar la jornada que incluya el monto ganado y 
 * la cantidad de envios de cada cadete y el total. Mostrar tambien cantidad de envios 
 * promedio por cada cadete 
*/

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


