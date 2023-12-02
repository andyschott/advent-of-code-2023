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
}