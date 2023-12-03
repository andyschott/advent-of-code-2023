namespace AdventOfCode;

public interface IPuzzle
{
    int Id { get; }
    int PartOne(string input);
    int PartTwo(string input);
}
