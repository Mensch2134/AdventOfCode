// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input.txt").ToList();

var stackList = lines.Take(lines.FindIndex(s => s.Equals(""))).ToList();
var stacks1 = getStackArrangement(stackList);
var stacks2 = getStackArrangement(stackList);

var stepList = lines.Skip(lines.FindIndex(s => s.Equals("")) + 1).ToList();
var steps = getRearrangementSteps(stepList);

firstHalf(stacks1, steps);
secondHalf(stacks2, steps);

//result Methods
void secondHalf(List<Stack<char>> stacks, List<RearrangementStep> steps)
{
    foreach (var step in steps)
    {
        Stack<char> tempStack = new Stack<char>();

        for (int i = 0; i < step.numOfBoxes; i++)
            tempStack.Push(stacks[step.originIndex].Pop());

        for(int i = 0; i < step.numOfBoxes; i++)
            stacks[step.destinationIndex].Push(tempStack.Pop());
    }

    string result = "";
    foreach (var stack in stacks)
    {
        result += stack.Pop();
    }
    Console.WriteLine(result);
}

void firstHalf(List<Stack<char>> stacks, List<RearrangementStep> steps)
{
    foreach (var step in steps)
    {
        for(int i = 0; i < step.numOfBoxes; i++)
        {
            stacks[step.destinationIndex].Push(stacks[step.originIndex].Pop());
        }
    }

    string result = "";
    foreach (var stack in stacks)
    {
        result += stack.Pop();
    }
    Console.WriteLine(result);
}

//Methods
List<RearrangementStep> getRearrangementSteps(List<string> stepList)
{
    List<RearrangementStep> steps = new List<RearrangementStep>();
    foreach (var step in stepList)
    {
        List<int> values = new List<int>();
        foreach (Match match in Regex.Matches(step, @"\d+"))
            values.Add(int.Parse(match.Value));

        steps.Add(new RearrangementStep(values[0], values[1], values[2]));
    }

    return steps;
}

List<Stack<char>> getStackArrangement(List<string> stackList)
{
    List<Stack<char>> stacks = new List<Stack<char>>();

    for (int i = stackList.Count() - 2; i >= 0; i--) //-2 to skip the stack numbers row
    {
        var stack = stackList[i].ToCharArray();

        for (int j = 1; j < stack.Length; j += 4)
        {
            var c = stack[j];
            var stackIndex = (j - 1) / 4;
            if (char.IsLetter(c))
            {
                //Console.WriteLine("Pushed " + c + " to stack with index " + stackIndex);
                if (stackIndex + 1 > stacks.Count)
                {
                    stacks.Add(new Stack<char>());
                }
                stacks[stackIndex].Push(c);
            }
        }
    }

    return stacks;
}

//Structs
public struct RearrangementStep
{
    public int originIndex;
    public int numOfBoxes;
    public int destinationIndex;

    public RearrangementStep()
    {
        originIndex = 0;
        numOfBoxes = 0;
        destinationIndex = 0;
    }

    public RearrangementStep(int sN, int sI, int dI)
    {
        numOfBoxes = sN;
        originIndex = sI - 1;
        destinationIndex = dI - 1;
    }

    public void print()
    {
        Console.WriteLine(originIndex + " | " + numOfBoxes + " | " + destinationIndex);
    }
};