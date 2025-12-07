char[,] _grid;

ReadInput("data01.txt");
ProcessInput();

void ProcessInput()
{
    int accesableTotal = 0;
    int accessablePass = -1;

    int rows = _grid.GetLength(0);
    int cols = _grid.GetLength(1);

    while (accessablePass != 0)
    {
        accessablePass = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int neighbors = NeighborCount(i, j);

                if (neighbors < 4 && _grid[i, j] == '@')
                {
                    _grid[i, j] = 'x';
                    accessablePass++;
                }
            }
        }

        Console.WriteLine($"Accessable this pass: {accessablePass}");
        accesableTotal += accessablePass;

        if (accessablePass != 0)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (_grid[i, j] == 'x')
                    {
                        _grid[i, j] = '.';
                    }
                }
            }
        }
    }

    Console.WriteLine($"Accesable rolls: {accesableTotal}");
}

int NeighborCount(int i, int j) =>
    IsOccupied(i - 1, j - 1) +
    IsOccupied(i - 1, j) +
    IsOccupied(i - 1, j + 1) +
    IsOccupied(i, j - 1) +
    IsOccupied(i, j + 1) +
    IsOccupied(i + 1, j - 1) +
    IsOccupied(i + 1, j) +
    IsOccupied(i + 1, j + 1);

int IsOccupied(int i, int j)
{
    if (i < 0 || j < 0 || i >= _grid.GetLength(0) || j >= _grid.GetLength(1))
    {
        return 0;
    }

    return (_grid[i, j] == '@' || _grid[i, j] == 'x') ? 1 : 0;
}

void ReadInput(string fn)
{
    var appDir = AppContext.BaseDirectory;
    var filePath = Path.Combine(appDir, "Data", fn);
    var lines = File.ReadAllLines(filePath);

    _grid = new char[lines.Length, lines[0].Length];

    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            _grid[i, j] = lines[i][j];
        }
    }
}
