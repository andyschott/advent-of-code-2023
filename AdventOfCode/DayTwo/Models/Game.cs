namespace AdventOfCode;

public sealed record Game(int Id, IEnumerable<CubeSet> Sets)
{
    public Game(int id, Cube[][] cubes)
        : this(id, cubes.Select(set => new CubeSet(set)).ToArray())
    {
    }

    public bool Equals(Game? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (Id != obj.Id)
        {
            return false;
        }

        return Enumerable.SequenceEqual(Sets, obj.Sets);
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            var setsHashCodes = Sets.Select(set => set.GetHashCode());
            var setsHashCode = setsHashCodes.Aggregate(486187739,
                (total, next) => total * 23 + next);

            return HashCode.Combine(Id.GetHashCode(), setsHashCode);
        }
    }
}
