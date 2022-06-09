using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSLTest.API.Models
{
    public class Post : BaseModel
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedTime { get; set; }

        public string AuthorName { get; set; }

        public int TotalLikes { get; set; }

        public override string ToString()
        {

            return $"{Title}, {ImageUrl}, {CreatedTime}, {AuthorName}, {TotalLikes}";
        }

    }
}
