using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace moviesNow.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Director{ get; set; }
        public string DateRelease { get; set; }
    }
}