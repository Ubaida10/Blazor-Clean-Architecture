using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Producer
    {
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Biography { get; set; }
    }
}
