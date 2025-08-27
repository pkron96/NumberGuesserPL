using System;
using System.Net.Mime;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();
            string userName = GetUserName();
            GreetUser(userName);
            Game();
        }

        static void GetAppInfo()
        {
            string appName = "Zgadywanie Liczb";
            int appVersion = 1;
            string appAuthor = "Patryk Kronberg";
            
            string info = $"[{appName}] Version {appVersion}, Author {appAuthor}";
            PrintColorMessage(ConsoleColor.Magenta, info);
        }

        static string GetUserName()
        {
            Console.WriteLine("Podaj imie:");
            string inputUserName = Console.ReadLine();
            return inputUserName;
        }

        static void GreetUser(string userName)
        {
            string message = $"Powodzenia {userName}, w naszej grze ...";
            PrintColorMessage(ConsoleColor.Cyan, message);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Game()
        {
            numbersRange(out int lower, out int upper, out int numberOfTries);
            int lowerNum = lower;
            int upperNum = upper;
            int guessNum = 0;
            int correctNumber = randomNumber(lowerNum, upperNum);
            bool correctAnswer = false;
            Console.WriteLine("Zgadnij liczbę: ");
            
            while (correctAnswer == false && guessNum < numberOfTries)
            {
                string input = Console.ReadLine();
                int guess;
                
                bool isNumber = int.TryParse(input, out guess);
                if (!isNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Wprowadź liczbę!");
                    continue;
                }

                if (guess < lowerNum || guess > upperNum)
                {
                    PrintColorMessage(ConsoleColor.Yellow, $"$Wprowadź {lowerNum}-{upperNum}!");
                    continue;
                }
                guessNum++;
                if (guess < correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Źle, wylosowana jest większa");
                    
                }
                else if (guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Źle, wylosowana jest mniejsza");
                    
                }
                else
                {
                    correctAnswer = true;
                    PrintColorMessage(ConsoleColor.Green, "Prawidłowa odpowiedź!!");
                    PrintColorMessage(ConsoleColor.Blue, $"Ilość prób: {guessNum}");
                }
                
                    
                
            }

            if (!correctAnswer)
            {
                PrintColorMessage(ConsoleColor.Red, "Przegrałeś!");
                Environment.Exit(0);
            }
           

        }

        static void numbersRange(out  int lowerNumber, out int upperNumber, out int numOfTries)
        {
            Console.WriteLine("Podaj najmniejszą liczbę z zakresu do odgadnięcia: ");
            lowerNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj największą liczbę z zakresu do odgadnięcia: ");
            upperNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ilość prób, które chcesz mieć: ");
            numOfTries = int.Parse(Console.ReadLine());
            
            if (upperNumber <= lowerNumber)
            {
                PrintColorMessage(ConsoleColor.Yellow, "Druga liczba powinna być większa niż pierwsza!");
                numbersRange(out lowerNumber,  out upperNumber, out numOfTries);
            }
           
        }

        static int randomNumber(int lowerNumber, int upperNumber)
        {
            Random random = new Random();

            int correctNumber = random.Next(lowerNumber, upperNumber+1);
            return correctNumber;
        }
    }
}