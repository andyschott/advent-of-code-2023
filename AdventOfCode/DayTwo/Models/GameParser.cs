using System.Text.RegularExpressions;

namespace AdventOfCode;

public partial class GameParser
{
    private static readonly Regex _gameIdRegex = CreateGameIdRegex();
    private static readonly Regex _cubeRegex = CreateCubeRegex();

    public Game Parse(string input)
    {
        var idSeparator = input.IndexOf(':');
        var gameId = ParseGameId(input[..idSeparator]);

        var setsInput = input[(idSeparator+2)..].Split("; ");
        var cubeSets = setsInput.Select(ParseSet);

        return new Game(gameId, cubeSets.ToArray());
    }

    private static int ParseGameId(string input)
    {
        var match = _gameIdRegex.Match(input);
        return int.Parse(match.Groups["gameId"].Value);
    }

    private static CubeSet ParseSet(string input)
    {
        var cubes = input.Split(", ");
        
        var sets = cubes.Select(cube =>
        {
            var match = _cubeRegex.Match(cube);
            var number = int.Parse(match.Groups["number"].Value);
            var color = Enum.Parse<CubeColor>(match.Groups["color"].Value, true);

            return new Cube(color, number);
        });

        return new CubeSet(sets.ToArray());
    }

    [GeneratedRegex(@"Game (?<gameId>\d+)")]
    private static partial Regex CreateGameIdRegex();
    [GeneratedRegex(@"(?<number>\d+) (?<color>\w+)")]
    private static partial Regex CreateCubeRegex();
}
