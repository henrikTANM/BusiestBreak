using System.Text.RegularExpressions;

namespace BusBreak
{
    internal class BreakChecker
    {
        /* Matches break time entry with a regular expression
         * represesntig the correct specified format of break time 
         */
        public static bool CheckRegex(string input)
        {
            string correctBreakFormat = @"^([0-2][0-9]:[0-5][0-9]){2}$";
            Match match = Regex.Match(input, correctBreakFormat);
            return match.Success;
        }
    }
}
