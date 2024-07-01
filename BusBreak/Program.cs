using BusBreak;
using System.Text.RegularExpressions;

BreakManager breakManager = new BreakManager();
string? filePath = ArgsParser.Parse(args);

if (filePath != null)
{
    breakManager.GetBreaksFromFile(filePath);
    Console.WriteLine(breakManager.GetBusiestBreakTime());
}
else
{
    Console.WriteLine("Use arguments: filename <file path>");
    Environment.Exit(0);
}

string correctBreakFormat = @"^([0-2][0-9]:[0-5][0-9]){2}$";

while (true)
{
    Console.Write(": ");
    string? input = Console.ReadLine();

    if (input != null)
    {
        if (input == "exit") { Environment.Exit(0); }

        Match match = Regex.Match(input, correctBreakFormat);

        if (match.Success)
        {
            TimeObject start = new(input[..5], true);
            TimeObject end = new(input[5..], false);
            
            if (start.IsBefore(end))
            {
                Console.WriteLine("Break added");

                breakManager.AddTime(start);
                breakManager.AddTime(end);
                Console.WriteLine(breakManager.GetBusiestBreakTime());
            }
            else
            {
                Console.WriteLine("Incorrect time values, start time must be before end time!");
            }
        } 
        else
        {
            Console.WriteLine("Incorrect format!");
            Console.WriteLine("Example break time entry: 12:0012:30");
        }
    }
}
