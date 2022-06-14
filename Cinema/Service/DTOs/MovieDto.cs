using Cinema.Domain.Enums;
using System;

namespace Cinema.Service.DTOs
{
    public class MovieDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
        public string StartTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
