using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLava.Models
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Rating RatingImdb { get; set; }
        public Rating RatingRottenTomatoes { get; set; }
        public Rating RatingMetacritic { get; set; }
        public List<MovieCharacter> Characters { get; set; }
        public List<string> Cast { get; set; }
    }
}
