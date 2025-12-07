using Day03;

List<BatteryBank> input = ReadInput("data01.txt");
Console.WriteLine($"Read {input.Count} battery banks from input file.");

long twoDigits = 0;
long twelveDigits = 0;

foreach (var bank in input)
{
    twoDigits += bank.Joltage();
    twelveDigits += bank.Joltage12();
}

Console.WriteLine($"Total joltage: {twoDigits}");
Console.WriteLine($"Total joltage (12 digits): {twelveDigits}");

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
