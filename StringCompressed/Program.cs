using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the string of characters");
        string sequence = Console.ReadLine();
        string compressed = printStringCompressed(sequence);
        Console.WriteLine(compressed);

        if (sequence.Length > 256 || sequence.Length <= 0)
        {
            Console.WriteLine("the string must have more than 0 characters and less than 256");
            Environment.Exit(1);
        }
    }

    static string printStringCompressed(string sequence)
    {
        if (string.IsNullOrEmpty(sequence))
        {
            return sequence;
        }
        foreach (char c in sequence)
        {
            if (char.IsDigit(c))
            {
                Console.WriteLine("the string must not contain numbers");
                Environment.Exit(1);
            }
            if (char.IsSymbol(c))
            {
                Console.WriteLine("the string must not contain special characters");
                Environment.Exit(1);
            }
        }

        StringBuilder compressed = new StringBuilder();
        int count = 1;
        for (int i = 1; i <= sequence.Length; i++)
        {
            if (i == sequence.Length || sequence[i] != sequence[i - 1])
            {
                compressed.Append(sequence[i - 1]);
                compressed.Append(count);
                count = 1;
            }
                count++;
        }
        Console.WriteLine("the compression result of the sequence is:");
        return compressed.Length < sequence.Length ? compressed.ToString() : sequence;
    }
}