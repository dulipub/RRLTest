using System;

namespace Logic
{
    public class ActiveShift
    {
        /// <summary>
        /// Calculate if there is a shift. Assuming shift last less than 12 hrs.
        /// </summary>
        /// <param name="time">Time to evaluate</param>
        /// <param name="shiftStart">Start time of shift give as HH.MM AM or PM </param>
        /// <param name="shiftEnd">End time of shift give as HH.MM AM or PM </param>
        /// <returns>True or false</returns>
        public bool IsActiveShift(DateTime currentTime, string shiftStart, string shiftEnd)
        {
            bool isActive = false;
            char[] delimeters = new char[] { '.', ' ' };

            string[] startTimeSplit = shiftStart.Split(delimeters);
            string[] endTimeSplit = shiftEnd.Split(delimeters);

            DateTime startDateTime = currentTime.Date;
            DateTime endDateTime = currentTime.Date;

            TimeSpan midDay = new TimeSpan(12, 0, 0);
            if (startTimeSplit[startTimeSplit.Length - 1] == "PM" && endTimeSplit[endTimeSplit.Length - 1] == "AM" && currentTime.TimeOfDay > midDay)
            {
                endDateTime = currentTime.Date.AddDays(1);
            }
            else if (startTimeSplit[startTimeSplit.Length - 1] == "PM" && endTimeSplit[endTimeSplit.Length - 1] == "AM" && currentTime.TimeOfDay < midDay)
            {
                startDateTime = currentTime.Date.AddDays(-1);
            }


            startDateTime = AddTime(startDateTime, startTimeSplit);
            endDateTime = AddTime(endDateTime, endTimeSplit);

            if (currentTime >= startDateTime && currentTime <= endDateTime)
            {
                isActive = true;
            }

            return isActive;
        }

        private DateTime AddTime(DateTime date, string[] split)
        {
            DateTime modified = DateTime.Now;
            int hours = int.Parse(split[0]);
            int mins = 0;
            if (split[split.Length - 1] == "PM")
            {
                hours += 12;
            }

            if (split.Length == 3)
            {
                mins = int.Parse(split[1]);
            }

            modified = date.AddHours(hours).AddMinutes(mins);
            return modified;
        }
    }
}
