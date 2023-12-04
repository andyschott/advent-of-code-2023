using System.Text.RegularExpressions;
using AdventOfCode.DayFour.Model;

namespace AdventOfCode.DayFour;

public partial class CardParser
{
    private readonly Regex _cardRegex = CreateCardRegex();

    public IEnumerable<Card> Parse(string input)
    {
        var lines = input.Split(Environment.NewLine);
        return lines.Select(ParseCard)
            .ToArray();
    }

    public Card ParseCard(string input)
    {
        var m = _cardRegex.Match(input);
        var id = int.Parse(m.Groups["id"].Value);
        var winningNumbers = ParseNumbers(m.Groups["winning"].Value);
        var numbers = ParseNumbers(m.Groups["numbers"].Value);

        return new Card(id, winningNumbers, numbers);
    }

    private static int[] ParseNumbers(string str)
    {
        return str.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => int.Parse(s))
            .ToArray();
    }

    [GeneratedRegex(@"Card (?<id>\d+)\: (?<winning>.+) \| (?<numbers>.+)")]
    private static partial Regex CreateCardRegex();
}
