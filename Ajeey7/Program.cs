using System;

namespace EnkelKalkylator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Välkommen till kalkylatorn!");
                    Console.WriteLine("Välj en operation:");
                    Console.WriteLine("1: Addition");
                    Console.WriteLine("2: Subtraktion");
                    Console.WriteLine("3: Multiplikation");
                    Console.WriteLine("4: Division");
                    Console.WriteLine("5: Avsluta");

                    string val = Console.ReadLine();

                    if (val == "5")
                    {
                        Console.WriteLine("Tack för att du använde kalkylatorn! Hejdå!");
                        break; // Avslutar programmet
                    }

                    // Validera operation
                    if (!IsValidOperation(val))
                    {
                        Console.WriteLine("Ogiltigt val, vänligen försök igen.");
                        continue; // Återgå till början av loopen
                    }

                    double num1 = GetNumber("Ange första numret: ");
                    double num2 = GetNumber("Ange andra numret: ");

                    double resultat = PerformCalculation(val, num1, num2);
                    if (resultat != double.NaN)
                    {
                        Console.WriteLine($"Resultat: {resultat}");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Felaktig inmatning, vänligen ange ett giltigt nummer.");
                }

                Console.WriteLine();
            }
        }

        static bool IsValidOperation(string operation)
        {
            return operation == "1" || operation == "2" || operation == "3" || operation == "4";
        }

        static double GetNumber(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out number)) // Validera inmatningen
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning, vänligen ange ett giltigt nummer.");
                }
            }
        }

        static double PerformCalculation(string operation, double num1, double num2)
        {
            switch (operation)
            {
                case "1":
                    return num1 + num2; // Addition
                case "2":
                    return num1 - num2; // Subtraktion
                case "3":
                    return num1 * num2; // Multiplikation
                case "4":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Fel: Division med noll är inte tillåten.");
                        return double.NaN; // Returnera NaN för att indikera ett fel
                    }
                    return num1 / num2; // Division
                default:
                    return double.NaN; // Ogiltig operation
            }
        }
    }
}
