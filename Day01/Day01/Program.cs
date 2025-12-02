using Day01;

var dial = new DoublyLinkedList<int>();
var current = PopuldateDial(dial);

int zeroCount = 0;
int zeroTotal = 0;

Console.WriteLine($"Current value: {current.Value}");

var moves = LoadInput("data01.txt");
foreach (var move in moves)
{
    var direction = move[0];
    var steps = int.Parse(move[1..]);

    for (int i = 0; i < steps; i++)
    {
        current = direction == 'L' ? current.Prev : current.Next;
        if (current.Value == 0)
            zeroTotal++;
    }

    if (current.Value == 0)
        zeroCount++;
}

Console.WriteLine($"Zero encountered {zeroCount} times at end of move.");
Console.WriteLine($"Zero encountered a total of {zeroTotal} times.");

static List<string> LoadInput(string fn)
{
    var appDir = AppDomain.CurrentDomain.BaseDirectory;
    var filePath = Path.Combine(appDir, "Data", fn);

    return File.ReadAllLines(filePath).ToList();
}

static DoublyLinkedListNode<int> PopuldateDial(DoublyLinkedList<int> dial)
{
    for (int i = 0; i <= 99; i++)
    {
        dial.AddLast(i);
    }

    dial.Head.Prev = dial.Tail;
    dial.Tail.Next = dial.Head;

    var current = dial.Head;
    while (current.Value != 50)
    {
        current = current.Next;
    }

    return current;
}
