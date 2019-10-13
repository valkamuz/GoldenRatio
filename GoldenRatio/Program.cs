using GoldenRatio.Math;
using System;

namespace GoldenRatio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var searcher = new MaximumFunctionArgumentSearcher(x => -x*x + 2*x + 6, 0, 7, 0.01);
            searcher.Search();

            string mes = $"x = {searcher.ResultArgument}, y = {searcher.ResultValue}";
            Console.WriteLine(mes);
        }
    }
}
