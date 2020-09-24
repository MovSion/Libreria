using AutoMapper;
using Libreria.Dtos;
using Libreria.Models;

namespace Libreria.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserReadDTO, User>();
        }
    }
}