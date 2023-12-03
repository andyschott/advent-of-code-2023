namespace AdventOfCode.DayTwo;

public class DayTwoPuzzle : IPuzzle
{
    private readonly GameParser _parser = new();

    private readonly IReadOnlyDictionary<CubeColor, int> _totalCubes =
        new Dictionary<CubeColor, int>
        {
            [CubeColor.Red] = 12,
            [CubeColor.Green] = 13,
            [CubeColor.Blue] = 14
        };

    public int Id => 2;

    public int PartOne(string input)
    {
        var games = Parse(input);

        var possibleGames = games.Where(IsPossible);

        var result = possibleGames.Sum(game => game.Id);
        return result;
    }

    public int PartTwo(string input)
    {
        var games = Parse(input);

        var minCubes = games.Select(FindMinimumCubeCount);
        var powers = minCubes.Select(item => item[CubeColor.Red] * item[CubeColor.Green] * item[CubeColor.Blue]);
        var result = powers.Sum();

        return result;
    }

    private Game[] Parse(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.TrimEntries);
        var games = lines.Select(_parser.Parse)
            .ToArray();

        return games;
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

    private static IReadOnlyDictionary<CubeColor, int> FindMinimumCubeCount(Game game)
    {
        var cubesByColor = game.Sets.SelectMany(set => set.Cubes)
            .GroupBy(cube => cube.Color, cube => cube.Count);

        var minCubes = new Dictionary<CubeColor, int>();

        foreach (var group in cubesByColor)
        {
            minCubes[group.Key] = group.Max();
        }

        return minCubes;
    }
}
