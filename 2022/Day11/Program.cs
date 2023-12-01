// See https://aka.ms/new-console-template for more information
using Day11;

var monkeys = File.ReadLines("input.txt").Chunk(7).ToList();

List<Monkey> monkeyList = new List<Monkey>();
int modulator = 1;

foreach(var monkey in monkeys)
{
    string items = "";
    int worryModifier = -1;
    OperationType modifyType = OperationType.ADD;
    int throwDivisor = 1;
    int trueMonkeyIndex = 0;
    int falseMonkeyIndex = 0;  
    foreach (var line in monkey)
    {
        if (line.Equals("") || line.StartsWith("Monkey"))
            continue;

        var l = line.Split(':');
        var indicator = l[0].Trim();
        var inf = l[1].Split(' ');
        if (indicator.Equals("Starting items"))
        {
            items = l[1].Trim();
            continue;
        }
        if (indicator.Equals("Operation"))
        {
            var success = int.TryParse(inf[inf.Length - 1], out worryModifier);
            if (!success)
                worryModifier = -1;
            var op = inf[inf.Length - 2];
            modifyType = op.Equals("*") ? OperationType.MULTIPLY : OperationType.ADD;

        }
        if (indicator.Equals("Test"))
        {
            throwDivisor = int.Parse(inf[inf.Length - 1]);
        }
        if (indicator.Equals("If true"))
        {
            trueMonkeyIndex = int.Parse(inf[inf.Length - 1]);
        }
        if (indicator.Equals("If false"))
        {
            falseMonkeyIndex = int.Parse(inf[inf.Length - 1]);
        }
    }
    modulator *= throwDivisor;
    monkeyList.Add(new Monkey(items, worryModifier, modifyType, throwDivisor, trueMonkeyIndex, falseMonkeyIndex));
}

for(int i = 0; i < 10000; i++)
{
    foreach(Monkey monkey in monkeyList)
    {
        var items = monkey.getItemCount();
        for (int j = 0; j < items; j++)
        {
            //ThrowResult r = monkey.throwItem();
            ThrowResult r = monkey.throwItemSecond();
            monkeyList[r.recipient].addItem(r.worry % modulator);
        }
    }
    //Console.WriteLine(i);
}

monkeyList = monkeyList.OrderBy(x => x.getInspectedItems()).ToList();

int count = 0;
foreach(Monkey monkey in monkeyList)
{
    Console.Write("Monkey " + count + ": ");
    monkey.print();
    count++;
}

long monkeyBusiness = (long)monkeyList[monkeyList.Count - 1].getInspectedItems() * (long)monkeyList[monkeyList.Count - 2].getInspectedItems();
Console.WriteLine("Zack die Bohne, die Affen sind " + monkeyBusiness + " am business moken.");