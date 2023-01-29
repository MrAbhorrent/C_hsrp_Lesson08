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

        private static void SwapInRow<T>( T[,] _array, int rowNumber, int positionColumnA, int positionColumnB )
        {
            if (positionColumnA < _array.GetLength(1) && positionColumnB < _array.GetLength(1))
            {
                var temp = _array[rowNumber, positionColumnA];
                _array[rowNumber, positionColumnA] = _array[rowNumber, positionColumnB];
                _array[rowNumber, positionColumnB] = temp;
            }
        }

        private static void OrderByRowArray( int[,] _array )
        {
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                CoctailSortRow(_array, i);
            }
        }

        private static void CoctailSortRow( int[,] _array, int row)
        {
            int left = 0;
            int right = _array.GetLength(1) - 1;
            
            while (left < right)
            {                
                for (int i = left; i < right; i++)
                {
                    
                    if (_array[row, i] > _array[row, i + 1])
                    {
                        SwapInRow<int>(_array, row, i, i + 1);
                    }
                }
                right--;

                for (int j = right - 1; j > left; j--)
                {
                    if (_array[row, j - 1] > _array[row, j])
                    {
                        SwapInRow<int>(_array, row, j - 1, j);
                    }
                }
                left++;
            }
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

            Divider(screenWidth);
            //Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
            //Например, даны 2 матрицы:
            //    2 4 | 3 4
            //    3 2 | 3 3
            //Результирующая матрица будет:
            //    18 20
            //    15 18

            Divider(screenWidth);
            //Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
            //Массив размером 2 x 2 x 2
            //    66(0,0,0) 25(0,1,0)
            //    34(1,0,0) 41(1,1,0)
            //    27(0,0,1) 90(0,1,1)
            //    26(1,0,1) 55(1,1,1)

            Divider(screenWidth);
            //Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
            //    Например, на выходе получается вот такой массив:
            //    01 02 03 04
            //    12 13 14 05
            //    11 16 15 06
            //    10 09 08 07


            Console.ReadKey();
        }
    }
}
