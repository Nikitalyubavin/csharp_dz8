/* Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

Console.Clear();
int rows = UserInput("Введите количество строк: ", "Введено неверное значение!");
int columns = UserInput("Введите количество столбцов: ", "Введено неверное значение!");
int[,] array = ArrayOfRealNumbers(rows, columns);

PrintArray(array);










int[,] ArrayOfRealNumbers(int rows, int columns)
{
    int[,] arr = new int[rows, columns];
    int i = 0;
    int j = 0;
    int count = 1;
    int n = 0;
    while (count <= rows * columns)
    {
        for (; j < arr.GetLength(1) - n; j++)
        {
            arr[i, j] = count;
            count++;
        }
        j--;
        i++;
        for (; i < arr.GetLength(0) - n; i++)
        {
            arr[i, j] = count;
            count++;
        }
        i--;
        j--;
        for (; j >= 0 + n; j--)
        {
            arr[i, j] = count;
            count++;
        }
        j++;
        i--;
        for (; i > 0 + n; i--)
        {
            arr[i, j] = count;
            count++;
        }
        i++;
        j++;
        n++;
    }
    return arr;
    /*int[,] arr = new int[rows, columns];
    int count = 1;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            arr[i,j] = count;
            count++;
        }
    }*/
    //return arr;
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