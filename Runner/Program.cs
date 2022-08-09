
using FizBuz;

var fizBuzGenerator = new FizBuzGenerator(output =>
Console.WriteLine(output),
new Dictionary<int, string>
{
    {3, "fiz" },
    {5, "buz" }
});

fizBuzGenerator.GenerateFizBuz(int.MaxValue);

Console.ReadKey();