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
            int[] array = new int[0];
            array = EditArray(array, 10, 2, 5);
            Console.WriteLine(array[2]);
        }

        static int[] EditArray(int[] array, int sizeArray, int index , int value)
        {
            array = new int[sizeArray];
            array[index] = value;
            return array;
        }
    }
}
