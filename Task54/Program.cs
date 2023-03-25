//=============================================================================
// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
//=============================================================================

Console.Clear();
int rows = GetNaturalNumberFromUser("Введите количество строк массива: ", "Ошибка ввода!");
int columns = GetNaturalNumberFromUser("Введите количество столбцов массива: ", "Ошибка ввода!");
int minValue = GetIntNumberFromUser("Введите начальное значение диапазона ", "Ошибка ввода!");
int maxValue = GetIntNumberFromUser("Введите конечное значение диапазона ", "Ошибка ввода!");
int[,] array = GetArray(rows, columns, minValue, maxValue);
PrintArray(array);
Console.WriteLine();
int[,] arr = SortArray(array);
PrintArray(arr);

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

//Ввод целого числа
int GetIntNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect)
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
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

//Сортировка строк массива
int[,] SortArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = j + 1; k < inArray.GetLength(1); k++)
            {
                if (inArray[i, j] < inArray[i, k])
                {
                    int b = inArray[i, j];
                    inArray[i, j] = inArray[i, k];
                    inArray[i, k] = b;                    
                }                
            }
            
        }              
    }
    return inArray;
}