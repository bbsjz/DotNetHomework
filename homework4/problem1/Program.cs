using System;

namespace problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list= new GenericList<int>();
            for(int i=0;i<10;i++)
            {
                list.Add(i);
            }
            //打印元素
            Action<Node<int>> listAction = delegate(Node<int> node) {
                Console.Write(node.Data + " ");
            };
            //求和
            int sum=0;
            listAction += delegate (Node<int> node)
             {
                  sum += node.Data;
             };
            //求最大值
            int max = list.Head.Data;
            listAction += delegate (Node<int> node)
              {
                  if (max < node.Data)
                      max = node.Data;
              };
            //求最小值
            int min = list.Head.Data;
            listAction += delegate (Node<int> node)
              {
                  if (min > node.Data)
                      min = node.Data;
              };
            list.ForEach(listAction);
            Console.WriteLine($"sum={ sum}max={ max}min={ min}");
        }
    }

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail==null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<Node<T>> action)
        {
            for(Node<T> node=head;node!=null;node=node.Next)
            {
                action(node);
            }
        }
    }
}
