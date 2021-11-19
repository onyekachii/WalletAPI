using AutoMapper;
using BankAPI.Models.DTOs;
using BankAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterCustomerDTO, Customer>();
            CreateMap<RegisterCustomerDTO, User>();           
        }
    }
}
