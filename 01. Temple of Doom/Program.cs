using System.Runtime.CompilerServices;

namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] toolsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> tools = new Queue<int>(toolsInput);

            int[] substanceInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> substances = new Stack<int>(substanceInput);

            List<int> challenges = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true) 
            {
                int tool = tools.Dequeue();
                int substance = substances.Pop();
                int result = tool * substance;

                if (challenges.Any(c => c == result))
                {
                    challenges.Remove(result);
                }
                else
                {
                    tools.Enqueue(tool+1);
                    if (substance - 1 > 0)
                    {
                        substances.Push(substance - 1);
                    }
                }
                if (challenges.Count <= 0)
                {
                    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                    break;
                }
                if (tools.Count <= 0 || substances.Count <= 0)
                {
                    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                    break;
                }
                
            }
            if (tools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }
            if (substances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }
            if (challenges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}