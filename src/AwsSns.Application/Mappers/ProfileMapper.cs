using AutoMapper;
using AwsSns.Domain.Entities;
using AwsSns.Domain.Entities.Dao;
using AwsSns.Domain.Entities.Dto;

namespace AwsSns.Application.Mappers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Status, StatusResponse>();

            // Publish 
            CreateMap<PublishRequestDto, PublishRequestDao>();
            CreateMap<PublishResponseDao, PublishResponseDto>();

            // Subscribe
            CreateMap<SubscribeRequestDto, SubscribeRequestDao>();
            CreateMap<SubscribeResponseDao, SubscribeResponseDto>();

            // Unsubscribe
            CreateMap<UnsubscribeRequestDto, UnsubscribeRequestDao>();
            CreateMap<UnsubscribeResponseDao, UnsubscribeResponseDto>();
        }
    }
}
