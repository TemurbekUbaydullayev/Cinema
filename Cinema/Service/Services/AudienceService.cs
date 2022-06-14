using Cinema.Data.IRepositories;
using Cinema.Data.Repositories;
using Cinema.Domain.Entities;
using Cinema.Service.DTOs;
using Cinema.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                TimeOfGetTicket = entity.TimeOfGetTicket
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
                TimeOfGetTicket = audience.TimeOfGetTicket
            };
        }
    }
}
