
using AutoMapper;
using SoftIran.Application.ViewModels.Identity.User.Cmd;
using SoftIran.Application.ViewModels.Identity.User.Query;
using SoftIran.DataLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Profiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<UpsertUserCmd, ApplicationUser>();

            CreateMap<ApplicationUser, UserDto>();
              // .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

    }
}
