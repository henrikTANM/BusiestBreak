
namespace BusBreak
{
    /* Time
     * Represents breaks start or end time as
     * integers h and m for hours and minutes
     */
    internal class Time
    {
        private readonly int h;
        private readonly int m;
        public bool isStartTime;

        public Time(string time, bool isStartTime) 
        {
            h = int.Parse(time.Split(":")[0]);
            m = int.Parse(time.Split(":")[1]);
            this.isStartTime = isStartTime;
        }



        // Checks if this time is before given time
        public bool IsBefore(Time time)
        {
            if (h < time.h) return true;
            if (h == time.h & m < time.m) return true;
            return false;
        }



        // Checks if this time and the given time match
        public bool IsSameTime(Time time)
        {
            return h == time.h & m == time.m;
        }



        public override string ToString()
        {
            return 
                (h < 10 ? "0" : "") + h.ToString() + 
                ":" +
                (m < 10 ? "0" : "") + m.ToString();
        }
    }
}
