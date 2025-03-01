using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Solicitar los elementos del arreglo en una sola línea
        Console.Write("Ingrese los elementos del arreglo separados por espacios: ");
        string? input = Console.ReadLine();

        // Convertir la entrada en un arreglo de enteros
        int[] arr = (input ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

        // Verificar si el arreglo está vacío
        if (arr.Length == 0)
        {
            Console.WriteLine("El arreglo está vacío. Intente nuevamente.");
            return;
        }

        // Menú de selección de algoritmo de ordenamiento
        Console.WriteLine("\nSeleccione el algoritmo de ordenamiento:");
        Console.WriteLine("1. Merge Sort (Ordenamiento por mezcla)");
        Console.WriteLine("2. Bubble Sort (Ordenamiento por intercambio)");
        Console.Write("Opción: ");
        
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 1 && opcion != 2))
        {
            Console.Write("Opción inválida. Seleccione 1 o 2: ");
        }

        // Ordenar el arreglo según la opción elegida
        if (opcion == 1)
        {
            MergeSort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nArreglo ordenado con Merge Sort.");
        }
        else
        {
            BubbleSort(arr);
            Console.WriteLine("\nArreglo ordenado con Bubble Sort.");
        }

        Console.WriteLine("Arreglo ordenado: " + string.Join(" ", arr));

        // Solicitar el número a buscar
        Console.Write("\nIngrese el número que desea buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("Entrada inválida. Debe ingresar un número.");
            return;
        }

        // Búsqueda binaria después de ordenar
        int result = BinarySearch(arr, x);

        // Mostrar el resultado de la búsqueda
        if (result != -1)
        {
            Console.WriteLine($"El número {x} se encuentra en la posición {result}.");
        }
        else
        {
            Console.WriteLine($"El número {x} no está en el arreglo.");
        }
    }

    // Ordenamiento por mezcla (Merge Sort)
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++) L[i] = arr[left + i];
        for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

        int k = left, i1 = 0, i2 = 0;
        while (i1 < n1 && i2 < n2)
            arr[k++] = (L[i1] <= R[i2]) ? L[i1++] : R[i2++];

        while (i1 < n1) arr[k++] = L[i1++];
        while (i2 < n2) arr[k++] = R[i2++];
    }

    // Ordenamiento por intercambio (Bubble Sort)
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]); // Intercambio
                }
            }
        }
    }

    // Búsqueda binaria (Binary Search)
    static int BinarySearch(int[] arr, int x)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == x) return mid;
            if (arr[mid] < x) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }
}
