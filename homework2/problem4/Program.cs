using System;

namespace problem4
{
    class Program
    {
        public bool ifEqual(int [,]a,int x,int y,int row,int column)
        {
            int firstNum = a[x,y];
            x++;y++;
            while(x<row&&y<column)
            {
                if(a[x,y]!=firstNum)
                {
                    return false;
                }
                x++;y++;
            }
            return true;
        }
        public bool ifTopLitz(int [,]a)
        {
            int row = a.GetLength(0);
            int column = a.GetLength(1);
            if(row==0||column==0)
            {
                return false;
            }
            for(int i=0;i<column;i++)
            {
                if(!ifEqual(a,0,i,row,column))
                {
                    return false;
                }
            }
            for(int j=1;j<row;j++)
            {
                if(!ifEqual(a,j,0,row,column))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            int[,] a = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 0, 2 } };
            Console.WriteLine(myProgram.ifTopLitz(a));
        }
    }
}
