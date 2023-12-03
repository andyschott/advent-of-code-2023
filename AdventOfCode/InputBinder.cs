using System.CommandLine;
using System.CommandLine.Binding;

namespace AdventOfCode;

public class InputBinder : BinderBase<string>
{
    private readonly Argument<int> _dayArgument;

    public InputBinder(Argument<int> dayArgument)
    {
        _dayArgument = dayArgument;
    }

    protected override string GetBoundValue(BindingContext bindingContext)
    {
        var day = bindingContext.ParseResult.GetValueForArgument(_dayArgument);

        return PuzzleInput.GetInput(day);
    }
}
