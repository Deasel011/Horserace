using System;
using System.Threading;

namespace Gibraltar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            Thread.Sleep(100);
            Console.WriteLine("After 100");

            Thread.Sleep(500);
            Console.WriteLine("After 500");

            Thread.Sleep(1000);
            Console.WriteLine("After 1000");

            Thread.Sleep(2000);
            Console.WriteLine("After 2000");

            Thread.Sleep(8000);
            Console.WriteLine("After 8000");

            Console.ReadKey();
        }
    }
}
