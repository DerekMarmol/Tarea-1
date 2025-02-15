using System;
using System.Linq;

class Program
{
    // Método de búsqueda lineal
    static int LinearSearch(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x)
            {
                return i; // Retorna la posición si encuentra el elemento
            }
        }
        return -1; // Retorna -1 si no lo encuentra
    }

    static void Main()
    {
        // Solicitar los elementos del arreglo en una sola línea con control de null
        Console.Write("Ingrese los elementos del arreglo separados por espacios: ");
        string? input = Console.ReadLine();

        // Si la entrada es null, asignamos una cadena vacía para evitar errores
        int[] arr = (input ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

        // Verificar si el arreglo está vacío
        if (arr.Length == 0)
        {
            Console.WriteLine("El arreglo está vacío. Intente nuevamente.");
            return;
        }

        // Solicitar el número a buscar
        Console.Write("Ingrese el número que desea buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("Entrada inválida. Debe ingresar un número.");
            return;
        }

        // Llamar al método de búsqueda lineal
        int result = LinearSearch(arr, x);

        // Mostrar el resultado
        if (result != -1)
        {
            Console.WriteLine($"El número {x} se encuentra en la posición {result}.");
        }
        else
        {
            Console.WriteLine($"El número {x} no está en el arreglo.");
        }
    }
}
