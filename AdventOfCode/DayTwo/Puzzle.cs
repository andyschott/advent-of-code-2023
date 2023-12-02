namespace AdventOfCode.DayTwo;

public class Puzzle : IPuzzle
{
    private readonly GameParser _parser = new();

    private readonly IReadOnlyDictionary<CubeColor, int> _totalCubes =
        new Dictionary<CubeColor, int>
        {
            [CubeColor.Red] = 12,
            [CubeColor.Green] = 13,
            [CubeColor.Blue] = 14
        };

    public int Run(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.TrimEntries);
        var games = lines.Select(_parser.Parse)
            .ToArray();

        var possibleGames = games.Where(IsPossible);

        var result = possibleGames.Sum(game => game.Id);
        return result;
    }

    private bool IsPossible(Game game)
    {
        return game.Sets.All(set =>
        {
            foreach (var cube in set.Cubes)
            {
                var totalCubes = _totalCubes[cube.Color];
                if (cube.Count > totalCubes)
                {
                    return false;
                }
            }

            return true;
        });
    }
}
