using System;
using System.Linq;
using System.Collections.Generic;

namespace kata2
{
    public delegate int Chop(int x, int[] array);
    
    public class Program
    {
        public static void Main(){}
        
        public static int IterativeBinarySearch(int x, int[] array)
        {
            if(array == null || array.Length == 0)
            {
                return -1;
            }

            int a = 0;
            int b = array.Length-1;
            int mid = array.Length / 2;

            while(a <= b)
            {
                if(x == array[mid])
                {
                    return mid;
                }

                if (x < array[mid])
                {
                    b = mid - 1;
                }
                else
                {
                    a = mid + 1;
                }
                
                mid = a + (b - a) / 2;
            }

            return -1;
        }

        public static int RecursiveBinarySearch(int x, int[] array)
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
                    int mid = a + (b - a) / 2;
                    if(x == array[mid])
                    {
                        return mid;
                    }
                    if (x < array[mid])
                    {
                        return binarySearch(x, array, a, mid - 1);
                    }
                    else
                    {
                        return binarySearch(x, array, mid + 1, b);
                    }
                }    
                return -1;
            }
        }
   
        public static int FunctionalBinarySearch(int x, int[] array)
        {
            int index = -1;
            if (binarySearch(array) == -1)
            {
                return -1;
            }
            return index-1;
            
            int binarySearch(IEnumerable<int> slice)
            {
                if(slice.Count() == 1 && slice.First() != x)
                {
                    return -1;
                }

                if(slice.Any())
                {
                    int mid = slice.Pivot();
                    if(x == slice.ElementAt(mid))
                    {
                        return mid;
                    }
                    if (x < slice.ElementAt(mid))
                    {
                        index -= mid;
                        return binarySearch(slice.Take(mid));
                    }

                    index += mid+1;
                    return binarySearch(slice.Skip(mid+1));
                }    
                return -1;
            }
        }

        public static int UnsafeBinarySearch(int x, int[] array)
        {
            if(array == null || array.Length == 0)
            {
                return -1;
            }
            unsafe
            {
                fixed (int* p = &array[0])
                {
                    return binarySearch(x, p, array.Length);
                }
            }
            
            unsafe int binarySearch(int x, int* array, int arrayLength)
            {
                int a = 0;
                int b = arrayLength - 1;
                int mid = arrayLength >> 1;

                while(a <= b)
                {
                    if(x == array[mid])
                    {
                        return mid;
                    }

                    if (x < array[mid])
                    {
                        b = mid - 1;
                    }
                    else
                    {
                        a = mid + 1;
                    }
                
                    mid = a + ((b - a) >> 1);
                }        
                return -1;
            }
        }

        public static int ThirdPartyBinarySearch(int x, int[] array)
        {
            int index = Array.BinarySearch(array, 0, array.Length, x);
            return index >= 0 ? index : -1;
        }
    }
}
