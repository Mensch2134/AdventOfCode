// See https://aka.ms/new-console-template for more information
var input = File.ReadLines("test.txt");

List<int> xs = new List<int>();
List<int> ys = new List<int>();

foreach (var line in input)
{
    var splits = line.Split(" -> ");
    foreach (var split in splits)
    {
        var t = split.Split(',');
        xs.Add(int.Parse(t[0]));
        ys.Add(int.Parse(t[1]));
    }
}

xs.Sort();
ys.Sort();
int w = xs.Last() - xs.First() + 3, h = ys.Last() + 3;
int xSand = w - (xs.Last() - 500) - 1;

char[,] cave = new char[h, w];

for (int i = 0; i < cave.GetLength(0); i++)
{
    char c = '.';
    if (i == cave.GetLength(0) - 1)
        c = '#';
    for (int j = 0; j < cave.GetLength(1); j++)
    {
        cave[i, j] = c;
    }
}
cave[0, xSand] = '+';

foreach (var line in input)
{
    var splits = line.Split(" -> ");
    int lastX = -1, lastY = -1;
    foreach (var split in splits)
    {
        var t = split.Split(',');
        int x, y;
        x = int.Parse(t[0]);
        y = int.Parse(t[1]);
        if (lastX >= 0)
        {
            fillArray(lastX, lastY, x, y);
        }
        lastX = x; lastY = y;
    }
}

for (int i = 0; i < 20; i++)
{
    sendSand(1);
    printCave();
}

//Methods
void sendSand(int amount)
{
    for (int i = 0; i < amount; i++)
    {
        int x = xSand, y = 0;
        var falling = true;
        while (falling)
        {
            if (y + 1 < h && cave[y + 1, x] == '.')
            {
                y += 1;
            }
            else if (x - 1 >= 0 && y + 1 < h && cave[y + 1, x - 1] == '.')
            {
                y += 1; x -= 1;
            }
            else if (x + 1 < w && y + 1 < h && cave[y + 1, x + 1] == '.')
            {
                y += 1; x += 1;
            }
            else
            {
                falling = false;
            }
        }
        if (x == xSand && y == 0)
        {
            Console.WriteLine("FUUUUUUUUUUUUUUUUUUUUU");
            cave[y, x] = 'o';
            break;
        }
        cave[y, x] = 'o';
    }
}

void fillArray(int x1, int y1, int x2, int y2)
{
    int aX1 = x1, aX2 = x2, aY1 = y1, aY2 = y2;
    if (x1 > x2)
    {
        aX1 = x2;
        aX2 = x1;
    }
    if (y1 > y2)
    {
        aY1 = y2;
        aY2 = y1;
    }
    for (int i = aX1; i <= aX2; i++)
    {
        var x = w - (xs.Last() - i) - 2;
        for (int j = aY1; j <= aY2; j++)
        {
            var y = h - (ys.Last() - j) - 3;
            cave[y, x] = '#';
        }
    }
}

void printCave()
{
    for (int i = 0; i < cave.GetLength(0); i++)
    {
        for (int j = 0; j < cave.GetLength(1); j++)
        {
            Console.Write(cave[i, j]);
        }
        Console.WriteLine();
    }
}
