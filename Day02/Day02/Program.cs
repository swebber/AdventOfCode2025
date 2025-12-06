using System.Diagnostics;
using Day02;

long totalCount = 0;
long totalMultiCount = 0;

List<(long start, long end)> pairs = PopulateData("data01.txt");

foreach (var pair in pairs)
{
    Console.WriteLine($"Start: {pair.start}, End: {pair.end}");

    Stopwatch sw = Stopwatch.StartNew();
    (long count, long multiCount) = ProcessPair(pair);

    totalCount += count;
    totalMultiCount += multiCount;

    sw.Stop();
}

Console.WriteLine($"Total Sum of matching patterns: {totalCount}");
Console.WriteLine($"Total Sum of multi patterns: {totalMultiCount}");

static (long count, long multiCount) ProcessPair((long start, long end) pair)
{
    long count = 0;
    long multiCount = 0;

    for (long i = pair.start; i <= pair.end; i++)
    {
        if (i.IsPattern())
        {
            count += i;
        }

        if (i.IsMultiPattern())
        {
            multiCount += i;
        }
    }
    return (count, multiCount);
}

static List<(long start, long end)> PopulateData(string fn)
{
    var result = new List<(long start, long end)>();

    var appDir = AppDomain.CurrentDomain.BaseDirectory;
    var filePath = Path.Combine(appDir, "Data", fn);
    var lines = File.ReadAllLines(filePath);
    var line = lines[0];

    var pairs = line.Split(',');
    foreach (var pair in pairs)
    {
        var parts = pair.Split('-');

        result.Add((long.Parse(parts[0]), long.Parse(parts[1])));
    }

    return result;
}
