/* Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

Console.Clear();
int rows = UserInput("Введите количество строк первой матрицы: ", "Введено неверное значение!");
int columns = UserInput("Введите количество столбцов первой матрицы: ", "Введено неверное значение!");
int depth = UserInput("Введите количество матриц: ", "Введено неверное значение!");
int[,,] array = ArrayOfRealNumbers(rows, columns, depth, 10, 100);

Console.WriteLine("Трехмерная матрица:");
PrintArray(array);

Console.WriteLine($"Матрица размером {rows} x {columns} x {depth}:");
ArrayWithIndexes(array);












void ArrayWithIndexes(int[,,] inArray)
{
    for (int k = 0; k < inArray.GetLength(2); k++)
    {
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            for (int j = 0; j < inArray.GetLength(1); j++)
            {
                Console.Write($"{inArray[i, j, k]}({i}, {j}, {k})   ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,,] ArrayOfRealNumbers(int rows, int columns, int depth, int minValue, int maxValue)
{
    int[,,] arr = new int[rows, columns, depth];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < depth; k++)
            {
                arr[i, j, k] = new Random().Next(minValue, maxValue);
            }
        }
    }
    return arr;
}

void PrintArray(int[,,] inArray)
{
    for (int k = 0; k < inArray.GetLength(2); k++)
    {
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            for (int j = 0; j < inArray.GetLength(1); j++)
            {
                Console.Write($"{inArray[i, j, k]} \t");
            }
            Console.WriteLine();
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