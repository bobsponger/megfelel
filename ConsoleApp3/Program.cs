using System;

namespace HaromszogTipusaOOP

{

    class HTipus

    {

        private int a, b, c;

        public HTipus(int a, int b, int c)

        {

            this.a = a;

            this.b = b;

            this.c = c;

        }

        public bool ErvenyesHaromszog()

        {

            return (a + b > c) && (a + c > b) && (b + c > a);

        }

        public bool DerekszoguHaromszog()

        {

            if (!ErvenyesHaromszog()) return false;

            int[] oldalak = { a, b, c };

            Array.Sort(oldalak);

            return (oldalak[0] * oldalak[0] + oldalak[1] * oldalak[1] == oldalak[2] * oldalak[2]);

        }

        public bool EgyenloSzaruHaromszog()

        {

            if (!ErvenyesHaromszog()) return false;

            return (a == b) || (a == c) || (b == c);

        }

        public bool EgyenloOldaluHaromszog()

        {

            if (!ErvenyesHaromszog()) return false;

            return (a == b) && (b == c);

        }

        public double Terulet()

        {

            if (!ErvenyesHaromszog()) throw new InvalidOperationException("Nem érvényes háromszög.");

            double s = (a + b + c) / 2.0;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("Add meg a háromszög három oldalát:");

            Console.Write("a: ");

            int a = int.Parse(Console.ReadLine());

            Console.Write("b: ");

            int b = int.Parse(Console.ReadLine());

            Console.Write("c: ");

            int c = int.Parse(Console.ReadLine());

            HTipus haromszog = new HTipus(a, b, c);

            Console.WriteLine($"Érvényes háromszög: {haromszog.ErvenyesHaromszog()}");

            Console.WriteLine($"Derékszögű háromszög: {haromszog.DerekszoguHaromszog()}");

            Console.WriteLine($"Egyenlő szárú háromszög: {haromszog.EgyenloSzaruHaromszog()}");

            Console.WriteLine($"Egyenlő oldalú háromszög: {haromszog.EgyenloOldaluHaromszog()}");

            Console.WriteLine($"Terület: {haromszog.Terulet()}");

            Console.ReadLine(); // Hozzáadva, hogy a konzolablak nyitva maradjon

        }

    }

}

