// See https://aka.ms/new-console-template for more information
using Day07;

var lines = File.ReadLines("input.txt").ToList().Skip(1);

Tree fileTree = new Tree();

foreach(var line in lines)
{
    var cmdParts = line.Split(' ');
    if (cmdParts[0].Equals("$"))
    {
        if (cmdParts[1].Equals("cd"))
        {
            if (cmdParts[2].Equals(".."))
            {
                fileTree.moveUp();
                continue;
            } else
            {
                fileTree.moveDown(cmdParts[2]);
                continue;
            }
        } else
        {
            //Console.WriteLine("Skipped cmd because we dont need to handle it at: " + line);
        }
    } else
    {
        int fileSize = 0;
        if (int.TryParse(cmdParts[0], out fileSize))
        {
            fileTree.addNode(cmdParts[1], fileSize);
            continue;
        } 
        else if (cmdParts[0].Equals("dir"))
        {
            fileTree.addNode(cmdParts[1], -1);
            continue;
        }
        //Console.WriteLine("Something went wrong with the line: " + line);
    }
}

var r = fileTree.getDirs();
var spaceToFree = 30000000 - (70000000 - fileTree.getRootSize());
int combSize = 0;
SortedList<int, string> deletionCandidates = new SortedList<int, string>();

foreach (var dir in r)
{
    if (dir is DirectoryNode)
    {
        DirectoryNode d = dir as DirectoryNode;
        var s = d.getDirSize();
        if (s <= 100000)
        {
            combSize += s;
        }
        if (s >= spaceToFree)
        {
            deletionCandidates.Add(s, d.name);
        }
        //Console.WriteLine("Directory " + dir.name + " with combined size of " + s);
    }
}

Console.WriteLine("The combined size of all directories smaller than 100.000 is: " + combSize);

Console.WriteLine("The smallest directory where its deletion frees up enough space to update: " + deletionCandidates.First().Key);

