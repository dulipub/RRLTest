using RSLTest.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLTest.API.Services
{
    public class IOService<T> : IIOService<T>
    {
        public string ConvertListToCSV(IList<T> values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in values)
            {
                sb.AppendLine(value.ToString());
            }

            return sb.ToString();
        }
    }
}
