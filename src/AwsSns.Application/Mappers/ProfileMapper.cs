using AutoMapper;
using AwsSns.Domain.Dtos;
using AwsSns.Domain.Entities;

namespace AwsSns.Application.Mappers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Status, StatusResponse>();

            // Publish 
            CreateMap<PublishRequestDto, PublishRequest>();
            CreateMap<PublishResponse, PublishResponseDto>();

            // Subscribe
            CreateMap<SubscribeRequestDto, SubscribeRequest>();
            CreateMap<SubscribeResponse, SubscribeResponseDto>();

            // Unsubscribe
            CreateMap<UnsubscribeRequestDto, UnsubscribeRequest>();
            CreateMap<UnsubscribeResponse, UnsubscribeResponseDto>();
        }
    }
}
