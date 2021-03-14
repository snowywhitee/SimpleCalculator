using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"5 + 6 = {MyMath.Perform('+', 5, 6)}");
            Console.WriteLine($"5 - 6 = {MyMath.Perform('-', 5, 6)}");
            Console.WriteLine($"5 * 6 = {MyMath.Perform('*', 5, 6)}");
            Console.WriteLine($"5 / 6 = {MyMath.Perform('/', 5, 6)}");
        }
    }
    /// <summary>
    /// Class which performs basic math operations
    /// </summary>
    public static class MyMath
    {
        public delegate double Calc(double x, double y);
        /// <summary>
        /// List of the supported operations with their corresponding methods
        /// </summary>
        private static Dictionary<char, Calc> _operations =
        new Dictionary<char, Calc>
        {
            { '+', Add },
            { '-', Sub },
            { '*', Mult },
            { '/', Div },
        };

        /// <summary>
        /// Executes the operation given
        /// </summary>
        /// <param name="op">operation from the dictionary</param>
        /// <param name="x">first param</param>
        /// <param name="y">second param</param>
        /// <returns>result of the operation</returns>
        public static double Perform(char op, double x, double y) => _operations[op](x, y);

        /// <summary>
        /// Method performing addition
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Add(double x, double y) => x + y;

        /// <summary>
        /// Method performing substraction
        /// </summary>
        /// <param name="x">minuend</param>
        /// <param name="y">subtrahend</param>
        /// <returns></returns>
        public static double Sub(double x, double y) => Add(x, -y);

        /// <summary>
        /// Method performing multiplication
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Mult(double x, double y) => x * y;

        /// <summary>
        /// Throwing the exception explicitly is required because delegates are being used
        /// </summary>
        /// <param name="x">dividend</param>
        /// <param name="y">denominator</param>
        /// <returns></returns>
        public static double Div(double x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();
            return x / y;
        }
        public static double Mode(double x, double y)
        {
            return x % y;
        }
    }
}
