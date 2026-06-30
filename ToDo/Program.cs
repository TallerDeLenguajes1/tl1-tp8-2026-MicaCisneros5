using EspacioTarea;
using System.Collections.Generic; //importamos la biblioteca donde se encuentra List
//using -> importar un espacio de nombres.
//System -> es el espacio de nombres principal de .NET.
//Collections -> contiene colecciones (arreglos, listas, colas, pilas, etc.).
//Generic -> contiene las colecciones genericas, como List<T>

//creamos las dos listas que pide la consigna
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();
//List<Tarea> -> una lista que guarda objetos de la clase Tarea.
//tareasPendientes -> nombre de la variable.
//new List<Tarea>() -> crea una lista vacia.


//flujo de orden a seguir: Crear objeto -> Completar sus datos -> Agregarlo a la lista

Ramdom random = new Random();//clase que genera numeros aleatorios

//6. Disena un menu principal que permita al usuario acceder a cada una de las funcionalidades descritas.
//La interaccion debe ser intuitiva (ej. "Presione 1 para...", "Ingrese el ID de la tarea:", etc.).

int opcion = 0;

while (opcion != 5)
{
    Console.WriteLine("\n===== GESTOR DE TAREAS =====");
    Console.WriteLine("Presione 1 para crear tareas");
    Console.WriteLine("Presione 2 para marcar una tarea como realizada");
    Console.WriteLine("Presione 3 para buscar una tarea por descripcion");
    Console.WriteLine("Presione 4 para mostrar todas las tareas");
    Console.WriteLine("Presione 5 para salir");

    Console.Write("Ingrese opcion: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
        //pedimos la cantidad de tareas
        Console.Write("Ingrese la cantidad de tareas que desea crear: ");
        int cantidad = int.Parse(Console.ReadLine());

        //cargamos las tareas
        for (int i = 0; i < cantidad; i++)
        {
            Tarea tarea = new Tarea();//en cada vuelta del for creo un objeto distinto

            tarea.TareaID = i + 1;
            tarea.Duracion = random.Next(10, 101);//genera un numero entre 10 y 100
            tarea.Descripcion = "Tarea " + (i + 1);

            tareasPendientes.add(tarea);//add agrega un objeto al final de la lista
        }
        Console.WriteLine("Tareas creadas correctamente.");
        break;

        case 2:
        if (tareasPendientes.Count == 0)
        {
            Console.WriteLine("No hay tareas pendientes.");
            break;
        }

        //mostramos las tareas pendientes
        Console.WriteLine("\n----- TAREAS PENDIENTES -----");

        //recorremos y mostramos los datos de las tareas
        foreach (Tarea tarea in tareasPendientes)
        {
            Console.WriteLine($"ID: {tarea.TareaID}");
            Console.WriteLine($"Descripcion: {tarea.Descripcion}");
            Console.WriteLine($"Duracion: {tarea.Duracion}");
            Console.WriteLine("-------------------------");
        }

        //preguntamos que tarea termino
        Console.Write("Ingrese el ID de la tarea realizada: ");
        int idBuscado = int.Parse(Console.ReadLine());

        //buscamos la tarea realizada
        for (int i = 0; i < tareasPendientes.Count; i++) //tareasPendientes.Count: recorre toda la lista
        {
            if (tareasPendientes[i].TareaID == idBuscado)
            {
                tareasRealizadas.add(tareasPendientes[i]);//lo agregamos a tareas realizadas
                tareasPendientes.Remove(tareasPendientes[i]);//lo quitamos de tarea pendiente

                Console.WriteLine("La tarea fue movida a realizadas.");
                break;//salimos del for
            }
        }
        break;

        case 3:
        //4.Desarrolle una funcion para buscar tareas pendientes por descripcion y mostrarla por consola

        Console.Write("Ingrese la descripcion a buscar: ");
        string descripcionBuscada = Console.ReadLine();

        bool encontrad = false;

        //recorremos la lista de pendientes
       for (int i = 0; i < tareasPendientes.Count; i++)
       {
           if (tareasPendientes[i].Descripcion.ToLower() == descripcionBuscada.ToLower())//ToLower() encuentra la tarea aunque le usuario la escriba en mayuscula o minuscula
           {
               Console.WriteLine("\nTarea encontrada:");
               Console.WriteLine($"ID: {tareasPendientes[i].TareaID}");
               Console.WriteLine($"Descripcion: {tareasPendientes[i].Descripcion}");
               Console.WriteLine($"Duracion: {tareasPendientes[i].Duracion}");

               encontrada = true;
           }
       }

        if (encontrada == false)
            {
                Console.WriteLine("No se encontro ninguna tarea.");
            }

        break;

        case 4: 
            Console.WriteLine("\n===== TAREAS PENDIENTES =====");

            foreach (Tarea tarea in tareasPendientes)
            {
                Console.WriteLine($"ID: {tarea.TareaID}");
                Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                Console.WriteLine($"Duracion: {tarea.Duracion}");
                Console.WriteLine("----------------");
            }


            Console.WriteLine("\n===== TAREAS REALIZADAS =====");


            foreach (Tarea tarea in tareasRealizadas)
            {
                Console.WriteLine($"ID: {tarea.TareaID}");
                Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                Console.WriteLine($"Duracion: {tarea.Duracion}");
                Console.WriteLine("----------------");
            }

        break;

        case 5:
        Console.WriteLine("Programa finalizado.");
        break;

        default:
        Console.WriteLine("Opcion invalida. Ingrese un numero del 1 al 5.");
        break;
    }
}