// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

var input = File.ReadLines("input.txt");

int[] maxCalories = new int[3];
var currentCalories = 0;

foreach (var l in input)
{
    if(l != "")
    {
        currentCalories += int.Parse(l);
    } else
    {
        for(int i = 0; i < maxCalories.Length; i++) 
        {
            if (currentCalories > maxCalories[i])
            {
                var temp = maxCalories[i];
                maxCalories[i] = currentCalories;
                currentCalories = temp;
            }
        }
        currentCalories = 0;
    }
}

Console.WriteLine(maxCalories.Sum());
