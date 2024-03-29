﻿namespace MovieLava.Models
{
    public class Actor : Entity
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public decimal Rating { get; set; }
        public List<Movie> Movies { get; set; }

    }

    public class FamousActor : Actor
    {
        public List<Award> Oscras { get; set; }
        public bool IsInPeopleHeart { get; set; }
    }

    public class Award
    {
        public AwardStatus Status { get; set; }
    }
}