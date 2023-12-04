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

    public int PartTwo(string input)
    {
        return 0;
    }
}
