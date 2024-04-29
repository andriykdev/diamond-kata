namespace TheDiamondKata;

internal class Program
{
    static void Main(string[] args)
    {
        var diamond = new Diamond();
        do
        {
            Console.WriteLine("Enter character or type 'exit' for Exit:");
                
            var input = Console.ReadLine();

            if (input == "exit") break;

            var character = string.IsNullOrEmpty(input) ? '0' : input[0];

            Console.WriteLine(diamond.Generate(character));

        } while (true);
    }
}