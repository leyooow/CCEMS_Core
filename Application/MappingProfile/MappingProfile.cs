﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.DTOs.Employee;
using Application.Models.DTOs.FBranch;
using Application.Models.DTOs.Group;
using Application.Models.DTOs.User;
using AutoMapper;
using Domain.FEntities;
using Infrastructure.Entities;

namespace Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Group, GroupCreateDTO>().ReverseMap();
            CreateMap<Group, GroupUpdateDTO>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();

            CreateMap<BranchCodeTable, BranchCodeTableDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.BranchAccesses, opt => opt.MapFrom(src =>
                src.BranchAccesses.Select(ba => new BranchAccess
                {
                    BranchId = ba.BranchId,
                    EmployeeId = src.EmployeeId,
                    UsersLoginName = src.LoginName
                })));
            CreateMap<UserUpdateDTO, User>()
                .ForMember(dest => dest.BranchAccesses, opt => opt.MapFrom(src => src.BranchAccessIds.Select(id => new BranchAccess { BranchId = id, EmployeeId = src.EmployeeId }).ToList()));


            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<PermissionLookup, PermissionLookupDTO>().ReverseMap();
            CreateMap<RolePermission, RolePermissionDTO>().ReverseMap();

        }
    }
}
