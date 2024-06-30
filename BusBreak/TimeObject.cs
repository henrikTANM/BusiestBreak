using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusBreak
{
    internal class TimeObject
    {
        private readonly int h;
        private readonly int m;
        public bool isStartTime;

        public TimeObject(string time, bool isStartTime) 
        {
            h = int.Parse(time.Split(":")[0]);
            m = int.Parse(time.Split(":")[1]);
            this.isStartTime = isStartTime;
        }

        public bool IsBefore(TimeObject timeObject)
        {
            if (h < timeObject.h) { return true; }
            if (h == timeObject.h & m < timeObject.m) { return true; }
            return false;
        }

        public bool IsSameTime(TimeObject timeObject)
        {
            return h == timeObject.h & m == timeObject.m;
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
