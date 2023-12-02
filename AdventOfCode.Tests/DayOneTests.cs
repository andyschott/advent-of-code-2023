namespace AdventOfCode.Tests;

public class DayOneTests
{
    private readonly DayOne _dayOne = new();

    [Fact]
    public void SampleInputWorks()
    {
        string sampleInput = string.Join(Environment.NewLine,
            new[]
            {
               "1abc2",
               "pqr3stu8vwx",
               "a1b2c3d4e5f",
               "treb7uchet"
            });

            var result = _dayOne.Run(sampleInput);

            Assert.Equal(142, result);
    }

    [Fact]
    public void PartTwoSampleInputWorks()
    {
        var sampleInput = string.Join(Environment.NewLine,
            new[]
            {
                "two1nine",
                "eightwothree",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen"
            });

        var result = _dayOne.Run(sampleInput);

        Assert.Equal(281, result);
    }

    [Theory]
    [InlineData("4mmbddbxnb", 44)]
    public void FixErrors(string input, int expectedResult)
    {
        var result = _dayOne.Run(input);

        Assert.Equal(expectedResult, result);
    }
}