using System.CommandLine;
using AdventOfCode;
using AdventOfCode.DayFour;
using AdventOfCode.DayThree;
using AdventOfCode.DayTwo;

var rootCommand = new RootCommand();

var dayArgument = new Argument<int>(() => DateTime.Now.Day);
rootCommand.AddArgument(dayArgument);

var puzzleBinder = new PuzzleBinder(new IPuzzle[]
{
    new DayOne(),
    new DayTwoPuzzle(),
    new DayThreePuzzle() ,
    new DayFourPuzzle()
}, dayArgument);

var inputBinder = new InputBinder(dayArgument);

rootCommand.SetHandler(async (puzzle, input) =>
{
    var partOneTask = Task.Run(() => puzzle.PartOne(input));
    var partTwoTask = Task.Run(() => puzzle.PartTwo(input));

    Console.WriteLine($"Part One: {await partOneTask}");
    Console.WriteLine($"Part Two: {await partTwoTask}");
}, puzzleBinder, inputBinder);

rootCommand.Invoke(args);
