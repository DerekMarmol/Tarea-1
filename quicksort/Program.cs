using System;

class QuickSort
{
    // Método principal que implementa el algoritmo QuickSort
    public static void QuickSortAlgo(int[] arr, int low, int high)
    {
        // Verificamos si hay al menos dos elementos para ordenar
        if (low < high)
        {
            // Obtenemos la posición del pivote después de la partición
            int pi = Partition(arr, low, high);

            // Llamamos recursivamente para ordenar los elementos antes y después del pivote
            QuickSortAlgo(arr, low, pi - 1);  // Lado izquierdo del pivote
            QuickSortAlgo(arr, pi + 1, high); // Lado derecho del pivote
        }
    }

    // Método que realiza la partición del array
    public static int Partition(int[] arr, int low, int high)
    {
        // Elegimos el último elemento como pivote
        int pivot = arr[high];

        // Inicializamos el índice del menor elemento
        int i = (low - 1);

        // Recorremos el array desde low hasta high - 1
        for (int j = low; j < high; j++)
        {
            // Si el elemento actual es menor que el pivote, lo intercambiamos
            if (arr[j] < pivot)
            {
                i++;  // Movemos el índice del menor elemento
                Swap(arr, i, j); // Intercambiamos arr[i] con arr[j]
            }
        }

        // Intercambiamos el pivote con el primer elemento mayor encontrado
        Swap(arr, i + 1, high);

        // Retornamos la posición final del pivote
        return i + 1;
    }

    // Método para intercambiar dos elementos en el array
    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];  // Guardamos el valor de arr[i] en una variable temporal
        arr[i] = arr[j];    // Asignamos el valor de arr[j] a arr[i]
        arr[j] = temp;      // Asignamos el valor temporal a arr[j]
    }

    // Método para imprimir el array en consola
    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " "); // Imprimimos cada elemento separado por un espacio
        }
        Console.WriteLine(); // Nueva línea después de imprimir el array
    }

    // Método principal donde se ejecuta el programa
    public static void Main()
    {
        // Solicitamos la entrada del usuario
        Console.WriteLine("Ingrese los números separados por espacios:");
        string? input = Console.ReadLine();

        // Validamos que la entrada no esté vacía o sea nula
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Entrada inválida. Saliendo...");
            return;
        }

        int[] arr;

        try
        {
            // Convertimos la entrada de texto en un array de enteros
            arr = Array.ConvertAll(input.Split(' '), int.Parse);
        }
        catch (FormatException)
        {
            // Capturamos el error si la entrada no es válida
            Console.WriteLine("Entrada inválida. Asegúrese de ingresar solo números.");
            return;
        }

        int n = arr.Length; // Obtenemos la cantidad de elementos en el array

        // Mostramos el array original
        Console.WriteLine("Array original:");
        PrintArray(arr);

        // Llamamos al algoritmo QuickSort
        QuickSortAlgo(arr, 0, n - 1);

        // Mostramos el array ordenado
        Console.WriteLine("Array ordenado:");
        PrintArray(arr);
    }
}
