using AdventOfCode.DayThree;

namespace AdventOfCode.Tests;

public class DayThreeTests
{
    private readonly DayThreePuzzle _puzzle = new();

    [Fact]
    public void SampleInputWorks()
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

        var sum = _puzzle.PartNumberSum(sampleInput);

        Assert.Equal(4361, sum);
    }
}
