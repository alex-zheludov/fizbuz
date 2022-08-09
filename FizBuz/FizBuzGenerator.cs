namespace FizBuz;
public class FizBuzGenerator
{
    private readonly Action<string> _printer;
    private readonly Dictionary<int, string> _conditions;

    public FizBuzGenerator(Action<string> print, Dictionary<int, string> conditions)
    {
        _printer = print;
        _conditions = conditions;
    }

    public void GenerateFizBuz(int maxNumber)
    {
        for (int i = 1; i <= maxNumber; i++)
        {
            PrintOut(i);
        }
    }

    public void PrintOut(int number)
    {
        var conditionIsMet = false;

        foreach (var kv in _conditions)
        {
            if(number % kv.Key == 0)
            {
                conditionIsMet = true;
                _printer(kv.Value);
            }
        
        }

        if (!conditionIsMet)
        {
            _printer(number.ToString());
        }
    }
}
