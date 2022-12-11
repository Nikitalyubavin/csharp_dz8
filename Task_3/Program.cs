/* Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.Clear();
int rows1 = UserInput("Введите количество строк первой матрицы: ", "Введено неверное значение!");
int columns1 = UserInput("Введите количество столбцов первой матрицы: ", "Введено неверное значение!");
int[,] array1 = ArrayOfRealNumbers(rows1, columns1, -10, 10);

int rows2 = UserInput("Введите количество строк второй матрицы: ", "Введено неверное значение!");
int columns2 = UserInput("Введите количество столбцов второй матрицы: ", "Введено неверное значение!");
int[,] array2 = ArrayOfRealNumbers(rows2, columns2, -10, 10);

Console.WriteLine("Первая матрица:");
PrintArray(array1);

Console.WriteLine("Вторая матрица:");
PrintArray(array2);

if (columns1 == rows2)
{
    int[,] newArray = CompositionOfTwoArrays(array1, array2);
    Console.WriteLine("Произведение двух матриц равно:");
    PrintArray(newArray);
}
else Console.WriteLine("Произведение данных матриц невозможно, так как количество столбцов первой матрицы не равно количеству строк второй.");
Console.WriteLine();





int[,] CompositionOfTwoArrays(int[,] arr1, int[,] arr2)
{
    int[,] composedArray = new int[arr1.GetLength(0), arr2.GetLength(1)];
    int sum = 0;
    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 0; j < arr2.GetLength(1); j++)
        {
            for (int k = 0; k < arr2.GetLength(0); k++)
            {
                sum += arr1[i, k] * arr2[k, j];
            }
            composedArray[i, j] = sum;
            sum = 0;
        }
    }
    return composedArray;
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