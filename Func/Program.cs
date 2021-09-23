using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            int[,] array2 = new int[1, 1];
            array = ResizeArray(array, 20);
            Console.WriteLine(array.Length);
            array2 = ResizeArray(array2, 4, 10);
            Console.WriteLine(array2.GetLength(0) + " " + array2.GetLength(1));
        }

        static int[] ResizeArray(int[] array, int size)
        {
            int[] tempArray = new int[size];
            for (int i = 0 ; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            array = tempArray;
            return array;
        }
        static int[,] ResizeArray(int[,] array, int sizeX, int sizeY)
        {
            int[,] tempArray = new int[sizeX,sizeY];
            for (int i = 0; i<array.GetLength(0); i++ )
            {
                for (int j = 0; j<array.GetLength(1); j++) 
                {
                    tempArray[i, j] = array[i, j];
                }
            }
            array = tempArray;
            return array;
        }
    }
}
