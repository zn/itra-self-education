using System;

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

            if(array.Length == 1 && array[0] == x)
            {
                return 0;
            }

            int a = 0;
            int b = array.Length-1;
            int pivot = array.Length / 2;

            while(a < b)
            {
                if(x == array[pivot])
                {
                    return pivot;
                }

                if(x < array[pivot])
                {
                    b = pivot-1;
                }
                else if( x > array[pivot])
                {
                    a = pivot+1;
                }
                
                pivot = (b - a) / 2;
            }

            return -1;
        }
    }
}
