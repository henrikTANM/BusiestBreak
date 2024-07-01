using BusBreak;

BreakCalculator breakCalculator = new();
string? filePath = ArgsParser.ParseArgs(args); // File path form passed arguments

if (filePath != null)
{
    if (filePath != "no_path")
    {
        List<Time> times = FileReader.GetBreakTimesFromFile(filePath);
        foreach (Time time in times) breakCalculator.AddTime(time);
        Console.WriteLine(breakCalculator.CalculateBusiestBreakTime());
    }
}
else Environment.Exit(0);

Console.WriteLine("Enter a new break time or 'exit' to exit the application.");

while (true)
{
    Console.Write(": ");
    string? input = Console.ReadLine();

    if (input != null)
    {
        if (input == "exit") Environment.Exit(0);

        if (!BreakChecker.CheckRegex(input))
        {
            Console.WriteLine("Incorrect format!");
            Console.WriteLine("Example break time entry: 12:0012:30");
            continue;
        }
        
        Time start = new(input[..5], true);
        Time end = new(input[5..], false);
            
        if (!start.IsBefore(end))
        {
            Console.WriteLine(
                    "Incorrect time values, " +
                    "start time must be before end time!");
            continue;
        }

        breakCalculator.AddTime(start);
        breakCalculator.AddTime(end);
        Console.WriteLine("Break added!");
        Console.WriteLine(breakCalculator.CalculateBusiestBreakTime());
    }
}
