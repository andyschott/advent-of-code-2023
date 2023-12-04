using AdventOfCode.DayFour;
using AdventOfCode.DayFour.Model;

namespace AdventOfCode.Tests.DayFour;

public class CardParserTests
{
    private readonly CardParser _parser = new();

    [Theory]
    [MemberData(nameof(ParseData))]
    public void Parse(string input, Card expectedCard)
    {
        var card = _parser.ParseCard(input);

        Assert.Equal(expectedCard, card);
    }

    public static TheoryData<string, Card> ParseData => new()
    {
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            new Card(1, [ 41, 48, 83, 86, 17 ], [ 83, 86, 6, 31, 17, 9, 48, 53] )
        },
        {
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            new Card(2, [ 13, 32, 20, 16, 61], [ 61, 30, 68, 82, 17, 32, 24, 19])
        },
        {
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            new Card(3, [ 1, 21, 53, 59, 44 ], [ 69, 82, 63, 72, 16, 21, 14, 1])
        },
        {
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            new Card(4, [ 41, 92, 73, 84, 69 ], [59, 84, 76, 51, 58, 5, 54, 83 ] )
        },
        {
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            new Card(5, [ 87, 83, 26, 28, 32 ], [ 88, 30, 70, 12, 93, 22, 82, 36 ])
        },
        {

            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            new Card(6, [ 31, 18, 13, 56, 72 ], [ 74, 77, 10, 23, 35, 67, 36, 11 ])
        }
    };
}
