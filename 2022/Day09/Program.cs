// See https://aka.ms/new-console-template for more information
using System.Globalization;

var lines = File.ReadLines("input.txt");

//Preprocessing
var x = 1;
var y = 1;

var width = 1;
var height = 1;

foreach (var line in lines)
{
    var lineSplit = line.Split(' ');
    var dir = lineSplit[0];
    var num = int.Parse(lineSplit[1]);

    if (dir.Equals("U"))
    {
        y += num;
        height = y > height ? y : height;
    }
    else if (dir.Equals("D"))
    {
        y -= num;
    }
    else if (dir.Equals("R"))
    {
        x += num;
        width = x > width ? x : width;
    }
    else if (dir.Equals("L"))
    {
        x -= num;
    }
    else
    {
        Console.WriteLine("Bruder ne, kann ich nicht einlesen");
    }
}

//Actual Task Second
Vector headPos = new Vector(0, 0);
Vector[] tailPositions = new Vector[9];
List<Vector> visitedPositions = new List<Vector> { headPos };

foreach (var line in lines)
{
    var lineSplit = line.Split(' ');
    var dir = lineSplit[0];
    var num = int.Parse(lineSplit[1]);

    if (dir.Equals("U"))
    {
        for (int i = 0; i < num; i++)
        {
            headPos.y++;
            tailPositions[0] = moveTail(headPos, tailPositions[0]);
            for (int j = 1; j < tailPositions.Length; j++)
            {
                tailPositions[j] = moveTail(tailPositions[j - 1], tailPositions[j]);
            }
            visitedPositions.Add(tailPositions[8]);
        }
    }
    else if (dir.Equals("D"))
    {
        for (int i = 0; i < num; i++)
        {
            headPos.y--;
            tailPositions[0] = moveTail(headPos, tailPositions[0]);
            for (int j = 1; j < tailPositions.Length; j++)
            {
                tailPositions[j] = moveTail(tailPositions[j - 1], tailPositions[j]);
            }
            visitedPositions.Add(tailPositions[8]);
        }
    }
    else if (dir.Equals("R"))
    {
        for (int i = 0; i < num; i++)
        {
            headPos.x++;
            tailPositions[0] = moveTail(headPos, tailPositions[0]);
            for (int j = 1; j < tailPositions.Length; j++)
            {
                tailPositions[j] = moveTail(tailPositions[j - 1], tailPositions[j]);
            }
            visitedPositions.Add(tailPositions[8]);
        }
    }
    else if (dir.Equals("L"))
    {
        for (int i = 0; i < num; i++)
        {
            headPos.x--;
            tailPositions[0] = moveTail(headPos, tailPositions[0]);
            for (int j = 1; j < tailPositions.Length; j++)
            {
                tailPositions[j] = moveTail(tailPositions[j - 1], tailPositions[j]);
            }
            visitedPositions.Add(tailPositions[8]);
        }
    }
}

foreach (var pos in visitedPositions.Distinct())
{
    Console.WriteLine("(" + pos.x + " " + pos.y + ")");
    //grid[pos.x, pos.y] = '#';
}

Console.WriteLine(visitedPositions.Distinct().Count());

//Actual Task First
char[,] grid = new char[width, height];
for (int i = 0; i < grid.GetLength(0); i++)
{
    for (int j = 0; j < grid.GetLength(1); j++)
    {
        grid[i, j] = '.';
        //Console.Write(grid[i, j]);
    }
    //Console.WriteLine();
}

headPos = new Vector(0, 0);
Vector tailPos = new Vector(0, 0);
visitedPositions = new List<Vector> { tailPos };

foreach (var line in lines)
{
    var lineSplit = line.Split(' ');
    var dir = lineSplit[0];
    var num = int.Parse(lineSplit[1]);

    if (dir.Equals("U"))
    {
        for (int i = 0; i < num; i++)
        {
            headPos.y++;
            tailPos = moveTail(headPos, tailPos);
            visitedPositions.Add(tailPos);
        }
    }
    else if (dir.Equals("D"))
    {
        for (int i = 0; i < num; i++)
        {
            headPos.y--;
            tailPos = moveTail(headPos, tailPos);
            visitedPositions.Add(tailPos);
        }
    }
    else if (dir.Equals("R"))
    {
        for(int i = 0; i < num; i++)
        {
            headPos.x++;
            tailPos = moveTail(headPos, tailPos);
            visitedPositions.Add(tailPos);
        }
    }
    else if (dir.Equals("L"))
    {
        for (int i = 0; i < num; i++)
        {
            headPos.x--;
            tailPos = moveTail(headPos, tailPos);
            visitedPositions.Add(tailPos);
        }
    }
}

//foreach(var pos in visitedPositions.Distinct())
//{
//    Console.WriteLine("(" + pos.x + " " + pos.y + ")");
//    //grid[pos.x, pos.y] = '#';
//}

//for (int i = 0; i < grid.GetLength(0); i++)
//{
//    for (int j = 0; j < grid.GetLength(1); j++)
//    {
//        Console.Write(grid[i, j]);
//    }
//    Console.WriteLine();
//}

Console.WriteLine(visitedPositions.Distinct().Count());

//methods
Vector moveTail(Vector head, Vector tail)
{
    Vector diff = new Vector(head.x - tail.x, head.y - tail.y);
    Vector newPos = new Vector(tail.x, tail.y);
    if (Math.Abs(diff.x) <= 1 && Math.Abs(diff.y) <= 1)
    {
        return tail;
    } else if (Math.Abs(diff.x) == 2 && Math.Abs(diff.y) == 1) {
        newPos.x = tail.x + (diff.x / 2);
        newPos.y = tail.y + diff.y;
    } else if (Math.Abs(diff.y) == 2 && Math.Abs(diff.x) == 1)
    {
        newPos.x = tail.x + diff.x;
        newPos.y = tail.y + (diff.y / 2);
    } else if (Math.Abs(diff.x) == 2 && Math.Abs(diff.y) == 0)
    {
        newPos.x = tail.x + (diff.x / 2);
    } else if (Math.Abs(diff.y) == 2 && Math.Abs(diff.x) == 0)
    {
        newPos.y = tail.y + (diff.y / 2);
    }
    return newPos;
}

public struct Vector
{
    public int x;
    public int y;

    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector()
    {
        this.x = 0;
        this.y = 0;
    }
}
