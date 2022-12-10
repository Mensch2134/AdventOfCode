// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

var lines = File.ReadLines("input.txt");

//Console.WriteLine(firstHalf(lines));
Console.WriteLine(secondHalf(lines));

int secondHalf(IEnumerable<string> input)
{
    var comps = input
        .ToList()
        .Select((x, i) => new { Index = i, Value = x })
        .GroupBy(x => x.Index / 3)
        .Select(x=>x.Select(v=>v.Value)
        .ToList())
        .ToList();

    int itemPriority = 0;

    foreach(var trio in comps)
    {
        var c = trio[0].ToCharArray().Intersect(trio[1].ToCharArray().Intersect(trio[2].ToCharArray())).ToList().First();
        var item = Char.IsLower(c) ? (int)c - 96 : (int)c - 38;
        itemPriority += item;
    }
    
    return itemPriority;
}

int firstHalf(IEnumerable<string> input)
{
    int itemPriorities = 0;

    foreach (var line in input)
    {
        var left = line.Substring(0, line.Length / 2).ToCharArray();
        var right = line.Substring(line.Length / 2, line.Length / 2).ToCharArray();

        foreach (var c1 in left)
        {
            bool done = false;
            foreach (var c2 in right)
            {
                if (c1 == c2)
                {
                    var item = Char.IsLower(c1) ? (int)c1 - 96 : (int)c1 - 38;
                    itemPriorities += item;
                    //Console.WriteLine("Similar Letter Found: " + c1 + " with Ascii value of" + item);
                    done = true;
                    break;
                }
            }
            if (done)
                break;
        }
    }

    return itemPriorities;
}
