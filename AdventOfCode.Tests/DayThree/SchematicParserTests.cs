using System.Text;
using AdventOfCode.DayThree;

namespace AdventOfCode.Tests;

public class SchematicParserTests
{
    private readonly SchematicParser _parser = new();

    [Fact]
    public void ParseSampleInputCorrectly()
    {
        const string sampleInput = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

        var result = _parser.Parse(sampleInput);

        var sampleInputLines = sampleInput.Split(Environment.NewLine, StringSplitOptions.TrimEntries);
        Assert.Equal(sampleInputLines.Length, result.GetLength(1));

        var lineLength = sampleInputLines[0].Length;
        Assert.Equal(lineLength, result.GetLength(0));

        var sb = new StringBuilder();
        for (var y = 0; y < result.GetLength(1); ++y)
        {
            for (var x = 0; x < result.GetLength(0); ++x)
            {
                if (result[x,y].Digit is not null)
                {
                    sb.Append(result[x,y].Digit!.Value);
                }
                else if (result[x,y].Symbol is not null)
                {
                    sb.Append(result[x,y].Symbol!.Value);
                }
                else
                {
                    sb.Append('.');
                }
            }
            sb.Append("\r\n");
        }

        Assert.Equal(sampleInput, sb.ToString().Trim());
    }
}
