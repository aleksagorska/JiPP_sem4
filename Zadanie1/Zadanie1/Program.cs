using System;
class Zadanie1
{

    public static void Main(string[] args)
    {
        int UserNumber;
        Console.Write("Podaj liczbę od 1 do 1000: ");
        UserNumber = Convert.ToInt32(Console.ReadLine());
        while (UserNumber < 1 || UserNumber > 1000)
        {
            Console.Write("Uwaga! Liczba musi być w przedziale między 1 a 1000: ");
            UserNumber = Convert.ToInt32(Console.ReadLine());
        }

        string newWord = NumberToWord(UserNumber);
        int count;
        int totalCount = 0;
        for (int i = 1; i <= 1000; i++)
        {
            string letters = NumberToWord(i);
            string lettersOnly = letters.Replace(" ", "");
            count = lettersOnly.Length;
            totalCount = totalCount + count;
        }
        Console.WriteLine("Wprowadzona liczba to: " + newWord);
        Console.WriteLine("Ilość liter wykorzystana do opisania liczb od 1 do 1000 wynosi: " + totalCount);
    }
    public static string NumberToWord(int number)
    {
        string[] units = { "", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć", "dziesięć", "jedenaście", "dwanaście", "trzynaście", "czternaście", "piętnaście", "szesnaście", "siedemnaście", "osiemnaście", "dziewiętnaście" };
        string[] tens = { "", "", "dwadzieścia", "trzydzieści", "czterdzieści", "pięćdziesiąt", "sześćdziesiąt", "siedemdziesiąt", "osiemdziesiąt", "dziewięćdziesiąt" };
        string[] hundreds = { "", "sto", "dwieście", "trzysta", "czterysta", "pięćset", "sześćset", "siedemset", "osiemset", "dziewięćset", "tysiąc" };
        string words = "";

        if (number / 100 > 0)
        {
            words += hundreds[number / 100] + " ";
            number %= 100;
        }

        if (number > 0)
        {
            if (number < 20)
            {
                words += units[number];
            }
            else
            {
                words += tens[number / 10] + " ";
                number %= 10;
                if (number > 0)
                {
                    words += units[number];
                }
            }
        }
        return words;
    }
}
