using RSLTest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSLTest.API.Services
{
    public interface IIOService<T>
    {
        public string ConvertListToCSV(IList<T> values);
    }
}
