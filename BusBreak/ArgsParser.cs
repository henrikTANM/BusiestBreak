using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBreak
{
    internal class ArgsParser
    {
        public static string? Parse(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Console.WriteLine("No arguments given!");
                    return null;

                case 1:
                    Console.WriteLine(
                        args[0].ToLower() == "filename" ?
                        "No file path specified!" :
                        $"Unknown argument {args[0]}"
                        );
                    return null;

                case 2:
                    return args[0].ToLower() == "filename" ? args[1] : null;

                default:
                    Console.WriteLine("Too many arguments!");
                    return null;
            }
        }
    }
}
