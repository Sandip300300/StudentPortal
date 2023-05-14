using System;
using System.Collections;
using System.Collections.Specialized;

namespace Practice_Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            var s = new Acme.Collections.Stack<int>();
            s.Push(1);
            s.Push(10);
            s.Push(100);
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
        }
    }
}
