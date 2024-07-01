
namespace BusBreak
{
    /* BreakManager
     * Holds break start and end times as Time objects
     * and uses them to calculate the busiest break time. 
     */
    internal class BreakManager
    {
        private readonly List<Time> times;

        public BreakManager() { times = new List<Time>(); }

        // Insert Time objects into times list in ascending order
        public void AddTime(Time newTime) 
        {
            foreach (Time time in times)
            {
                if (newTime.IsSameTime(time) & !newTime.isStartTime) continue;
                if (newTime.IsSameTime(time) | newTime.IsBefore(time))
                {
                    times.Insert(times.IndexOf(time), newTime);
                    return;
                }
            }
            times.Add(newTime);
        }

        // Get break times from given file
        public void GetBreaksFromFile(string filePath)
        {
            List<Time> newTimes = FileReader.GetBreakTimesFromFile(filePath);
            foreach (Time time in newTimes) AddTime(time);
        }

        // Calculate busiest break time
        public string GetBusiestBreakTime()
        {
            int max = 0; // maximum number of concurrent break takers found
            int current = 0; // current number of break takers
            string maxStart = ""; // start time of busiest break time
            string maxEnd = ""; // end time of busiest break time
            bool newMax = false;

            // loops through sorted list of break start and end times
            foreach (Time time in times)
            {
                // adds or subtracts based on start or end time 
                current += time.isStartTime ? 1 : -1;

                if (current > max)
                { 
                    max = current; 
                    newMax = true;
                    maxStart = time.ToString();
                }
                if (current + 1 == max & newMax)
                {
                    newMax = false;
                    maxEnd = time.ToString();
                }
            }

            return 
                "The busiest time is " + maxStart + "-" + maxEnd + 
                " with total of " + max.ToString() + " drivers taking a break.\n";
        }
    }
}
