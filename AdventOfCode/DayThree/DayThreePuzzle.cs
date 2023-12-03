using System.Data;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace AdventOfCode.DayThree;

public class DayThreePuzzle
{
    private readonly SchematicParser _parser = new();

    public int PartNumberSum(string input)
    {
        var schematic = _parser.Parse(input);

        var partNumbers = new List<int>();

        TraverseSchematic(schematic,
            (partNumber, _, _) => partNumbers.Add(partNumber));

        return partNumbers.Sum();
    }

    public int SumOfGearRatios(string input)
    {
        var schematic = _parser.Parse(input);

        var possibleGearParts = new List<(int partNumber, int gearX, int gearY)>();
        TraverseSchematic(schematic,
            (partNumber, partX, partY) =>
            {
                if (schematic[partX, partY].Symbol is '*')
                {
                    possibleGearParts.Add((partNumber, partX, partY));
                }
            });

        var gears = possibleGearParts.GroupBy(item => (item.gearX, item.gearY),
            item => item.partNumber)
            .Select(gear => gear.ToArray())
            .Where(gear => gear.Length is 2);

        var sum = gears.Select(gear => gear[0] * gear[1])
            .Sum();
        return sum;
    }

    private void TraverseSchematic(SchematicItem[,] schematic, Action<int, int, int> callback)
    {
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
                    var (isPartNumber, partX, partY) = IsPartNumber(schematic, currentPartNumber, numLines, y, lineLength, x);

                    if (isPartNumber && partX is not null && partY is not null)
                    {
                        var partNumber = 0;
                        for (var index = 0; index < currentPartNumber.Count; ++index)
                        {
                            partNumber += currentPartNumber[^(index + 1)] * (int)Math.Pow(10, index);
                        }
                        callback(partNumber, partX.Value, partY.Value);
                    }
                    currentPartNumber = null;
                }
            }
        }
    }

    private static (bool isPartNumber, int? x, int? y) IsPartNumber(SchematicItem[,] schematic, List<int> currentPartNumber,
        int numLines, int y, int lineLength, int x)
    {
        if (x is not 0 && schematic[x, y].IsSymbol)
        {
            return (true, x, y);
        }

        (x, y) = MovePrevious(x, y, lineLength);

        // is there a symbol next to this part number?
        var beforeStartX = x - currentPartNumber.Count;
        if (beforeStartX >= 0 && schematic[beforeStartX, y].IsSymbol)
        {
            return (true, beforeStartX, y);
        }

        var xIndices = Enumerable.Range(beforeStartX, currentPartNumber.Count + 2)
            .Where(index => index >= 0 && index < lineLength)
            .ToArray();
        if (y < numLines - 1)
        {
            var symbolIndex = Find(xIndices, index => schematic[index, y + 1].IsSymbol);
            if (symbolIndex is not null)
            {
                return (true, symbolIndex.Value, y + 1);
            }
        }

        if (y > 0)
        {
            var symbolIndex = Find(xIndices, index => schematic[index, y - 1].IsSymbol);
            if (symbolIndex is not null)
            {
                return (true, symbolIndex.Value, y - 1);
            }
        }

        return (false, null, null);
    }

    private static (int x, int y) MovePrevious(int x, int y, int lineLength)
    {
        if (x is 0)
        {
            return (lineLength - 1, y - 1);
        }

        return (x - 1, y);
    }

    private static int? Find(int[] a, Predicate<int> filter)
    {
        for (var index = 0; index < a.Length; ++index)
        {
            if (filter(a[index]))
            {
                return a[index];
            }
        }

        return null;
    }
}
