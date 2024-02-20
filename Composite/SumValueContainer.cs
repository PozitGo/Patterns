public interface IValueContainer
{
    IEnumerable<int> GetValues();
}

public class SingleValue : IValueContainer
{
    public int Value;

    public IEnumerable<int> GetValues()
    {
        yield return Value;
    }
}

public class ManyValues : List<int>, IValueContainer
{
    public IEnumerable<int> GetValues()
    {
        return this;
    }
}

public static class ExtensionMethods
{
    public static int Sum(this List<IValueContainer> containers)
    {
        int result = 0;
        foreach (var container in containers)
        {
            foreach (var value in container.GetValues())
            {
                result += value;
            }
        }
        return result;
    }
}
