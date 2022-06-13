﻿using Cinema.Data.IRepositories;
using Cinema.Data.Repositories;
using Cinema.Domain.Entities;
using Cinema.Service.DTOs;
using Cinema.Service.Extensions;
using Cinema.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;
        public AdminService()
        {
            adminRepository = new AdminRepository();
        }

        public AdminViewModel Create(AdminForCreationDto adminDto)
        {
            AdminViewModel adminCheck = GetAll().FirstOrDefault(p => p.Email.Equals(adminDto.Email));

            if (adminCheck != null)
                return null;

            var admin = new Admin
            {
                FirstName = adminDto.FirstName.GetCapitalize(),
                LastName = adminDto.LastName.GetCapitalize(),
                Age = adminDto.Age,
                Phone = adminDto.Phone,
                Email = adminDto.Email,
                Password = adminDto.Password.GetHashPassword()
            };

            return ConvertToViewModel(adminRepository.Create(admin));
        }

        public bool Delete(long id)
        {
            AdminViewModel adminCheck = GetAll().FirstOrDefault(p => p.Equals(id));

            if (adminCheck != null)
                return adminRepository.Delete(id);

            return false;
        }

        public AdminViewModel Get(long id)
        {
            AdminViewModel adminCheck = GetAll().FirstOrDefault(p => p.Equals(id));

            if (adminCheck != null)
                return ConvertToViewModel(adminRepository.Get(id));

            return null;
        }

        public IEnumerable<AdminViewModel> GetAll()
            => adminRepository.GetAll().Select(p => new AdminViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Phone= p.Phone,
                Email = p.Email,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });

        public AdminViewModel Update(AdminForCreationDto admin)
        {
            AdminViewModel adminCheck = GetAll().FirstOrDefault(p => p.Id == admin.Id);

            if (adminCheck is null)
                return null;

            var entity = new Admin
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Age = admin.Age,
                Phone = admin.Phone,
                Email = admin.Email,
                Password = adminRepository.Get(admin.Id).Password,
                CreatedAt = adminCheck.CreatedAt,
                UpdatedAt = adminCheck.UpdatedAt
            };

            return ConvertToViewModel((adminRepository.Update(entity)));
        }

        private AdminViewModel ConvertToViewModel(Admin admin)
        {
            return new AdminViewModel
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                CreatedAt = admin.CreatedAt,
                UpdatedAt = admin.UpdatedAt
            };
        }
    }
}
