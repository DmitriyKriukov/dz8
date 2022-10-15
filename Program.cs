// Методы

int[,] FillArray(int rows, int columns, int min, int max)
{
    int[,] filledArray = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            filledArray[i, j] = new Random().Next(min, max + 1);
        }
    }
    return filledArray;
}


void PrintArray(int[,] inputArray)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            Console.Write("\t" + inputArray[i, j]);
        }
        Console.WriteLine();
    }
}


void task1()
{
    // Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию 
    // элементы каждой строки двумерного массива.
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // В итоге получается вот такой массив:
    // 7 4 2 1
    // 9 5 3 2
    // 8 4 4 2

    Console.Clear();
    Console.WriteLine("Введите количество строк двумерного массива");
    int rowCount = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите количество столбцов двумерного массива");
    int columnCount = int.Parse(Console.ReadLine());

    int[,] array = FillArray(rowCount, columnCount, 1, 10);
    PrintArray(array);

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - j - 1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    int temp = array[i, k + 1];
                    array[i, k + 1] = array[i, k];
                    array[i, k] = temp;
                }
            }
        }
    }
    Console.WriteLine();
    PrintArray(array);
    Console.ReadKey();
}


void task2()
{
    // Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет
    // находить строку с наименьшей суммой элементов.
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // 5 2 6 7
    // Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

    Console.Clear();
    Console.WriteLine("Введите количество строк (столбцов) прямоугольного двумерного массива");
    int RowAndColumnCount = int.Parse(Console.ReadLine());

    int[,] array = FillArray(RowAndColumnCount, RowAndColumnCount, 1, 10);
    PrintArray(array);

    int minSum = 0;
    int minIndex = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        minSum += array[0, j];
    }

    for (int i = 1; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        if (sum < minSum)
        {
            minSum = sum;
            minIndex = i;
        }
    }

    Console.WriteLine();
    Console.WriteLine($"Минимальная сумма {minSum} в строке: {minIndex + 1}");

    Console.ReadKey();
}


void task3()
{
    //     Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
    // Например, даны 2 матрицы:
    // 2 4 | 3 4
    // 3 2 | 3 3
    // Результирующая матрица будет:
    // 18 20
    // 15 18

    Console.Clear();
    Console.WriteLine("Введите количество строк первой матрицы");
    int rowFirst = int.Parse(Console.ReadLine());

    Console.WriteLine("Введите количество столбцов первой матрицы");
    int columnFirst = int.Parse(Console.ReadLine());

    int rowSecond = columnFirst;

    Console.WriteLine("Введите количество столбцов столбцов матрицы");
    int columnSecond = int.Parse(Console.ReadLine());

    int[,] firstMatrix = FillArray(rowFirst, columnFirst, 1, 10);
    int[,] secondMatrix = FillArray(rowSecond, columnSecond, 1, 10);


    PrintArray(firstMatrix);
    Console.WriteLine();
    PrintArray(secondMatrix);

    int[,] result = new int[rowFirst, columnSecond];

    for (int i = 0; i < rowFirst; i++)
    {
        for (int j = 0; j < columnSecond; j++)
        {
            for (int k = 0; k < rowSecond; k++)
            {
                result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
            }
        }
    }
    Console.WriteLine();
    PrintArray(result);

    Console.ReadKey();
}



void Main()
{
    Console.Clear();
    Console.WriteLine("\n Выберите задачу:\n\t1 - Задача 54 \n\t2 - Задача 56 \n\t3 - Задача 58 \n\t4 - Выйти");
    int num = Convert.ToInt32(Console.ReadLine());
    switch (num)
    {
        case 1:
            task1();
            Main();
            break;
        case 2:
            task2();
            Main();
            break;
        case 3:
            task3();
            Main();
            break;
        case 4:
            break;
    }
}
Main();