using System;
using System.Collections;

namespace homework2
{
    class Program
    {
        public int TryParse()
        {
            Console.WriteLine("请输入一个整数，本程序将返回该数字的所有的素数因子");
            string str=Console.ReadLine();
            while(!int.TryParse(str,out int n))
            {
                Console.WriteLine("请输入正确的整数");
                str = Console.ReadLine();
            }
            int.TryParse(str, out int num);
            return num;
        }
        public bool ifPrime(int num,int currentDivisor)
        {
            if(currentDivisor*currentDivisor>num)
            {
                return true;
            }
            if(num%currentDivisor==0)
            {
                return false;
            }
            return (ifPrime(num, currentDivisor + 1));
        }

        public ArrayList getPrimeDivisor(int num,int currentDivisor,ArrayList answer)
        {
            if (currentDivisor * currentDivisor > num)
            {
                if(ifPrime(num,2))
                {
                    answer.Add(num);
                }
                return answer;
            }
            if(num%currentDivisor==0)
            {
                if(ifPrime(currentDivisor,2))
                {
                    answer.Add(currentDivisor);
                }
                return(getPrimeDivisor(num / currentDivisor, currentDivisor, answer));
            }
            else
            {
                return(getPrimeDivisor(num, currentDivisor + 1, answer));
            }
        }

        public void showAllDivisor(ArrayList list)
        {
            foreach(Object num in list)
            {
                Console.Write(" {0}", num);
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            int num = myProgram.TryParse();
            ArrayList list = new ArrayList();
            list = myProgram.getPrimeDivisor(num, 2, list);
            myProgram.showAllDivisor(list);
        }
    }
}
