// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

void PrintMas(int[,,] mas)
{
    for (int i = 0; i < mas.GetLength(0); i++)
    {
        for (int j = 0; j < mas.GetLength(1); j++)
        {
            for (int k = 0; k < mas.GetLength(2); k++)
            {
                Console.Write($"{mas[i,j,k]}({i},{j},{k})\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int[,,] Generate3DMas(int[] rowmas, int rows, int columns, int depth)
{
    int[,,] mas = new int[rows, columns, depth];
    int t = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    mas[i,j,k]=rowmas[t];
                    t++;
                }
            }
        }
    return mas;
    
}

int[] GenerateMas(int rows, int columns, int depth)
{
    int size = rows*columns*depth;
    int[] rowmas = new int[size];
    Random random = new Random();
    for (int i = 0; i < rowmas.Length; i++)
    {
        int number = random.Next(10, 100);
        if (rowmas.Contains(number))
        {
            i--;
        }
        else
        {
            rowmas[i] = number;
        }
    }
    return rowmas;
}

int GetInput(string text)
{
    Console.WriteLine(text);
    return Convert.ToInt32(Console.ReadLine());
}

int rows = GetInput("Введите количество строк в массиве: ");
int columns = GetInput("Введите количество столбцов в массиве: ");
int depth = GetInput("Введите глубину массива: ");
Console.WriteLine();
int[] rowmas = GenerateMas(rows, columns, depth);
Console.WriteLine();
int[,,] mas = Generate3DMas(rowmas, rows, columns, depth);
PrintMas(mas);