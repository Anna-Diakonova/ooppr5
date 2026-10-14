using System;

namespace GeometryTask
{
    public class TCircle
    {
        private double radius;

        public double Radius
        {
            get => radius;
            set
            {
                if (value >= 0)
                {
                    radius = value;
                }
                else
                {
                    Console.WriteLine("Помилка: Радіус не може бути негативним! Встановлено значення 0.");
                    radius = 0;
                }
            }
        }

        public TCircle()
        {
            Radius = 0;
        }

        public TCircle(double radius)
        {
            Radius = radius;
        }

        public TCircle(TCircle other)
        {
            if (other != null)
            {
                Radius = other.Radius;
            }
        }

        public void Input()
        {
            Console.Write("Введіть радіус кола: ");
            if (double.TryParse(Console.ReadLine(), out double r))
            {
                Radius = r;
            }
            else
            {
                Console.WriteLine("Некоректне введення! Встановлено радіус 0.");
                Radius = 0;
            }
        }

        public void Print()
        {
            Console.Write($"Окружність [Радіус = {Radius}]");
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetSectorArea(double angleDegrees)
        {
            return (Math.PI * Radius * Radius * angleDegrees) / 360.0;
        }

        public double GetLength()
        {
            return 2 * Math.PI * Radius;
        }

        public bool IsEqualTo(TCircle other)
        {
            if (other == null) return false;
            return Math.Abs(this.Radius - other.Radius) < 1e-7;
        }

        public bool IsGreaterThan(TCircle other)
        {
            if (other == null) return true;
            return this.Radius > other.Radius;
        }

        public bool IsLessThan(TCircle other)
        {
            if (other == null) return false;
            return this.Radius < other.Radius;
        }

        public static TCircle operator +(TCircle c1, TCircle c2)
        {
            double r1 = c1?.Radius ?? 0;
            double r2 = c2?.Radius ?? 0;
            return new TCircle(r1 + r2);
        }

        public static TCircle operator -(TCircle c1, TCircle c2)
        {
            double r1 = c1?.Radius ?? 0;
            double r2 = c2?.Radius ?? 0;
            double diff = r1 - r2;
            return new TCircle(diff >= 0 ? diff : 0);
        }

        public static TCircle operator *(TCircle c, double scalar)
        {
            double r = c?.Radius ?? 0;
            return new TCircle(r * scalar);
        }

        public static TCircle operator *(double scalar, TCircle c)
        {
            return c * scalar;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TCircle c1 = new TCircle();
            TCircle c2 = new TCircle(5.0);
            TCircle c3 = new TCircle(c2);

            Console.WriteLine("=== Тестування створених об'єктів ===");
            Console.Write("c1: "); c1.Print(); Console.WriteLine();
            Console.Write("c2: "); c2.Print(); Console.WriteLine();
            Console.Write("c3 (копія c2): "); c3.Print(); Console.WriteLine("\n");

            Console.WriteLine("=== Введення даних для c1 ===");
            c1.Input();
            Console.Write("Новий c1: "); c1.Print(); Console.WriteLine("\n");

            Console.WriteLine("=== Розрахунки для c2 (радіус = 5) ===");
            Console.WriteLine($"Довжина кола: {c2.GetLength():F2}");
            Console.WriteLine($"Площа кола: {c2.GetArea():F2}");
            Console.WriteLine($"Площа сектора (90 градусів)): {c2.GetSectorArea(90):F2}\n");

            Console.WriteLine("=== Порівняння кіл ===");
            if (c2.IsEqualTo(c3))
            {
                Console.WriteLine("c2 и c3 рівні.");
            }
            if (c1.IsGreaterThan(c2))
            {
                Console.WriteLine("c1 більше c2.");
            }
            else
            {
                Console.WriteLine("c1 менше або дорівнює c2.");
            }
            Console.WriteLine();

            Console.WriteLine("=== Тестування операторів +, -, * ===");
            TCircle cSum = c1 + c2;
            Console.Write("c1 + c2: "); cSum.Print(); Console.WriteLine();

            TCircle cDiff = c2 - new TCircle(2.0);
            Console.Write("c2 - 2.0: "); cDiff.Print(); Console.WriteLine();

            TCircle cMul = c2 * 2.5;
            Console.Write("c2 * 2.5: "); cMul.Print(); Console.WriteLine();

            Console.ReadLine();
        }
    }
}