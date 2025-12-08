using System.Net.Sockets;

long[,] _ranges;
List<long> _ids = [];

ReadInput("data01.txt");
Console.WriteLine($"Number of Ranges: {_ranges.GetLength(0)}");
Console.WriteLine($"Number of IDs: {_ids.Count}");

int freshCount = FreshCount();
Console.WriteLine($"Number of fresh IDs: {freshCount}");

long freshIds = FreshIdCount();
Console.WriteLine($"Number of unique fresh IDs: {freshIds}");

long FreshIdCount()
{
    // Collect ranges into a list of tuples
    var ranges = new List<(long start, long end)>();
    for (int row = 0; row < _ranges.GetLength(0); row++)
    {
        ranges.Add((_ranges[row, 0], _ranges[row, 1]));
    }

    // Sort ranges by start
    ranges.Sort((a, b) => a.start.CompareTo(b.start));

    // Merge overlapping/adjacent ranges
    var merged = new List<(long start, long end)>();
    foreach (var range in ranges)
    {
        if (merged.Count == 0)
        {
            merged.Add(range);
            continue;
        }

        var last = merged[^1];
        if (range.start <= last.end + 1)
        {
            // Overlap or adjacent, merge
            merged[^1] = (last.start, Math.Max(last.end, range.end));
        }
        else
        {
            merged.Add(range);
        }
    }

    // Sum sizes of merged ranges
    long total = 0;
    foreach (var r in merged)
    {
        total += r.end - r.start + 1;
    }
    return total;
}

int FreshCount()
{
    int freshCount = 0;

    foreach (var id in _ids)
    {
        for (int row = 0; row < _ranges.GetLength(0); row++)
        {
            if (id >= _ranges[row, 0] && id <= _ranges[row, 1])
            {
                freshCount++;
                break;
            }
        }
    }

    return freshCount;
}


void ReadInput(string fn)
{
    var appDir = AppContext.BaseDirectory;
    var filePath = Path.Combine(appDir, "Data", fn);

    bool rangeData = true;
    List<string> lines = [];

    foreach (var line in File.ReadLines(filePath))
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            rangeData = false;
            continue;
        }

        if (rangeData)
        {
            lines.Add(line);
        }
        else
        {
            _ids.Add(long.Parse(line));
        }
    }

    _ranges = new long[lines.Count, 2];
    for (int row = 0; row < lines.Count; row++)
    {
        var parts = lines[row].Split('-');
        _ranges[row, 0] = long.Parse(parts[0]);
        _ranges[row, 1] = long.Parse(parts[1]);
    }
}
