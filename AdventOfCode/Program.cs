using AdventOfCode;
using AdventOfCode.DayTwo;

var puzzle = new DayTwoPuzzle();

var partOne = puzzle.SumOfPossibleGames(Constants.Day2Input);
var partTwo = puzzle.MinimumCubes(Constants.Day2Input);

Console.WriteLine($"Part One: {partOne}");
Console.WriteLine($"Part Two: {partTwo}");
