using Cinema.Data.IRepositories;
using Cinema.Data.Repositories;
using Cinema.Domain.Entities;
using Cinema.Service.DTOs;
using Cinema.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Service.Services
{
    public class AudienceService : IAudienceService
    {
        private readonly IAudienceRepository audienceRepository;
        public AudienceService()
        {
            audienceRepository = new AudienceRepository();
        }
        public AudienceDto Create(AudienceDto entity)
        {
            AudienceDto audienceCheck = GetAll().FirstOrDefault(p => p.Email.Equals(entity.Email));

            if (audienceCheck != null)
                return null;

            var audience = new Audience
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                MovieName = entity.MovieName
            };

            return ConvertToViewModel(audienceRepository.Create(audience));
        }

        public IEnumerable<AudienceDto> GetAll()
            => audienceRepository.GetAll().Select(p => new AudienceDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                MovieName = p.MovieName,
                TimeOfGetTicket = p.TimeOfGetTicket
            });

        private AudienceDto ConvertToViewModel(Audience audience)
        {
            return new AudienceDto
            {
                Id = audience.Id,
                FirstName = audience.FirstName,
                LastName = audience.LastName,
                Email = audience.Email,
                MovieName = audience.MovieName,
                TimeOfGetTicket = audience.TimeOfGetTicket
            };
        }
    }
}
