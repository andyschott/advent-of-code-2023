namespace AdventOfCode.Tests;

public class GameParserTests
{
    private readonly GameParser _parser = new();

    public static TheoryData<string, Game> TestInput => new()
    {
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            new Game(1, [
                [ new Cube(CubeColor.Blue, 3), new Cube(CubeColor.Red, 4)],
                [ new Cube(CubeColor.Red, 1), new Cube(CubeColor.Green, 2), new Cube(CubeColor.Blue, 6)],
                [ new Cube(CubeColor.Green, 2)]
            ])
        },
        {
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            new Game(2, [
                [ new Cube(CubeColor.Blue, 1), new Cube(CubeColor.Green, 2)],
                [ new Cube(CubeColor.Green, 3), new Cube(CubeColor.Blue, 4), new Cube(CubeColor.Red, 1)],
                [ new Cube(CubeColor.Green, 1), new Cube(CubeColor.Blue, 1)],
            ])
        },
        {
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            new Game(3, [
                [ new Cube(CubeColor.Green, 8), new Cube(CubeColor.Blue, 6), new Cube(CubeColor.Red, 20)],
                [ new Cube(CubeColor.Blue, 5), new Cube(CubeColor.Red, 4), new Cube(CubeColor.Green, 13)],
                [ new Cube(CubeColor.Green, 5), new Cube(CubeColor.Red, 1)],
            ])
        },
        {
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            new Game(4, [
                [ new Cube(CubeColor.Green, 1), new Cube(CubeColor.Red, 3), new Cube(CubeColor.Blue, 6)],
                [ new Cube(CubeColor.Green, 3), new Cube(CubeColor.Red, 6)],
                [ new Cube(CubeColor.Green, 3), new Cube(CubeColor.Blue, 15), new Cube(CubeColor.Red, 14)],
            ])
        },
        {
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
            new Game(5, [
                [ new Cube(CubeColor.Red, 6), new Cube(CubeColor.Blue, 1), new Cube(CubeColor.Green, 3)],
                [ new Cube(CubeColor.Blue, 2), new Cube(CubeColor.Red, 1), new Cube(CubeColor.Green, 2)],
            ])
        }
    };

    [Theory, MemberData(nameof(TestInput))]
    public void ParseSuccessfully(string input, Game expectedResult)
    {
        var result = _parser.Parse(input);

        Assert.Equal(expectedResult, result);
    }
}
