﻿using AutoMapper;
using SoftIran.Application.ViewModels.Equipment.Query;
using SoftIran.Application.ViewModels.Equipment.Upsert;
using SoftIran.DataLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Profiles
{
    public class EquipmentProfile : Profile

    {

        public EquipmentProfile()
        {
            CreateMap<UpsertEquipmentCmd, Equipment>().
                ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpsertEquipmentCmd, Equipment>().
                ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<Equipment, EquipmentDto>();
             //  ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
