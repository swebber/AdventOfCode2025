using System.Diagnostics;
using Day02;

long count = 0;

List<(long start, long end)> pairs = PopulateData("data01.txt");

foreach (var pair in pairs)
{
    Console.Write($"Start: {pair.start}, End: {pair.end}");

    Stopwatch sw = Stopwatch.StartNew();

    count += ProcessPair(pair);
    sw.Stop();

    Console.WriteLine($" - Elapsed: {sw.ElapsedMilliseconds} ms");
}

Console.WriteLine($"Total Sum of Palindromes: {count}");

static long ProcessPair((long start, long end) pair)
{
    long count = 0;
    for (long i = pair.start; i <= pair.end; i++)
    {
        if (i.IsPattern())
        {
            count += i;
        }
    }
    return count;
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
