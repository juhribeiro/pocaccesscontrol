using System;
using accesscontrol.Data;
using accesscontrol.Model;
using AutoMapper;

namespace accesscontrol.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<User, UserModel>();
            this.CreateMap<UserModel, User>();

            this.CreateMap<Application, ApplicationModel>();
            this.CreateMap<Application, ApplicationModel>();

            this.CreateMap<Role, RoleModel>();
            this.CreateMap<RoleModel, Role>();

            this.CreateMap<BaseData, BaseDataModel>();
            this.CreateMap<BaseDataModel, BaseData>();

            this.CreateMap<BaseEntity, BaseModel>();

            this.CreateMap<BaseModel, BaseEntity>()
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            this.CreateMap<Group, GroupModel>()
            .ForMember(dest => dest.ApplicationCode, opt => opt.MapFrom(src => src.Application.Code));

            this.CreateMap<GroupModel, Group>();
        }
    }
}