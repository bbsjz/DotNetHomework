using System;

namespace calculatorConsole
{
    class Program
    {
        private static double TryParse()
        {
            try
            {
                double num1 = double.Parse(Console.ReadLine());
                return num1;
            }
            catch
            {
                Console.WriteLine("请按正确的格式输入参数！");
                return 0;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("输入两个数字和一个运算符（+，-，*，/），每次输入一个值后请按回车，示例：2回车，3回车，+回车。此程序会打印出计算结果");
            double num1 = TryParse();
            double num2 = TryParse();
            string numOperator = Console.ReadLine();
            switch (numOperator)
            {
                case "+":
                    Console.WriteLine(num1 + num2);
                    break;
                case "-":
                    Console.WriteLine(num1 - num2);
                    break;
                case "*":
                    Console.WriteLine(num1 * num2);
                    break;
                case "/":
                    Console.WriteLine(num1 / num2);
                    break;
                default:
                    Console.WriteLine("请输入合法的运算符（+，-，*，/）");
                    break;
            }
        }
    }
}
