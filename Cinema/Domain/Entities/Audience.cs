using System;

namespace Cinema.Domain.Entities
{
    public class Audience
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime TimeOfGetTicket { get; set; }
    }
}
