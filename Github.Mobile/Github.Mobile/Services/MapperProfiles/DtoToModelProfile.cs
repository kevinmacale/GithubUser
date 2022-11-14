using AutoMapper;
using Github.Mobile.Dtos;
using Github.Mobile.Models;

namespace Github.Mobile.Services.MapperProfiles
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<GithubUserProfileTransport, GithubUserProfileModel>();
        }
    }
}
