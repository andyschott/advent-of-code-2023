﻿using AdventOfCode.DayTwo;

namespace AdventOfCode.Tests;

public class DayTwoTests
{
    private readonly DayTwoPuzzle _dayTwo = new();

    private static readonly string _sampleInput = string.Join(Environment.NewLine,
        [
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        ]);

    [Fact]
    public void IsPossible_SampleInputWorks()
    {
        var result = _dayTwo.PartOne(_sampleInput);

        Assert.Equal(8, result);
    }

    [Fact]
    public void MinimumCubes_SampleInputWorks()
    {
        var result = _dayTwo.PartTwo(_sampleInput);

        Assert.Equal(2286, result);
    }
}
