// See https://aka.ms/new-console-template for more information
var lines = File.ReadLines("input.txt");

//firstHalf(lines);
secondHalf(lines);

//Methods
void secondHalf(IEnumerable<string> lines)
{
    int count = 0;

    foreach (var l in lines)
    {
        count = isCover(l.Split(',')[0], l.Split(',')[1]) ? count + 1 : count;
    }

    Console.WriteLine(count);
}

bool isCover(string l, string r)
{
    var bordersL = l.Split('-');
    var bordersR = r.Split('-');

    if (int.Parse(bordersL[1]) < int.Parse(bordersR[0]))
    {
        return false;
    }
    else if (int.Parse(bordersR[1]) < int.Parse(bordersL[0]))
    {
        return false;
    }

    return true;
}

void firstHalf(IEnumerable<string> lines)
{
    int count = 0;

    foreach (var l in lines)
    {
        count = isFullCover(l.Split(',')[0], l.Split(',')[1]) ? count + 1 : count;
    }

    Console.WriteLine(count);
}

bool isFullCover(string l, string r)
{
    var bordersL = l.Split('-');
    var bordersR = r.Split('-');

    if (int.Parse(bordersL[0]) <= int.Parse(bordersR[0]) &&
        int.Parse(bordersL[1]) >= int.Parse(bordersR[1]))
    {
        return true;
    } else if (int.Parse(bordersR[0]) <= int.Parse(bordersL[0]) &&
        int.Parse(bordersR[1]) >= int.Parse(bordersL[1]))
    {
        return true;
    }

    return false;
}
