using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLava.Models
{
    public class MovieCharacter : Entity
    {
        public decimal Rating { get; set; }
        public int VoteCount { get; set; }
        public Movie? Movie { get; set; }
        public DateOnly AppearDate { get; set; }
    }

    public class HumanCharacter : MovieCharacter
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Actor Actor { get; set; }
    }

    public class AnimalCharacter : MovieCharacter
    {
        public string Title { get; set; }
        public Gender Gender { get; set; }

    }

    public class FictionalCharacter : MovieCharacter
    {
        public string Title { get; set; }
    }
}
