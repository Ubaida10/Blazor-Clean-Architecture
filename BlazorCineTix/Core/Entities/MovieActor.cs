﻿namespace Core.Entities
{
    public class MovieActor
    {
        public int Id { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        public int ActorID { get; set; }
        public Actor Actor { get; set; }
    }
}
