
using System.Diagnostics;
using System.Runtime.CompilerServices;

List<(long start, long end)> pairs = PopulateData("data01.txt");

foreach (var pair in pairs)
{
    Console.Write($"Start: {pair.start}, End: {pair.end}");

    Stopwatch sw = Stopwatch.StartNew();
    ProcessPair(pair);
    sw.Stop();

    Console.WriteLine($" - Elapsed: {sw.ElapsedMilliseconds} ms");
}

static void ProcessPair((long start, long end) pair)
{
    for (long i = pair.start; i <= pair.end; i++)
    {
        // Processing logic here
    }
}

static List<(long start, long end)> PopulateData(string fn)
{
    var result = new List<(long start, long end)>();

    var appDir = AppDomain.CurrentDomain.BaseDirectory;
    var filePath = Path.Combine(appDir, "Data", fn);
    var lines = File.ReadAllLines(filePath);
    var line = lines[0];

    var pairs = line.Split(',');
    foreach (var pair in pairs )
    {
        var parts = pair.Split('-');

        result.Add( (long.Parse(parts[0]), long.Parse(parts[1])));
    }

    return result;
}
