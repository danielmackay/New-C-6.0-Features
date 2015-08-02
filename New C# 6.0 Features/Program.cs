using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// 1. Static references
using static System.Console;

namespace NewCSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = new List<Point> { new Point(1, 2), new Point(3, 4), new Point(5, 6) };

            // 1. Static references
            WriteLine("Starting Program...");

            var json = new JArray(points.Select(p => p.ToJson())).ToString();

            WriteLine(json);

            // 2. Lambda debugging
            Task.Run(() =>
            {
                // todo: set break point here
                var start = 0;
                start = start + 2;
                start = start - 10;
                var result = start;
                WriteLine($"Result: {result}");
            });

            ReadKey();
        }
    }

    class Point
    {
        // 3. Auto property initialisers
        public int Origin { get; set; } = 0;

        // 4. Getter only auto properties
        public int Width { get; } = 2;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        // 5. String interpolation
        // 6. Expression body members (works with properties too)
        public string ToJson() => $"{{X: {X}, Y: {Y}}}";

        public static Point FromJson(JObject arg)
        {
            try
            {
                // 7. Null propagating operator
                if (arg?["x"]?.Type != JTokenType.Integer ||
                    arg?["y"]?.Type != JTokenType.Integer)
                {
                    // 8. nameof operator
                    throw new ArgumentException("The parameter is not shaped like a point", nameof(arg));
                }
            }
            catch (Exception ex) when (shouldCatch(ex))
            {
                WriteLine("Oops!");
            }

            return null;
        }

        private static bool shouldCatch(Exception ex) => ex is ApplicationException;
    }
}
