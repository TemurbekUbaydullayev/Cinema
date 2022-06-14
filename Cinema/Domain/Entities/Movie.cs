using Cinema.Domain.Enums;

namespace Cinema.Domain.Entities
{
    public class Movie : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
        public string StartTime { get; set; }
    }
}
