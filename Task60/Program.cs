//=============================================================================
// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся 
// двузначных чисел. Напишите программу, которая будет построчно выводить 
// массив, добавляя индексы каждого элемента.
//
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
//=============================================================================

Console.Clear();
Console.WriteLine($"Задайте размер массива А, В, С:");
int A = GetNaturalNumberFromUser("A= ", "Число должно быть больше нуля!");
int B = GetNaturalNumberFromUser("B= ", "Число должно быть больше нуля!");
int C = GetNaturalNumberFromUser("С= ", "Число должно быть больше нуля!");
int[,,] array3D = new int[A, B, C];
CreateArray(array3D);
PrintArray(array3D);

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

//печать массива
void PrintArray(int[,,] array3D)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"{array3D[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

//заполнение массива неповторяющимися двузначными числами
void CreateArray(int[,,] array3D)
{
    int[] arr = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
    int number;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        arr[i] = new Random().Next(10, 100);
        number = arr[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (arr[i] == arr[j])
                {
                    arr[i] = new Random().Next(10, 100);
                    j = 0;
                    number = arr[i];
                }
                number = arr[i];
            }
        }
    }
    int count = 0;
    for (int x = 0; x < array3D.GetLength(0); x++)
    {
        for (int y = 0; y < array3D.GetLength(1); y++)
        {
            for (int z = 0; z < array3D.GetLength(2); z++)
            {
                array3D[x, y, z] = arr[count];
                count++;
            }
        }
    }
}
