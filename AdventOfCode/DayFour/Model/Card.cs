namespace AdventOfCode.DayFour.Model;

public sealed record Card(int Id, int[] WinningNumbers, int[] Numbers)
{
    public bool Equals(Card? obj)
    {
        if (obj is null)
        {
            return false;
        }

        return Id == obj.Id &&
            Enumerable.SequenceEqual(WinningNumbers, obj.WinningNumbers) &&
            Enumerable.SequenceEqual(Numbers, obj.Numbers);
    }

    public override int GetHashCode()
    {
        var winningHash = WinningNumbers.Aggregate(486187739,
                (total, next) => total * 23 + next);
        var numbereHash = Numbers.Aggregate(486187739,
                (total, next) => total * 23 + next);

        return HashCode.Combine(Id, winningHash, numbereHash);
    }
}
