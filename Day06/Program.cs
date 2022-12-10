// See https://aka.ms/new-console-template for more information
//Other Tests
//bvwbjplbgvbhsrlpgdmjqwftvncz
//nppdvjthqldpwncqszvftbrmjlhg
//nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg
//zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw

using System.Collections.Generic;

var signal = File.ReadAllText("input.txt").ToCharArray();

firstHalf(signal);
secondHalf(signal);

//Methods
void secondHalf(char[] signal)
{
    List<char> lastChars = new List<char>();
    for (int i = 0; i < signal.Length; i++)
    {
        if (i < 13)
        {
            lastChars.Add(signal[i]);
        }
        else
        {
            lastChars.Add(signal[i]);
            if (lastChars.Distinct().Count() == 14)
            {
                lastChars.ForEach(x => Console.Write(x + " "));
                Console.WriteLine(" | at letter " + (i + 1));
                return;
            }
            //Console.WriteLine();
            lastChars.Remove(lastChars.First());
        }
    }
}

void firstHalf(char[] signal)
{
    List<char> lastChars = new List<char>();
    for (int i = 0; i < signal.Length; i++)
    {
        if (i < 3)
        {
            lastChars.Add(signal[i]);
        }
        else
        {
            lastChars.Add(signal[i]);
            if (lastChars.Distinct().Count() == 4)
            {
                lastChars.ForEach(x => Console.Write(x + " "));
                Console.WriteLine(" | at letter " + (i + 1));
                return;
            }
            //Console.WriteLine();
            lastChars.Remove(lastChars.First());
        }
    }
}
