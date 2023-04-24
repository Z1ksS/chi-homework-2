using System;

//Task 1
public class TextMain
{
    private string text;

    public TextMain(string text)
    {
        this.text = text;
    }

    public string GetText()
    {
        return text;
    }

    // Task 1.1
    public int SumOfDigits()
    {
        int sum = 0;

        foreach (char c in this.text)
        {
            if (char.IsDigit(c))
            {
                sum += int.Parse(c.ToString());
            }
        }

        return sum;
    }


    //Task 1.2
    public int MaxDigit()
    {
        int maxDigit = 0;

        foreach (char c in this.text)
        {
            if (char.IsDigit(c))
            {
                int digit = int.Parse(c.ToString());

                if (digit > maxDigit)
                {
                    maxDigit = digit;
                }
            }
        }

        return maxDigit;
    }
}

//Task 2
public class TextWithSpaces : TextMain
{
    public TextWithSpaces(string text) : base(text) { }

    public int MaxDigitIndex()
    {
        int maxDigitIndx = 0;
        int maxDigit = 0;

        string text = GetText().Trim();

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            if (char.IsDigit(c))
            {
                int digit = int.Parse(c.ToString());

                if (digit > maxDigit)
                {
                    maxDigit = digit;
                    maxDigitIndx = i + 1;
                }
            }
        }

        return maxDigitIndx;
    }
}

public class Programm
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Task 1");
        Console.WriteLine("Введіть перевіричний текст без пробілів");
        string text = Console.ReadLine();
        TextMain analyze = new TextMain(text);

        Console.WriteLine($"Сума цифр у тексті: {analyze.SumOfDigits()} ");
        Console.WriteLine($"Максимальна цифра у тексті: {analyze.MaxDigit()} ");

        Console.WriteLine();

        Console.WriteLine("Task 2");
        Console.WriteLine("Введіть перевіричний текст з пробілами"); // Перевірка 9 4 8 9 2
        string text2 = Console.ReadLine();
        TextWithSpaces analyze2 = new TextWithSpaces(text2);

        Console.WriteLine($"Порядковий номер максимальної цифри у тексті: {analyze2.MaxDigitIndex()} ");
    }
}