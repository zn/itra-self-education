using System;
using System.Linq;
using System.Collections.Generic;

namespace kata2
{
    public delegate int Chop(int x, int[] array);
    
    public class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int IterativeChop(int x, int[] array)
        {
            if(array == null || array.Length == 0)
            {
                return -1;
            }

            int a = 0;
            int b = array.Length-1;
            int pivot = array.Length / 2;

            while(a <= b)
            {
                if(x == array[pivot])
                {
                    return pivot;
                }

                if (x < array[pivot])
                {
                    b = pivot - 1;
                }
                else
                {
                    a = pivot + 1;
                }
                
                pivot = a + (b - a) / 2;
            }

            return -1;
        }

        public int RecursiveChop(int x, int[] array)
        {
            if(array == null || array.Length == 0)
            {
                return -1;
            }

            return binarySearch(x, array, 0, array.Length - 1);

            int binarySearch(int x, int[] array, int a, int b)
            {
                if(a <= b)
                {
                    int pivot = a + (b - a) / 2;
                    if(x == array[pivot])
                    {
                        return pivot;
                    }
                    if (x < array[pivot])
                    {
                        return binarySearch(x, array, a, pivot - 1);
                    }
                    else
                    {
                        return binarySearch(x, array, pivot + 1, b);
                    }
                }    
                return -1;
            }
        }

    }
}
