using System;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;


namespace ИГРА____
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameLogic();
        }  // ИГРА !!!
        static char[,] Map()
        {
            char[,] map =
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };
            return map;
        }   // Карта
        static void GameLogic()
        {

            Console.SetCursorPosition(0, 0);
            int X = 1, Y = 2;
            char[,] map = Map();
            bool IsTrue = true;
            bool isTRue = true;
            int l = RandomEscapeX();
            int m = RandomEscapeY();
            while (IsTrue && isTRue == true)
            {
                Console.SetCursorPosition(0, 0);
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    for (int y = 0; y < map.GetLength(1); y++)
                    {
                        Console.Write(map[x, y]);
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(X, Y);
                Console.Write('@');
                ConsoleKeyInfo Key = Console.ReadKey();
                if (l == X && m == Y)
                {
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("You want leave?");
                    Console.WriteLine("1 - Yes\n\n2 - No");
                    int leave = Convert.ToInt32(Console.ReadLine());
                    switch (leave)
                    {
                        case 1:

                            isTRue = false;

                            break;
                        case 2:
                            Console.SetCursorPosition(X, Y);
                            Console.Write('%');
                            break;
                    }
                    Console.Clear();
                }
                switch (Key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[Y - 1, X] != '#')
                        {
                            Y--;

                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[Y + 1, X] != '#')
                        {
                            Y++;

                        }
                        break;
                    case (ConsoleKey.LeftArrow):
                        if (map[Y, X - 1] != '#')
                        {
                            X--;

                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[Y, X + 1] != '#')
                        {
                            X++;

                        }
                        break;
                }
                Console.SetCursorPosition(0, 14);
                Console.WriteLine(X + " - user x");
                Console.WriteLine(Y + " - user y");
                IsTrue = Fight();


            }


        }   // Логика игры
        static bool Fight()
        {

            bool Esc = true;
            int RandomEnemyDrop()
            {
                int E;
                Random Rand = new Random();
                E = Rand.Next(1, 10);
                return E;
            }           // шанс врага
            int RandomEnemyClass()
            {
                int E;
                Random Rand1 = new Random();
                E = Rand1.Next(1, 6);
                return E;
            }
            if (RandomEnemyDrop() == 1)
            {
                Console.Clear();
                switch (RandomEnemyClass())
                {
                    case 1:
                        Console.SetCursorPosition(0, 3);
                        Console.Write("Это обычный зомби...");
                        FightVS(enemyJust.Damage, enemyJust.Health, ref Hero.Health, ref Hero.Damage);
                        if (Hero.Health <= 0)
                        {
                            Esc = false;
                        }
                        break;
                    case 2:
                        Console.SetCursorPosition(0, 3);
                        Console.Write("Это обычный зомби...");
                        FightVS(enemyJust.Damage, enemyJust.Health, ref Hero.Health, ref Hero.Damage);
                        if (Hero.Health <= 0)
                        {
                            Esc = false;
                        }
                        break;
                    case 3:
                        Console.SetCursorPosition(0, 3);
                        Console.Write("Это обычный зомби...");
                        FightVS(enemyJust.Damage, enemyJust.Health, ref Hero.Health, ref Hero.Damage);
                        if (Hero.Health <= 0)
                        {
                            Esc = false;
                        }
                        break;
                    case 4:
                        Console.SetCursorPosition(0, 3);
                        Console.Write("Это бронированный зомби");
                        FightVS(enemyArcher.Damage, enemyArcher.Health, ref Hero.Health, ref Hero.Damage);
                        if (Hero.Health <= 0)
                        {
                            Esc = false;
                        }
                        break;
                    case 5:
                        Console.SetCursorPosition(0, 3);
                        Console.Write("Это бронированный зомби");
                        FightVS(enemyArcher.Damage, enemyArcher.Health, ref Hero.Health, ref Hero.Damage);
                        if (Hero.Health <= 0)
                        {
                            Esc = false;
                        }
                        break;
                    case 6:
                        Console.SetCursorPosition(0, 3);
                        Console.Write("Это лучник!!!");
                        FightVS(enemyArmored.Damage, enemyArmored.Health, ref Hero.Health, ref Hero.Damage);
                        if (Hero.Health <= 0)
                        {
                            Esc = false;
                        }
                        break;
                }


            }
            return Esc;
        } // логическая составляющая боя 
        static int FightVS(int enemyDamage, int enemyHealth, ref int HeroHealth, ref int heroDamage)
        {

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Round");
            Random rand = new Random();
            Console.SetCursorPosition(0, 5);
            while (HeroHealth > 0 && enemyHealth > 0)
            {

                Console.SetCursorPosition(0, 5);
                HealthBar((HeroHealth / 10), 10, ConsoleColor.Red, 0);
                Console.WriteLine();
                Console.WriteLine("Your Avarage Damage is: " + heroDamage);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("\n\nБой");
                Console.ReadKey();
                heroDamage = rand.Next(heroDamage - 4, heroDamage + 4);
                enemyDamage = rand.Next(enemyDamage - 4, enemyDamage + 4);
                if (enemyDamage < 0)
                {
                    enemyDamage = 0;
                }
                if (heroDamage < 0)
                {
                    heroDamage = 0;
                }
                HeroHealth -= enemyDamage;
                enemyHealth -= heroDamage;
                Console.WriteLine($"ТЫ получил урон равный {enemyDamage}, у ТЕБЯ осталось {HeroHealth} здоровья");
                Console.WriteLine($"ВРАГ получил урон равный {heroDamage}, у ВРАГА осталось {enemyHealth} здоровья");
                if (HeroHealth <= 0)
                {
                    Console.WriteLine("You DIED");
                    break;

                }
                else if (enemyHealth <= 0)
                {
                    Console.WriteLine("Вы выжили чтобы умереть в следующий раз");

                }
                else if (enemyHealth == HeroHealth)
                {
                    Console.WriteLine("Ничья, ваш бой не имел смысла");


                }
                else if (enemyHealth > 0 && enemyDamage > 0)
                {
                    Console.WriteLine("Вы скрестили мечи и оба выжили, противник не отступает");
                }
                Console.SetCursorPosition(0, 5);
                HealthBar((HeroHealth / 10), 10, ConsoleColor.Red, 0);
                Console.SetCursorPosition(0, 0);

                Console.ReadKey();
                Console.Clear();
            }
            return HeroHealth;
        } // сам бой 
        static void HealthBar(int Value, int MaxValue, ConsoleColor color, int position)
        {
            ConsoleColor defoultColor = Console.BackgroundColor;
            string bar = "";
            for (int i = 0; i < Value; i++)
            {
                bar += " ";
            }
            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defoultColor;

            bar = "";

            for (int b = Value; b < MaxValue; b++)
            {
                bar += " ";
            }
            Console.Write(bar + "]");

        } // отрисовка полоски здоровья
        static int RandomEscapeX()
        {

            char[,] map = Map();
            int p;

            Random rand = new Random();
            p = rand.Next(2, map.GetLength(0) - 2);
            return p;
        }   //Случайная координата выхода по оси Ox
        static int RandomEscapeY()
        {
            char[,] map = Map();
            int q;
            Random rand = new Random();
            q = rand.Next(2, map.GetLength(1) - 2);
            return q;
        }   //Случайная координата выхода по оси Oy

    }

    public class Hero
    {
        public static int Health = 100;
        public static int Damage = 23;
    }
    public class enemyJust
    {
        public static int Health = 60;
        public static int Armor = 2;
        public static int Damage = 10;
    }
    public class enemyArmored
    {
        public static int Health = 120;
        public static int Armor = 5;
        public static int Damage = 7;
    }
    public class enemyArcher
    {
        public static int Health = 45;
        public static int Armor = 3;
        public static int Damage = 12;
    }


}
