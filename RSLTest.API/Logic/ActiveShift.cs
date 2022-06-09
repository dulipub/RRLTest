using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSLTest.API.Logic
{
    public class ActiveShift
    {
        /// <summary>
        /// Calculate if there is a shift
        /// </summary>
        /// <param name="time">Time to evaluate</param>
        /// <param name="shiftStart">Start time of shift give as HH.MM AM or PM </param>
        /// <param name="shiftEnd">End time of shift give as HH.MM AM or PM </param>
        /// <returns></returns>
        public bool IsActiveShift(DateTime time, string shiftStart, string shiftEnd)
        {
            bool isActive = false;
            if (CheckDayShift( time))
            {
                return true;
            }
            else if (CheckNightShift( time))
            {
                return true;
            }

            return isActive;
        }

        private bool CheckNightShift(DateTime time)
        {
            //DateTime startTime = time.AddHours(9);

            //DateTime endTime = time.Add(DayShift);

            //if (time > startTime && time < endTime)
            //{
            //    return true;
            //}

            return false;
        }

        private bool CheckDayShift(DateTime time)
        {
            //DateTime startTime = time.AddHours(22);

            //DateTime endTime = time.Add(NightShift);

            //if (time > startTime && time < endTime)
            //{
            //    return true;
            //}

            return false;
        }
    }
}
