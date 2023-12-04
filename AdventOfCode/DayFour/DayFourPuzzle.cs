using System.Security.Cryptography;
using AdventOfCode.DayFour.Model;

namespace AdventOfCode.DayFour;

public class DayFourPuzzle : IPuzzle
{
    private readonly CardParser _parser = new();

    public int Id => 4;

    public int PartOne(string input)
    {
        var cards = _parser.Parse(input);

        var scores = cards.Select(GetScore);

        return scores.Sum();
    }

    public int PartTwo(string input)
    {
        var cards = _parser.Parse(input)
            .ToDictionary(card => card.Id);

        var workQueue = new Queue<Card>(cards.Values);

        int copiesObtained = 0;
        while (workQueue.Count > 0)
        {
            var card = workQueue.Dequeue();
            var numMatches = GetNumberMatches(card);

            if (numMatches is 0)
            {
                continue;
            }

            copiesObtained += numMatches;

            var cardCopies = Enumerable.Range(card.Id + 1, numMatches)
                .Select(id => cards[id]);
            foreach (var copy in cardCopies)
            {
                workQueue.Enqueue(copy);
            }
        }

        return cards.Count + copiesObtained;
    }

    private static int GetNumberMatches(Card card)
    {
        var intersection = card.Numbers.Intersect(card.WinningNumbers);

        return intersection.Count();
    }

    private static int GetScore(Card card)
    {
        var intersection = card.Numbers.Intersect(card.WinningNumbers)
            .ToArray();

        return intersection switch
        {
            [] => 0,
            [_] => 1,
            _ => (int)Math.Pow(2, intersection.Length - 1)
        };
    }
}
