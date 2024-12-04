using System;

namespace HaromszogTipusaOOP
{
    class HTipus
    {
        private int a, b, c;

        public HTipus(int a, int b, int c)
        {
            
            if (a <= 0 || b <= 0 || c <= 0)
                throw new Exception("Az oldalhosszúságoknak pozitív számnak kell lenniük!");

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
            if (!ErvenyesHaromszog()) return 0;

            double s = (a + b + c) / 2.0;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;


            Console.WriteLine("Add meg a háromszög három oldalát:");


            a = GetValidInput("a");
            if (a == 0) return;


            b = GetValidInput("b");
            if (b == 0) return;


            c = GetValidInput("c");
            if (c == 0) return;

            try
            {
                HTipus haromszog = new HTipus(a, b, c);

                Console.WriteLine($"Érvényes háromszög: {haromszog.ErvenyesHaromszog()}");
                Console.WriteLine($"Derékszögű háromszög: {haromszog.DerekszoguHaromszog()}");
                Console.WriteLine($"Egyenlő szárú háromszög: {haromszog.EgyenloSzaruHaromszog()}");
                Console.WriteLine($"Egyenlő oldalú háromszög: {haromszog.EgyenloOldaluHaromszog()}");
                Console.WriteLine($"Terület: {haromszog.Terulet()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }

            Console.ReadLine();
        }


        static int GetValidInput(string side)
        {
            int value;
            while (true)
            {
                Console.Write($"{side}: ");
                string input = Console.ReadLine();

                try 
                {
                    int.TryParse(input, out value);
                        if (value <= 0)
                    {
                        return 0;
                    }
                }
                catch 
                {
                    Console.WriteLine("Hibás érték! Kérem, adjon meg egy pozitív számot.");
                    return 0;
                }

                return value;
            }

        }
    }
}
