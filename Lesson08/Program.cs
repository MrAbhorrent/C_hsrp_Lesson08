using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson08
{
    class Program
    {
        private static int screenWidth = 119;
        private static String divider = new String('=', screenWidth);

        private static void Divider( int _size )
        {
            String _divider = new String('=', _size);
            Console.WriteLine(_divider);
        }

        private static int[,] CreateRandom2DArray( int _sizeM, int _sizeN, int _minValue, int _maxValue )
        {
            Random rnd = new Random();
            int[,] array = new int[_sizeM, _sizeN];
            for (int i = 0; i < _sizeM; i++)
            {
                for (int j = 0; j < _sizeN; j++)
                {
                    array[i, j] = rnd.Next((int)_minValue, (int)_maxValue - 1);
                }
            }
            return array;
        }

        private static int[, ,] CreateRandom3DArray( int _sizeX, int _sizeY, int _sizeZ, bool _nonRepetitive )
        {
            int minValue = 0;
            int maxValue = 100;
            int temp;
            List<int> checkedList = new List<int>();
            int[, ,] newArray = new int[_sizeX, _sizeY, _sizeZ];

            Random rnd = new Random();
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    for (int k = 0; k < _sizeZ; k++)
                    {
                        do
                        {
                            temp = rnd.Next((int)minValue, (int)maxValue);
                        } while (checkedList.Contains(temp));
                        checkedList.Add(temp);
                        newArray[i, j, k] = temp;
                    }
                }
            }
            checkedList.Clear();
            return newArray;
        }

        private static void SwapInRow<T>( T[,] _array, int rowNumber, int positionColumnA, int positionColumnB )
        {
            if (positionColumnA < _array.GetLength(1) && positionColumnB < _array.GetLength(1))
            {
                var temp = _array[rowNumber, positionColumnA];
                _array[rowNumber, positionColumnA] = _array[rowNumber, positionColumnB];
                _array[rowNumber, positionColumnB] = temp;
            }
        }

        private static void OrderByRowArray<T>( T[,] _array ) where T: IComparable<T>
        {
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                CoctailSortRow(_array, i);
            }            
        }

        private static void CoctailSortRow<T>( T[,] _array, int row) where T: IComparable<T>
        {
            int left = 0;
            int right = _array.GetLength(1) - 1;
            
            while (left < right)
            {                
                for (int i = left; i < right; i++)
                {
                    
                    if (_array[row, i].CompareTo(_array[row, i + 1]) < 0 )
                    {
                        SwapInRow(_array, row, i, i + 1);
                    }
                }
                right--;

                for (int j = right - 1; j > left; j--)
                {
                    if (_array[row, j - 1].CompareTo(_array[row, j]) < 0 )
                    {
                        SwapInRow(_array, row, j - 1, j);
                    }
                }
                left++;
            }
        }

        private static int NumberRowMinSum( int[,] _array )
        {
            int min = 0;
            int sum = 0;
            int numberRowFind = -1;

            for (int i = 0; i < _array.GetLength(0); i++)
            {                
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    sum += _array[i, j];
                }

                if ( min > sum || i == 0 )
                {
                    min = sum;
                    numberRowFind = i;
                }
                sum = 0;
            }
            return numberRowFind + 1;
        }

        private static int[,] ProduceOfMatrix( int[,] _arrayA, int[,] _arrayB )
        {
            int sizeMatrixA_M = _arrayA.GetLength(0);
            int sizeMatrixA_N = _arrayA.GetLength(1);
            int sizeMatrixB_N = _arrayB.GetLength(0);
            int sizeMatrixB_K = _arrayB.GetLength(1);
            int[,] resultArray = new int[sizeMatrixA_M, sizeMatrixB_K];

            if (sizeMatrixA_N == sizeMatrixB_N)
            {
                for (int i = 0; i < sizeMatrixA_M; i ++)
                {
                    for (int j = 0; j < sizeMatrixB_K; j++)
                    {
                        for (int k = 0; k < sizeMatrixB_N; k++)
                        {
                            resultArray[i, j] += _arrayA[i, k] * _arrayB[k, j];
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Матрицы нельзя перемножить");
            }
            return resultArray;
        }

        private static void PrintArray<T>( T[] _array )
        {
            if (_array.Length > 0)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.Write("[");
                for (int i = 0; i < _array.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (_array[i] is double)
                    {
                        Console.Write("{0:F2}", _array[i]);
                    }
                    else
                    {
                        Console.Write("{0}", _array[i]);
                    }
                    Console.ForegroundColor = color;
                    if (i == _array.Length - 1)
                    {
                        Console.Write("]");
                    }
                    else
                    {
                        Console.Write(", ");
                    }
                }
                Console.ForegroundColor = color;
            }
        }
        
        private static void Print2DArray<T>( T[,] _array )
        {
            if (_array.GetLength(0) > 0 && _array.GetLength(1) > 0)
            {
                ConsoleColor color = Console.ForegroundColor;
                for (int i = 0; i < _array.GetLength(0); i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < _array.GetLength(1); j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (_array[i, j] is double)
                        {
                            Console.Write("{0,6:F2}", _array[i, j]);
                        }
                        else
                        {
                            Console.Write("{0,6}", _array[i, j]);
                        }
                        Console.ForegroundColor = color;
                        if (j == _array.GetLength(1) - 1)
                        {
                            Console.Write("]");
                        }
                        else
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = color;
            }
        }

        private static void Print3DArray<T>( T[,,] _array )
        {
            if (_array.GetLength(0) > 0 && _array.GetLength(1) > 0 && _array.GetLength(2) > 0)
            {
                ConsoleColor color = Console.ForegroundColor;
                for (int i = 0; i < _array.GetLength(0); i++)
                {                    
                    for (int j = 0; j < _array.GetLength(1); j++)
                    {
                        Console.Write("[");
                        for (int k = 0; k < _array.GetLength(2); k++)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (_array[i, j, k] is double)
                            {
                                Console.Write("{0,6:F2}({1},{2},{3})", _array[i, j, k], i, j, k);
                            }
                            else
                            {
                                Console.Write("{0,6}({1},{2},{3})", _array[i, j, k], i, j, k);
                            }
                            Console.ForegroundColor = color;
                            if (k == _array.GetLength(2) - 1)
                            {
                                Console.Write("]");
                            }
                            else
                            {
                                Console.Write(", ");
                            }
                        }
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = color;
            }
        }
        
        static void Main( string[] args )
        {
            //Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
            //Например, задан массив:
            //    1 4 7 2
            //    5 9 2 3
            //    8 4 2 4
            //В итоге получается вот такой массив:
            //    7 4 2 1
            //    9 5 3 2
            //    8 4 4 2
            Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");

            int[,] array1 = CreateRandom2DArray(_sizeM: 3, _sizeN: 4, _minValue: -100, _maxValue: 101);
            Print2DArray(array1);
            Console.WriteLine("->");
            OrderByRowArray(array1);
            Print2DArray(array1);
            Divider(screenWidth);
                    
            //Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
            //Например, задан массив:
            //    1 4 7 2
            //    5 9 2 3
            //    8 4 2 4
            //    5 2 6 7
            //Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
            Console.WriteLine("Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
            int size = 4;
            int[,] array2 = CreateRandom2DArray(_sizeM: size, _sizeN: size, _minValue: 0, _maxValue: 50);
            Print2DArray(array2);
            Console.WriteLine("Номер строки с наименьшей суммой элементов - {0}", NumberRowMinSum(array2));
            Divider(screenWidth);
            //Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
            //Например, даны 2 матрицы:
            //    2 4 | 3 4
            //    3 2 | 3 3
            //Результирующая матрица будет:
            //    18 20
            //    15 18
            Console.WriteLine("Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
            var sizeM = 3;
            var sizeN = 4;
            int[,] array3 = CreateRandom2DArray(_sizeM: sizeM, _sizeN: sizeN, _minValue: 0, _maxValue: 10);
            int[,] array4 = CreateRandom2DArray(_sizeM: sizeN, _sizeN: sizeM, _minValue: 0, _maxValue: 10);
            Print2DArray(array3);
            Console.WriteLine("-> *");
            Print2DArray(array4);
            int[,] array5 = ProduceOfMatrix(array3, array4);
            Console.WriteLine("-> =");
            Print2DArray(array5);
            Divider(screenWidth);
            //Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
            //Массив размером 2 x 2 x 2
            //    66(0,0,0) 25(0,1,0)
            //    34(1,0,0) 41(1,1,0)
            //    27(0,0,1) 90(0,1,1)
            //    26(1,0,1) 55(1,1,1)
            Console.WriteLine("Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
            int sizeX = 2;
            int sizeY = 2;
            int sizeZ = 2;
            int[, ,] array6 = CreateRandom3DArray(_sizeX: sizeX, _sizeY: sizeY, _sizeZ: sizeZ, _nonRepetitive: true);
            Print3DArray(array6);
            Divider(screenWidth);
            //Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
            //    Например, на выходе получается вот такой массив:
            //    01 02 03 04
            //    12 13 14 05
            //    11 16 15 06
            //    10 09 08 07
            Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.");
            Console.Write("Введите размер квадратного массива - ");
            int sizeArray = Convert.ToInt32(Console.ReadLine());
            int[,] array7 = CreateFillSquareArray(sizeArray);
            Print2DArray(array7);
            Console.ReadKey();
        }

        private static int[,] CreateFillSquareArray( int _sizeArray )
        {
            int[,] resultArray = new int[_sizeArray, _sizeArray];
            int count = resultArray.Length;
            int row = 0;
            int col = 0;
            int dx = 0;
            int dy = 1;
            int directional = 0;
            int border = _sizeArray;

            for (int i = 0; i < count; i++)
            {
                resultArray[col, row] = i + 1;
                if (--border == 0)
                {
                    border = _sizeArray * (directional % 2) + _sizeArray * ((directional + 1) % 2) - (directional / 2 - 1) - 2;
                    int temp = dy;
                    dy = -dx;
                    dx = temp;
                    directional++;
                }
                col += dx;
                row += dy;

            }
            return resultArray;
        }

        
    }
}
