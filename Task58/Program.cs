//=============================================================================
// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить 
// произведение двух матриц.
//
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
//=============================================================================


Console.Clear();
int rows1 = GetNaturalNumberFromUser("Введите количество строк первой матрицы: ", "Ошибка ввода!");
int columns1 = GetNaturalNumberFromUser("Введите количество столбцов первой матрицы: ", "Ошибка ввода!");
int rows2 = columns1;
int columns2 = GetNaturalNumberFromUser("Введите количество столбцов второй матрицы: ", "Ошибка ввода!");
int minValue = GetNaturalNumberFromUser("Введите начальное значение диапазона ", "Ошибка ввода!");
int maxValue = GetNaturalNumberFromUser("Введите конечное значение диапазона ", "Ошибка ввода!");
int[,] arrayA = GetArray(rows1, columns1, minValue, maxValue);
int[,] arrayB = GetArray(rows2, columns2, minValue, maxValue);
int[,] arrayC = ArrayMultiplication(arrayA, arrayB);
PrintArray(arrayA);
Console.WriteLine();
PrintArray(arrayB);
Console.WriteLine($"Результат произведения двух массивов:");
PrintArray(arrayC);

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

//произведение матриц
int[,] ArrayMultiplication(int[,] arr1, int[,] arr2)
{
    int[,] arr3 = new int[arr1.GetLength(0), arr2.GetLength(1)];
    for (int i = 0; i < arr3.GetLength(0); i++)
    {
        for (int j = 0; j < arr3.GetLength(1); j++)
        {
            arr3[i, j] = 0;
            for (int k = 0; k < arr1.GetLength(1); k++)
            {
                arr3[i, j] += arr1[i, k] * arr2[k, j];
            }
        }

    }
    return arr3;
}