namespace AdventOfCode;

public record SchematicItem
{
    public int? Digit { get; }
    public char? Symbol { get; }
    public bool IsBlank => Digit is null && Symbol == '.';
    public bool IsSymbol => Digit is null && Symbol != '.';

    public SchematicItem(int digit)
        : this(digit, null)
    {
    }

    public SchematicItem(char symbol)
        : this(null, symbol)
    {
    }

    private SchematicItem(int? digit, char? symbol)
    {
        Digit = digit;
        Symbol = symbol;
    }

    public override string ToString()
    {
        if (Digit is not null)
        {
            return Digit.Value.ToString();
        }

        if (Symbol is not null)
        {
            return Symbol.Value.ToString();
        }

        return ".";
    }
}
