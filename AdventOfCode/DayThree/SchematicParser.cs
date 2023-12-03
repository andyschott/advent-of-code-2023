namespace AdventOfCode.DayThree;

public class SchematicParser
{
    public SchematicItem[,] Parse(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.TrimEntries);

        // assuming all lines are the same length
        var schematic = new SchematicItem[lines[0].Length, lines.Length];

        for (var y = 0; y < lines.Length; ++y)
        {
            for (var x = 0; x < lines[y].Length; ++x)
            {
                if (char.IsDigit(lines[y][x]))
                {
                    schematic[x,y] = new SchematicItem((int)char.GetNumericValue(lines[y][x]));
                }
                else
                {
                    schematic[x,y] = new SchematicItem(lines[y][x]);
                }
            }
        }

        var xLen = schematic.GetLength(0);
        var yLen = schematic.GetLength(1);
        return schematic;
    }
}
