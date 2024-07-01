
namespace BusBreak
{
    internal class FileReader
    {
        /* Reads break times from given file
         * Returns start and end times of correct break time entries 
         * as a list of Time objects
         */
        public static List<Time> GetBreakTimesFromFile(string filePath)
        {
            List<Time> times = new List<Time>();
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                string? line = streamReader.ReadLine();
                int lineCounter = 0;
                int successfulLines = 0;

                while (line != null)
                {
                    lineCounter++;

                    if (!BreakChecker.CheckRegex(line))
                    {
                        Console.WriteLine(
                            "Break on line " +
                            lineCounter +
                            " not added: Incorrect format!");
                        line = streamReader.ReadLine();
                        continue;
                    }

                    Time start = new(line[..5], true);
                    Time end = new(line[5..], false);

                    if (!start.IsBefore(end))
                    {
                        Console.WriteLine(
                            "Break on line " +
                            lineCounter +
                            " not added: First time must be before second!");
                        line = streamReader.ReadLine();
                        continue;
                    }

                    times.Add(start);
                    times.Add(end);

                    successfulLines++;
                    line = streamReader.ReadLine();
                }

                streamReader.Close();
                Console.WriteLine(
                    "Loaded " +
                    successfulLines +
                    " break times from file.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            return times;
        }
    }
}
