// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

var lines = File.ReadLines("input.txt");

//var result = firstHalf(lines);
var result = secondHalf(lines);

Console.WriteLine(result);

int secondHalf(IEnumerable<string> lines)
{
    int myScore = 0;

    foreach (var line in lines)
    {
        var round = line.Trim().Remove(1, 1).ToCharArray();

        int enemyHand = (int)round[0] - 65;
        int goal = round[1];

        int myHand = -100000;

        if (goal == 'Y')
        {
            myHand = enemyHand;
        }
        else if (goal == 'X')
        {
            myHand = (enemyHand - 1) < 0 ? 2: enemyHand - 1;
        }
        else if (goal == 'Z')
        {
            myHand = (enemyHand + 1) % 3;
        }

        if ((enemyHand + 1) % 3 == myHand)
        {
            myScore += myHand + 1 + 6;
        }
        else if (enemyHand == myHand)
        {
            myScore += myHand + 1 + 3;
        }
        else
        {
            myScore += myHand + 1;
        }
    }
    return myScore;
}

int firstHalf(IEnumerable<string> lines)
{
    int myScore = 0;

    foreach (var line in lines)
    {
        var round = line.Trim().Remove(1, 1).ToCharArray();

        int enemyHand = (int)round[0] - 65;
        int myHand = (int)round[1] - 88;

        if ((enemyHand + 1) % 3 == myHand)
        {
            myScore += myHand + 1 + 6;
        }
        else if (enemyHand == myHand)
        {
            myScore += myHand + 1 + 3;
        }
        else
        {
            myScore += myHand + 1;
        }
    }
    return myScore;
}

