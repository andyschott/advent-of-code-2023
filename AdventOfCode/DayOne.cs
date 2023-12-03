namespace AdventOfCode;

public class DayOne : IPuzzle
{
    private readonly static IReadOnlyDictionary<string, int> _numberNameMap =
        new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
        {
            ["zero"] = 0,
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5,
            ["six"] = 6,
            ["seven"] = 7,
            ["eight"] = 8,
            ["nine"] = 9,
        };
    record ParsedNumber(char[] Chararacters, int Number);
    private readonly static ParsedNumber[] _parsedNumbers =
    [
        new ParsedNumber([.. "zero"], 0),
        new ParsedNumber([.. "one"], 1),
        new ParsedNumber([.. "two"], 2),
        new ParsedNumber([.. "three"], 3),
        new ParsedNumber([.. "four"], 4),
        new ParsedNumber([.. "five"], 5),
        new ParsedNumber([.. "six"], 6),
        new ParsedNumber([.. "seven"], 7),
        new ParsedNumber([.. "eight"], 8),
        new ParsedNumber([.. "nine"], 9)
    ];

    public int Id => 1;

    public int PartOne(string input) => Run(input);
    public int PartTwo(string input) => Run(input);

    private static int Run(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.TrimEntries);
        var parsed = lines.Select(Parse);

        var sum = parsed.Sum();
        return sum;
    }

    private static int Parse(string line)
    {
        var first = Enumerable.Range(0, line.Length)
            .Select(startingIndex => ParseForward(line, startingIndex))
            .SkipWhile(result => result is null)
            .FirstOrDefault();
        var backwardIndices = Enumerable.Range(1, line.Length);
        var last = Enumerable.Range(1, line.Length)
            .Select(startingIndex => ParseBackward(line, startingIndex))
            .SkipWhile(result => result is null)
            .FirstOrDefault();

        if (first is null || last is null)
        {
            throw new ArgumentException("Could not parse out a number", nameof(line));
        }

        return first.Value * 10 + last.Value;
    }

    private static int? ParseForward(string line, int startingIndex = 0)
    {
        var options = _parsedNumbers;
        for (int index = startingIndex, relativeIndex = 0; index < line.Length; ++index, ++relativeIndex)
        {
            if (char.IsDigit(line[index]))
            {
                return (int)char.GetNumericValue(line[index]);
            }

            options = options.Where(p => line[index] == p.Chararacters[relativeIndex])
                .ToArray();
            if (options.Length is 1 && relativeIndex == options[0].Chararacters.Length - 1)
            {
                return options[0].Number;
            }

            if (options.Length is 0)
            {
                return null;
            }
        }

        return null;
    }

    private static int? ParseBackward(string line, int startingIndex = 1)
    {
        var options = _parsedNumbers;
        for (int index = startingIndex, relativeIndex = 1; index <= line.Length; ++index, ++relativeIndex)
        {
            if (char.IsDigit(line[^index]))
            {
                return (int)char.GetNumericValue(line[^index]);
            }

            options = options.Where(p => line[^index] == p.Chararacters[^relativeIndex])
                .ToArray();
            if (options.Length is 1 && relativeIndex == options[0].Chararacters.Length)
            {
                return options[0].Number;
            }

            if (options.Length is 0)
            {
                return null;
            }
        }

        return null;
    }
}
