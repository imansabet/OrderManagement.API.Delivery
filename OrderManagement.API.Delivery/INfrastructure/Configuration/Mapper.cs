using AutoMapper;
using OrderManagement.API.Delivery.DTO.ExternalApiModel.Response;
using OrderManagement.API.Delivery.INfrastructure.Entities;

namespace OrderManagement.API.Delivery.INfrastructure.Configuration
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Order,OrderResponse>().ReverseMap();
        }
    }
}
