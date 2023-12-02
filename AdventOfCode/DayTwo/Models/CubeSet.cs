namespace AdventOfCode;

public sealed record CubeSet(IEnumerable<Cube> Cubes)
{
    public bool Equals(CubeSet? obj)
    {
        if (obj is null)
        {
            return false;
        }

        return Enumerable.SequenceEqual(Cubes, obj.Cubes);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var cubesHashCodes = Cubes.Select(cube => cube.GetHashCode());
            var cubesHashCode = cubesHashCodes.Aggregate(486187739,
                (total, next) => total * 23 + next);

            return cubesHashCode;
        }
    }
}
