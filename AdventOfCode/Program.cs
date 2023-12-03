using AdventOfCode;
using AdventOfCode.DayThree;

var puzzle = new DayThreePuzzle();

var partOne = puzzle.PartNumberSum(Constants.Day3Input);
var partTwo = puzzle.SumOfGearRatios(Constants.Day3Input);

Console.WriteLine($"Part One: {partOne}");
Console.WriteLine($"Part Two: {partTwo}");
