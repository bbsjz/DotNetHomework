using System;
using System.Collections;

namespace problem3
{
    class Program
    {
        public bool ifPrime(int num, int currentDivisor)
        {
            if (currentDivisor * currentDivisor > num)
            {
                return true;
            }
            if (num % currentDivisor == 0)
            {
                return false;
            }
            return (ifPrime(num, currentDivisor + 1));
        }
        public bool IfMultiple(int divisor,int dividend)
        {
            if(dividend==divisor)
            {
                return false;
            }
            if(dividend%divisor==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ArrayList GetAllPrime(ArrayList listLeft)
        {
            int begin = 2;
            int end = (int)listLeft[listLeft.Count-1];
            while(begin*begin<end)
            {
                if(ifPrime(begin,2))
                {
                    for(int i=0;i<listLeft.Count;i++)
                    {
                        if (IfMultiple(begin, (int)listLeft[i]))
                        {
                            listLeft.Remove((int)listLeft[i]);
                        }
                    }
                }
                begin++;
            }
            return listLeft;
        }
        public ArrayList generateList(int begin,int end)
        {
            ArrayList list=new ArrayList();
            for(int i=begin;i<=end;i++)
            {
                list.Add(i);
            }
            return list;
        }

        public void showAllPrime(ArrayList list)
        {
            foreach(Object obj in list)
            {
                Console.Write(" {0}", obj);
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            ArrayList list = new ArrayList();
            list = myProgram.generateList(2, 100);
            list = myProgram.GetAllPrime(list);
            myProgram.showAllPrime(list);
        }
    }
}
