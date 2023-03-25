//=============================================================================
// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
//
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка
//=============================================================================

Console.Clear();
int num = GetNaturalNumberFromUser("Введите размер массива: ", "Ошибка ввода!");
int rows = num;
int columns = num;
int minValue = GetNaturalNumberFromUser("Введите начальное значение диапазона ", "Ошибка ввода!");
int maxValue = GetNaturalNumberFromUser("Введите конечное значение диапазона ", "Ошибка ввода!");
int[,] array = GetArray(rows, columns, minValue, maxValue);

PrintArray(array);
int result = FindMinSum(array);
Console.WriteLine($"Номер строки с минимальной суммой равен {result}");

//Ввод натурального числа
int GetNaturalNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 0)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

//Создание массива
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] array = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return array;
}

//Печать массива
void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int FindMinSum(int[,] inArray)
{
    int sum = 0;
    int result = 0;
    for (int j = 0; j < inArray.GetLength(1); j++)
    {
        sum += inArray[0, j];
    }
    for (int i = 1; i < inArray.GetLength(0); i++)
    {
        int temp = 0;
        for (int j = 0; j < inArray.GetLength(1); j++)
            temp += inArray[i, j];
        if (temp < sum)
        {
            sum = temp;
            result = i;
        }

    }
    return result+1;
}