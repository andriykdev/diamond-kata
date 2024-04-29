using FluentAssertions;

namespace TheDiamondKata.Tests;

public class DiamondTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Diamond_should_generate_correct_output(char input, string expected)
    {
        var diamond = new Diamond('_');

        var result = diamond.Generate(input);

        result.Should().Be(expected);
    }


    [Theory]
    [InlineData('5')]
    [InlineData('a')]
    [InlineData('x')]
    [InlineData('%')]
    public void Diamond_should_return_error_message_when_character_is_not_supported(char input)
    {
        var diamond = new Diamond();

        var result = diamond.Generate(input);

        result.Should().Contain("character is not supported");
    }



    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { 'A', "A" },
            new object[] { 'B', 
@"_A_
B_B
_A_" },
            new object[] { 'G', 
@"______A______
_____B_B_____
____C___C____
___D_____D___
__E_______E__
_F_________F_
G___________G
_F_________F_
__E_______E__
___D_____D___
____C___C____
_____B_B_____
______A______" },
           new object[] { 'D', 
@"___A___
__B_B__
_C___C_
D_____D
_C___C_
__B_B__
___A___" },
        };
}