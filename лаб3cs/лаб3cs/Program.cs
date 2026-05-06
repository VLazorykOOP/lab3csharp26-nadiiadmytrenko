using System;
using System.Linq;

namespace RhombusApp
{
    public class DRomb
    {
        protected int d1;
        protected int d2;
        protected int c; 
        public DRomb(int diagonal1, int diagonal2, int color)
        {
            d1 = diagonal1;
            d2 = diagonal2;
            c = color;
        }
        public int D1
        {
            get => d1;
            set => d1 = value;
        }
        public int D2
        {
            get => d2;
            set => d2 = value;
        }
        public int Color => c; 
        public void DisplayInfo()
        {
            Console.WriteLine($"Діагоналі: {d1}, {d2} | Колір: {c} | Площа: {CalculateArea()} | Периметр: {CalculatePerimeter():F2} | Квадрат: {(IsSquare() ? "Так" : "Ні")}");
        }

        public double CalculatePerimeter()
        {
            double side = 0.5 * Math.Sqrt(Math.Pow(d1, 2) + Math.Pow(d2, 2));
            return 4 * side;
        }
        public double CalculateArea()
        {
            return (d1 * d2) / 2.0;
        }
        public bool IsSquare()
        {
            return d1 == d2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DRomb[] rhombuses = new DRomb[]
            {
                new DRomb(10, 10, 5),  
                new DRomb(4, 8, 2),
                new DRomb(6, 6, 1),  
                new DRomb(12, 5, 8),
                new DRomb(3, 3, 4)    
            };
            Console.WriteLine("Вихідний список ромбів");
            foreach (var r in rhombuses) r.DisplayInfo();
            Console.WriteLine("\nВпорядковані за кольором");
            var sortedByColor = rhombuses.OrderBy(r => r.Color);
            foreach (var r in sortedByColor) r.DisplayInfo();
            Console.WriteLine("\nВпорядковані за площею");
            var sortedByArea = rhombuses.OrderBy(r => r.CalculateArea());
            foreach (var r in sortedByArea) r.DisplayInfo();
            Console.WriteLine("\n Впорядковані за периметром");
            var sortedByPerimeter = rhombuses.OrderBy(r => r.CalculatePerimeter());
            foreach (var r in sortedByPerimeter) r.DisplayInfo();
            int squareCount = rhombuses.Count(r => r.IsSquare());
            Console.WriteLine($"\nКількість квадратів у масиві: {squareCount}");

            Console.ReadLine();
        }
    }
}

