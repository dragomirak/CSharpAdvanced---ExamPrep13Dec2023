using System;

namespace WormsAndHoles;

public class Program
{
    static void Main()
    {
        int[] wormsArray = ReadArray();
        int[] holesArray = ReadArray();

        Stack<int> worms = new Stack<int>(wormsArray);
        Queue<int> holes = new Queue<int>(holesArray);

        int matchesCount = 0;
        bool wormRemoved = false;
        while (worms.Count > 0 && holes.Count > 0)
        {
            int currentWorm = worms.Peek();
            int currentHole = holes.Peek();

            if (currentWorm == currentHole)
            {
                worms.Pop();
                matchesCount++;
            }
            else
            {
                int worm = worms.Pop() - 3;
                if (worm > 0)
                {
                    worms.Push(worm);
                }
                else
                {
                    wormRemoved = true;
                }
            }

            holes.Dequeue();
        }

        if (matchesCount == 0)
        {
            Console.WriteLine("There are no matches.");
        }
        else
        {
            Console.WriteLine($"Matches: {matchesCount}");
        }

        if (worms.Count == 0)
        {
            if (!wormRemoved)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else if (wormRemoved)
            {
                Console.WriteLine("Worms left: none");
            }
        }
        else if (worms.Count > 0)
        {
            Console.Write("Worms left: "); 
            while (worms.Count > 1)
            {
                Console.Write($"{worms.Pop()}, ");
            }

            Console.Write(worms.Pop());
            Console.WriteLine();
        }

        
        if (holes.Count == 0)
        {
            Console.WriteLine("Holes left: none");
        }
        else
        {
            Console.Write("Holes left: ");
            while (holes.Count > 1)
            {
                Console.Write($"{holes.Dequeue()}, ");
            }

            Console.Write(holes.Dequeue());
        }

    }

    private static int[] ReadArray()
    {
        return Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}