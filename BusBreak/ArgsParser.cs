
namespace BusBreak
{
    internal class ArgsParser
    {
        /* Parses passed command line arguments
         * Arguments passed correctly: returns file path containing break times
         * Arguments passed incorrectly: notifies the user and returns null
         */
        public static string? ParseArgs(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    return "no_path";

                case 1:
                    if (args[0].ToLower() == "filename")
                    {
                        Console.WriteLine("No file path specified!");
                    }
                    else Console.WriteLine($"Unknown argument {args[0]}"); ;
                    break;

                case 2:
                    if (args[0].ToLower() == "filename")
                    {
                        if (args[1].EndsWith(".txt")) return args[1];
                        else Console.WriteLine("File is not a .txt file!"); ;
                    }
                    else Console.WriteLine($"Unknown argument {args[0]}");
                    break;

                case > 2:
                    Console.WriteLine("Too many arguments!");
                    break;
            }

            Console.WriteLine("Use arguments: filename <file path>");
            return null;
        }
    }
}
