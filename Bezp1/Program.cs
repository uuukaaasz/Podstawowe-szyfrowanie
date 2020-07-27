using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bezp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 9;
            do
            {
                Console.WriteLine("\n-------------------------------------------------------------------------------------------");
                Console.Write("Jaki szyfr chcesz użyć?\n1 - Szyfr Cezara\n2 - Szyfr rzymski\n3 - Szyfr macierzy\n0 - Wyjdź\nWybór: ");
                i = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("-------------------------------------------------------------------------------------------\n");
                if (i == 1) Szyfr_cezara();
                if (i == 2) Szyfr_rzymski();
                if (i == 3) Szyfr_macierzy();
            } while (i != 0);
            
        }

        public static void Szyfr_cezara()
        {
            Console.WriteLine(".......... SZYFR CEZARA ..........");
            Console.WriteLine("Podaj liczbę przesunięcia kodowania: ");
            int n = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("[Wciśnij ESCAPE żeby wrócić do menu]");
            Console.WriteLine("Wprowadź z klawiatury wiadomość do zaszyfrowania: ");
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.KeyChar >= 97 && keyInfo.KeyChar <= 122) //litery a-z
                {
                    char znak = (char)(((keyInfo.KeyChar - 97 + n) % 26) + 97);
                    Console.Write(znak);
                }
                if (keyInfo.KeyChar >= 64 && keyInfo.KeyChar <= 90) //litery A-Z
                {
                    char znak = (char)(((keyInfo.KeyChar - 64 + n) % 26) + 64);
                    Console.Write(znak);
                }
                if (keyInfo.KeyChar >= 48 && keyInfo.KeyChar <= 57) //cyfry 0-9
                {
                    char znak = (char)(((keyInfo.KeyChar - 48 + n) % 10) + 48);
                    Console.Write(znak);
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static void Szyfr_rzymski()
        {
            Console.WriteLine(".......... SZYFR RZYMSKI ..........");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("[Wciśnij ESCAPE żeby wrócić do menu]");
            Console.WriteLine("Wprowadź z klawiatury wiadomość do zaszyfrowania: ");
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.KeyChar >= 97 && keyInfo.KeyChar <= 122) //litery a-z
                {
                    char znak = (char)(97 + (25 - keyInfo.KeyChar + 97) % 26);
                    Console.Write(znak);
                }
                if (keyInfo.KeyChar >= 64 && keyInfo.KeyChar <= 90) //litery A-Z
                {
                    char znak = (char)(64 + (25 - keyInfo.KeyChar + 64) % 26);
                    Console.Write(znak);
                }
                if (keyInfo.KeyChar >= 48 && keyInfo.KeyChar <= 57) //cyfry 0-9
                {
                    char znak = (char)(48 + (9 - keyInfo.KeyChar + 48) % 10);
                    Console.Write(znak);
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static void Szyfr_macierzy()
        {
            Console.WriteLine(".......... SZYFR MACIERZY ..........");
            string[,] array1 = { { "A", "B", "C", "D", "E" }, { "F", "G", "H", "I", "J" }, { "K", "L", "M", "N", "O" }, { "P", "Q", "R", "S", "T" }, { "U", "V", "W", "X", "Y" } };
            string[,] array2 = new string[5, 5];
            Array.Clear(array2, 0, array2.Length);

            Console.Write("Czy chcesz zobaczyć tablicę jawną i zaszyfrowaną (t/n)? ");
            string x = Convert.ToString(Console.ReadLine());
            if (x == "t")
            {
                Console.WriteLine("Tablica jawna wygląda tak: ");
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.WriteLine("array1[{0},{1}]={2}", i, j, array1[i, j]);
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        array2[i, j] = array1[j, i];
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.WriteLine("array2[{0},{1}]={2}", i, j, array2[i, j]);
                    }
                }
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("[Wciśnij ESCAPE żeby wrócić do menu]");
            Console.WriteLine("Wprowadź z klawiatury wiadomość do zaszyfrowania: ");
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if(keyInfo.KeyChar.ToString().ToUpper() == array1[i, j])
                        {
                            Console.Write(array1[j, i]);
                        }
                    }
                }

            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}