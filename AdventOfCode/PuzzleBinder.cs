using System.CommandLine;
using System.CommandLine.Binding;

namespace AdventOfCode;

public class PuzzleBinder : BinderBase<IPuzzle>
{
    private readonly IReadOnlyDictionary<int, IPuzzle> _puzzles;
    private readonly Argument<int> _dayArgument;

    public PuzzleBinder(IEnumerable<IPuzzle> puzzles,
        Argument<int> dayArgument)
    {
        _puzzles = puzzles.ToDictionary(puzzle => puzzle.Id);
        _dayArgument = dayArgument;
    }

    protected override IPuzzle GetBoundValue(BindingContext bindingContext)
    {
        var day = bindingContext.ParseResult.GetValueForArgument(_dayArgument);
        var puzzle = _puzzles.GetValueOrDefault(day);

        if (puzzle is not null)
        {
            return puzzle;
        }

        throw new Exception($"Could not find puzzle with ID {day}");
    }
}
