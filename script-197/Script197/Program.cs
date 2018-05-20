using System;

namespace Script197
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nella UWP console app!");
            var parameters = string.Join(Environment.NewLine, args);

            if (string.IsNullOrEmpty(parameters))
                Console.WriteLine("App invocata senza parametri");
            else
                Console.WriteLine($"App invocata con i parametri: {Environment.NewLine}{parameters}");

            Console.ReadKey();
        }
    }
}