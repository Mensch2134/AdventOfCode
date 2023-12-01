// See https://aka.ms/new-console-template for more information
var lines = File.ReadLines("input.txt");

//firstHalf(lines);
secondHalf(lines);

//Methods
void secondHalf(IEnumerable<string> lines)
{
    int cycles = 0;
    int register = 1;

    List<List<char>> screen = new List<List<char>>();

    foreach (var line in lines)
    {
        var splitLine = line.Split(' ');

        if (splitLine[0].Equals("noop"))
        {
            var row = cycles / 40;
            if (row + 1 > screen.Count)
                screen.Add(new List<char>());
            var lit = !(cycles % 40 < register - 1 || cycles % 40 > register + 1);
            if (lit)
                screen[row].Add('#');
            else
                screen[row].Add('.');
            cycles++;
        }
        else if (splitLine[0].Equals("addx"))
        {
            for (int i = 0; i < 2; i++)
            {
                var row = cycles / 40;
                if (row + 1 > screen.Count)
                    screen.Add(new List<char>());
                var lit = !(cycles % 40 < register - 1 || cycles % 40 > register + 1);
                if (lit)
                    screen[row].Add('#');
                else
                    screen[row].Add('.');
                cycles++;
            }
            register += int.Parse(splitLine[1]);
        }
    }

    foreach(var row in screen)
    {
        foreach(var c in row)
        {
            Console.Write(c);
        }
        Console.WriteLine();
    }
}

void firstHalf(IEnumerable<string> lines)
{
    int cycles = 0;
    int register = 1;

    int signalStrengthSum = 0;

    foreach (var line in lines)
    {
        var splitLine = line.Split(' ');

        if (splitLine[0].Equals("noop"))
        {
            cycles++;
            signalStrengthSum += getSignalStrength(cycles, register);
        }
        else if (splitLine[0].Equals("addx"))
        {
            for (int i = 0; i < 2; i++)
            {
                cycles++;
                signalStrengthSum += getSignalStrength(cycles, register);
            }
            register += int.Parse(splitLine[1]);
        }
    }

    Console.WriteLine(signalStrengthSum + " after " + cycles + " cycles");
}

int getSignalStrength(int cycle, int register)
{
    int ret = 0;
    if (cycle > 0 && (cycle + 20) % 40 == 0)
    {
        ret = cycle * register;
        //Console.WriteLine("We are at cycle " + cycle + " and the registers value is " + register + " so we add " + ret);
    }
    return ret;
}