using System.Text;

namespace TheDiamondKata;

public class Diamond
{
    // We only accept capital letters of the English alphabet
    private const char First = 'A';
    private const char Last = 'Z';
    private readonly char _space;

    private readonly string _errorMessage = $"Input character is not supported. Accepted characters are {First} to {Last}";

    private readonly StringBuilder _sb;

    public Diamond(char space = ' ')
    {
        _space = space;
        _sb = new StringBuilder();
    }

    public string Generate(char input)
    {
        if (input < First || input > Last) return _errorMessage;

        _sb.Clear();

        var offset = input - First;
        var rowsTotal = offset * 2 + 1;
        var middlePadding = -1;
        var sidePadding = offset;
        var symbol = First;
        var descending = true;

        for (var rowNumber = 1; rowNumber <= rowsTotal; rowNumber++)
        {
            var sidePart = new string(_space, sidePadding);

            if (rowNumber == 1 || rowNumber == rowsTotal)
            {
                _sb.AppendLine($"{sidePart}{symbol}{sidePart}");
            }
            else
            {
                var middlePart = new string(_space, middlePadding);
                _sb.AppendLine($"{sidePart}{symbol}{middlePart}{symbol}{sidePart}");
            }

            (symbol, middlePadding, sidePadding) = AdjustPaddingAndSymbol(descending, symbol, middlePadding, sidePadding);

            if (sidePadding == 0) descending = !descending;
        }

        return _sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
    }

    private (char symbol, int middlePadding, int sidePadding) AdjustPaddingAndSymbol(bool descending, char symbol, int middlePadding, int sidePadding)
    {
        if (descending)
        {
            symbol++;
            middlePadding += 2;
            sidePadding -= 1;
        }
        else
        {
            symbol--;
            middlePadding -= 2;
            sidePadding += 1;
        }

        return (symbol, middlePadding, sidePadding);
    }
}