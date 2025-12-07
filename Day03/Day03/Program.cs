using Day03;

List<BatteryBank> input = ReadInput("data01.txt");
Console.WriteLine($"Read {input.Count} battery banks from input file.");

long total = 0;
foreach (var bank in input)
{
    total += bank.Joltage();
}

Console.WriteLine($"Total joltage: {total}");

static List<BatteryBank> ReadInput(string fn)
{
    var result = new List<BatteryBank>();

    var appDir = AppContext.BaseDirectory;
    var filePath = Path.Combine(appDir, "Data", fn);
    
    foreach (var line in File.ReadLines(filePath))
    {
        result.Add(new BatteryBank(line));
    }

    return result;
}
