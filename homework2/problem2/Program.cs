using System;

namespace problem2
{
    class Program
    {
        public int INT_MAX { get; private set; }

        public int GetMax(int []a)
        {
            int length = a.GetLength(0);
            int max=a[0];
            for(int i=0;i<length;i++)
            {
                if(a[i]>max)
                {
                    max = a[i];
                }
            }
            return max;
        }

        public int GetMin(int []a)
        {
            int length = a.GetLength(0);
            int min = a[0];
            for(int i=0;i<length;i++)
            {
                if(a[i]<min)
                {
                    min = a[i];
                }
            }
            return min;
        }

        public int GetSum(int []a)
        {
            int length = a.GetLength(0);
            int sum = 0;
            for(int i=0;i<length;i++)
            {
                sum += a[i];
            }
            return sum;
        }

        public double GetAverange(int []a)
        {
            int length = a.GetLength(0);
            int sum = GetSum(a);
            return ((double)sum / (double)length);
        }

        static void Main(string[] args)
        {
            int[] a = { 3, 4, 6, 2, 4, 7, 8, 10 };
            Program p = new Program();
            Console.WriteLine(p.GetMax(a));
            Console.WriteLine(p.GetMin(a));
            Console.WriteLine(p.GetSum(a));
            Console.WriteLine(p.GetAverange(a));
        }
    }
}
