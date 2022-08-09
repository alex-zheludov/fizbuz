using Moq;

namespace FizBuz.Tests;

public class FizBuzGeneratorTests
{
    [Fact]
    public void Verify_NumberThatMeetsBothConditionsPrinterOutBothTimes()
    {
        var printer = new Mock<Action<string>>();

        var fizBuzGenerator = new FizBuzGenerator(printer.Object, new Dictionary<int, string>
        {
            {3, "fiz" },
            {5, "buz" }
        });

        fizBuzGenerator.PrintOut(15);

        printer.Verify(p => p.Invoke("fiz"), Times.Once);
        printer.Verify(p => p.Invoke("buz"), Times.Once);
    }


    [MemberData(nameof(Verify_ConditionsAreMet_TestData))]
    [Theory]
    public void Verify_ConditionsAreMet(int number, Dictionary<int, string> conditions, List<string> expectedOutputs)
    {
        var printer = new Mock<Action<string>>();

        var fizBuzGenerator = new FizBuzGenerator(printer.Object, conditions);

        fizBuzGenerator.PrintOut(number);

        foreach (var output in expectedOutputs)
        {
            printer.Verify(p => p.Invoke(output), Times.Once);
        }
    }

    public static IEnumerable<Object[]> Verify_ConditionsAreMet_TestData()
    {
        yield return new object[]
        {
            15,
            new Dictionary<int, string>{
                {3, "fiz" },
                {5, "buz" }
            },
            new List<string>
            {
                "fiz",
                "buz"
            }
        };

        yield return new object[]
        {
            18,
            new Dictionary<int, string>{
                {9, "hello" },              
            },
            new List<string>
            {
                "hello"
            }
        };
    }
}

// Update this code to allow developers to pass their own numbers and word pairs