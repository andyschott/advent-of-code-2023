namespace AdventOfCode;

public class DayOne
{
    public int Run(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var parsed = lines.Select(Parse);
        
        var sum = parsed.Sum();
        return sum;
    }

    private static int Parse(string str)
    {
        var firstDigit = str.SkipWhile(ch => !char.IsDigit(ch))
            .FirstOrDefault();
        var lastDigit = str.Reverse()
            .SkipWhile(ch => !char.IsDigit(ch))
            .FirstOrDefault();

        return int.Parse($"{firstDigit}{lastDigit}");
    }
}
