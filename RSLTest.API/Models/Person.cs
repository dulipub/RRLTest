using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSLTest.API.Models
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }
    }
}
