using System.Runtime.CompilerServices;

namespace AdventOfCode.DayThree;

public class DayThreePuzzle
{
    private readonly SchematicParser _parser = new();

    public int PartNumberSum(string input)
    {
        var schematic = _parser.Parse(input);

        var partNumbers = new List<int>();

        List<int>? currentPartNumber = null;
        int numLines = schematic.GetLength(1);
        for (var y = 0; y < numLines; ++y)
        {
            int lineLength = schematic.GetLength(0);
            for (var x = 0; x < lineLength; ++x)
            {
                if (schematic[x,y].Digit is not null)
                {
                    currentPartNumber ??= [];
                    currentPartNumber.Add(schematic[x,y].Digit!.Value);
                }
                else if (currentPartNumber is not null)
                {
                    var isPartNumber = IsPartNumber(schematic, currentPartNumber, numLines, y, lineLength, x);

                    if (isPartNumber)
                    {
                        var partNumber = 0;
                        for (var index = 0; index < currentPartNumber.Count; ++index)
                        {
                            partNumber += currentPartNumber[^(index + 1)] * (int)Math.Pow(10, index);
                        }
                        partNumbers.Add(partNumber);
                    }
                    currentPartNumber = null;
                }
            }
        }

        return partNumbers.Sum();
    }

    private static bool IsPartNumber(SchematicItem[,] schematic, List<int> currentPartNumber,
        int numLines, int y, int lineLength, int x)
    {
        if (x is not 0 && schematic[x, y].IsSymbol)
        {
            return true;
        }

        (x, y) = MovePrevious(x, y, lineLength);

        // is there a symbol next to this part number?
        var beforeStartX = x - currentPartNumber.Count;
        if (beforeStartX >= 0 && schematic[beforeStartX, y].IsSymbol)
        {
            return true;
        }

        var xIndices = Enumerable.Range(beforeStartX, currentPartNumber.Count + 2)
            .Where(index => index >= 0 && index < lineLength)
            .ToArray();
        if (y < numLines - 1)
        {
            if (xIndices.Any(index => schematic[index, y + 1].IsSymbol))
            {
                return true;
            }
        }

        if (y > 0)
        {
            if (xIndices.Any(index => schematic[index, y - 1].IsSymbol))
            {
                return true;
            }
        }

        return false;
    }

    private static (int x, int y) MovePrevious(int x, int y, int lineLength)
    {
        if (x is 0)
        {
            return (lineLength - 1, y - 1);
        }

        return (x - 1, y);
    }
}
