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
           
            this.CreateMap<ApplicationModel, Application>();
          
            this.CreateMap<Role, RoleModel>();
            this.CreateMap<RoleModel, Role>();

            this.CreateMap<BaseData, BaseDataModel>();
            this.CreateMap<BaseDataModel, BaseData>();

            this.CreateMap<BaseEntity, BaseModel>();
            this.CreateMap<BaseModel, BaseEntity>();

            this.CreateMap<Group, GroupModel>();
            this.CreateMap<GroupModel, Group>();

            this.CreateMap<UserApplication, UserApplicationModel>();
            this.CreateMap<UserApplicationModel, UserApplication>();

            this.CreateMap<RoleGroup, RoleGroupModel>();
            this.CreateMap<RoleGroupModel, RoleGroup>();

            this.CreateMap<UserGroup, UserGroupModel>();
            this.CreateMap<UserGroupModel, UserGroup>();
        }
    }
}