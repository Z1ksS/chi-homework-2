using System;

//Task 3
public class Books
{
    private int[] pages = new int[100];

    public Books()
    {
        Random rand = new Random();

        for (int i = 0; i < pages.Length; i++)
        {
            pages[i] = rand.Next(10, 1000);
        }
    }

    public int[] getBooksCatalog()
    {
        return pages;
    }

    public int GetBookByPages(int pageCount)
    {
        int book = -1;

        for (int i = 0; i < pages.Length; i++)
        {
            if (pageCount == pages[i])
            {
                book = i + 1;
            }
        }

        return book;
    }

    public int GetMaxPagesBook()
    {
        int maxPages = 0;
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i] > maxPages)
            {
                maxPages = pages[i];
            }
        }

        return maxPages;
    }
}

public class Programm
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Books booksArray = new Books();
        int maxPages = booksArray.GetMaxPagesBook();

        Console.WriteLine("Task 3");

        Console.WriteLine("Каталог книжок:");
        for(int i = 0; i < booksArray.getBooksCatalog().Length; i++)
        {
            Console.WriteLine($"Книжка {i + 1}, кількість сторінок: {booksArray.getBooksCatalog()[i]}");
        }

        Console.WriteLine($"Найбільш товста книжка є книга з номером {booksArray.GetBookByPages(maxPages)}, її кількість сторінок: {maxPages}");
    }
}