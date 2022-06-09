using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSLTest.API.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }
}
