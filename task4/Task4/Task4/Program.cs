using System;
using System.Collections;

public interface IRandomizable 
{
    void RandomizeArray();
}

public abstract class ArrayExtension
{
    protected int[] values;

    public virtual int GetMaxValue()
    {
        int max = 0;
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] > max)
            {
                max = values[i];
            }
        }
        return max;
    }

    public int GetIndexByValue(int value)
    {
        int index = -1;

        for (int i = 0; i < values.Length; i++)
        {
            if (value == values[i])
            {
                index = i + 1;
            }
        }

        return index;
    }

    public int[] getArray()
    {
        return values;
    }
}

//Task 3
public class Books: ArrayExtension, IRandomizable
{
    public Books()
    {
        values = new int[100];

        RandomizeArray();
    }

    public void RandomizeArray()
    {
        Random rand = new Random();

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = rand.Next(10, 1000);
        }
    }
}

//Task 4
public class Cars: ArrayExtension, IRandomizable
{
    private Dictionary<int, int> carsMaxSpeed = new Dictionary<int, int>();

    public Cars()
    {
        values = new int[40];
        RandomizeArray();
        GetMaxValue();
    }

    public void RandomizeArray()
    {
        Random rand = new Random();

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = rand.Next(100, 300);
        }
    }

    public Dictionary<int, int> getCarsSpeed()
    {
        return carsMaxSpeed;
    }

    public override int GetMaxValue()
    {
        int maxSpeed = values[0];

        for (int i = 0; i < values.Length; i++)
        {
            if (maxSpeed < values[i])
            {
                maxSpeed = values[i];
            }
        }

        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] == maxSpeed)
            {
                carsMaxSpeed.Add(i, values[i]);
            }
        }

        return 0;
    }

} 

public class Programm
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Task 3");
        Books booksArray = new Books();
        int maxPages = booksArray.GetMaxValue();

        Console.WriteLine("Каталог книжок:");
        for (int i = 0; i < booksArray.getArray().Length; i++)
        {
            Console.WriteLine($"Книжка {i + 1}, кількість сторінок: {booksArray.getArray()[i]}");
        }

        Console.WriteLine($"Найбільш товста книжка є книга з номером {booksArray.GetIndexByValue(maxPages)}, її кількість сторінок: {maxPages}");

        Console.WriteLine();

        Console.WriteLine("Task 4");
        Cars carArray = new Cars();

        Console.WriteLine("Каталог авто:");
        for (int i = 0; i < carArray.getArray().Length; i++)
        {
            Console.WriteLine($"Авто {i + 1}, швидкість: {carArray.getArray()[i]}");
        }

        foreach (var item in carArray.getCarsSpeed())
        {
            Console.WriteLine($"Найшвидше авто з номером {item.Key} її швидкість становить {item.Value}"); 
        }
    }
}