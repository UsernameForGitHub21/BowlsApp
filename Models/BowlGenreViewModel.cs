using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BowlsApp.Models
{
    public class BowlGenreViewModel
    {
        public List<Bowl> Bowls { get; set; }
        public SelectList Genres { get; set; }
        public string BowlGenre { get; set; }
        public string SearchString { get; set; }
    }
}
