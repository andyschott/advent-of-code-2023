using AdventOfCode.DayThree;

namespace AdventOfCode.Tests;

public class DayThreeTests
{
    private readonly DayThreePuzzle _puzzle = new();

        private const string SampleInput = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

    [Fact]
    public void SampleInputWorks()
    {
        var sum = _puzzle.PartOne(SampleInput);

        Assert.Equal(4361, sum);
    }

    [Fact]
    public void SumOfGearRatios_SampleInput_Works()
    {
        var sum = _puzzle.PartTwo(SampleInput);

        Assert.Equal(467835, sum);
    }
}
