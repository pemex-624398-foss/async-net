namespace AsyncConsole;

public static class DataSet
{
    public static IDictionary<string, IList<int>> NumberDictionary { get; set; }

    static DataSet()
    {
        NumberDictionary = new Dictionary<string, IList<int>>();
        NumberDictionary["A"] = new List<int>(new[] {1, 2, 3, 4, 5});
        NumberDictionary["B"] = new List<int>(new[] {10, 20, 30, 40, 50});
        NumberDictionary["C"] = new List<int>(new[] {100, 200, 300, 400, 500});
        NumberDictionary["D"] = new List<int>(new[] {1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000});
    }
}