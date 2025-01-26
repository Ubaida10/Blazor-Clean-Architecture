using System.Runtime.InteropServices.JavaScript;

namespace Core.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }

        //public ICollection<MovieActor> MovieActors { get; set; }
    }
}
