using System;

namespace KEAOpgave5._3
{
    class Program
    {
        static void Main(string[] args)
        {
            // CPR numbers can be checked with a given control-number: 4327654321

            // variables
            string date = "";
            int a, b, c, d, e1, f, dateSum, sum = 0;

            // date cant be spaces but needs a length of six
            while (string.IsNullOrWhiteSpace(date) && date.Length != 6)
            {
                // info
                Console.Clear();
                Console.WriteLine("Type in a date, and we'll print out all available CPR-numbers for the date.");
                Console.WriteLine("Date formats accepted: dd-MM-YY, dd.MM.YY, dd/MM/YY, ddMMYY");
                date = Console.ReadLine(); // applies input to date

                if (date.Contains("/")) // if the user used slash as seperator
                    date = date.Replace("/", "").Trim(); // trims white space and removes slashs

                else if (date.Contains("-")) // if the user used hyphen as seperator
                    date = date.Replace("-", "").Trim(); // trims white space and removes hyphens

                else if (date.Contains(".")) // if the user used period as seperator
                    date = date.Replace(".", "").Trim(); // trims white space and removes periods
                else
                    date = date.Trim(); // removes whitespace
            }

            Console.Clear(); 

            // Converts specific parts of date to interger and applies to variables
            a = Convert.ToInt32(date.Substring(0, 1));
            b = Convert.ToInt32(date.Substring(1, 1));
            c = Convert.ToInt32(date.Substring(2, 1));
            d = Convert.ToInt32(date.Substring(3, 1));
            e1 = Convert.ToInt32(date.Substring(4, 1));
            f = Convert.ToInt32(date.Substring(5, 1));

            dateSum = 4 * a + 3 * b + 2 * c + 7 * d + 6 * e1 + 5 * f; // the sum of the date with part of the control-number

            // going through the four last digits in the cpr number from 0-9
            for (int g = 0; g < 9; g++) 
                for (int h = 0; h < 9; h++)
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                        {
                            sum = dateSum + 4 * g + 3 * h + 2 * i + 1 * j; // adds the sum of the date with control numbers and the last for digits of cpr to sum

                            if (!(sum % 11 == 0)) // just keeps going when there isnt a valid cpr-number
                                continue;
                            else if (sum % 11 == 0) // if nothing is left over in sum after division the number is a valid cpr number and it prints
                                Console.WriteLine($"{a}{b}{c}{d}{e1}{f}-{g}{h}{i}{j}"); // print
                                Console.ReadLine(); // we force the user to press enter every time they want to see the next valid cpr number - mwahahahahahaa
                        }
            Console.ReadLine();
        }
    }
}
