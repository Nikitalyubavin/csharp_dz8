/* Задайте прямоугольный двумерный массив. Напишите программу,
которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

Console.Clear();
int rows = UserInput("Введите количество строк: ", "Введено неверное значение!");
int columns = UserInput("Введите количество столбцов: ", "Введено неверное значение!");
int[,] array = ArrayOfRealNumbers(rows, columns, 0, 10);

Console.WriteLine();
PrintArray(array);

Console.WriteLine();
Console.WriteLine($"Наименьшая сумма элементов: {RowWithMinSum(array)} строка!");


int RowWithMinSum(int[,] arr)
{
    int sum = 0;
    int minSum = 0;
    int index = 1;
    for (int j = 0; j < arr.GetLength(1); j++)
        minSum += arr[0, j];
    for (int i = 1; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            sum += arr[i, j];
        }
        if (sum < minSum)
        {
            minSum = sum;
            index = i + 1;
        }
        sum = 0;
    }
    return index;
}

int[,] ArrayOfRealNumbers(int rows, int columns, int minValue, int maxValue)
{
    int[,] arr = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            arr[i,j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return arr;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i,j]} \t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int UserInput(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine()??"", out int number) && number > 0) return number;
        else Console.WriteLine(errorMessage);
    }
}