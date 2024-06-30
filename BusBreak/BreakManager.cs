using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusBreak
{
    internal class BreakManager
    {
        private List<TimeObject> times;

        public BreakManager() { times = new List<TimeObject>(); }

        public void AddTime(TimeObject timeObject) 
        {
            foreach (TimeObject time in times)
            {
                if (timeObject.IsSameTime(time) & !timeObject.isStartTime) continue;
                if (timeObject.IsSameTime(time) | timeObject.IsBefore(time))
                {
                    times.Insert(times.IndexOf(time), timeObject);
                    return;
                }
            }
            times.Add(timeObject);
        }

        public void GetBreaksFromFile(string filePath)
        {
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                string? line = streamReader.ReadLine();

                while (line != null)
                {
                    AddTime(new TimeObject(line[..5], true));
                    AddTime(new TimeObject(line[5..], false));
                    line = streamReader.ReadLine();
                }

                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        public string GetBusiestBreakTime()
        {
            int max = 0;
            int current = 0;
            string maxStart = "";
            string maxEnd = "";
            bool newMax = false;

            foreach (TimeObject timeObject in times)
            {
                Console.WriteLine(timeObject + " " + timeObject.isStartTime);

                current += timeObject.isStartTime ? 1 : -1;
                if (current > max) 
                { 
                    max = current; 
                    newMax = true;
                    maxStart = timeObject.ToString();
                }
                if (current + 1 == max & newMax)
                {
                    newMax = false;
                    maxEnd = timeObject.ToString();
                }
            }
            return 
                "The busiest time is " + maxStart + "-" + maxEnd + 
                " with total of " + max.ToString() + " drivers taking a break.";
        }
    }
}
