using AutoMapper;
using OrderManagement.API.Delivery.INfrastructure.Entities;

namespace OrderManagement.API.Delivery.INfrastructure.Configuration
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //CreateMap<Order,DTO.ExternalApiModel.Response.OrderResponse>().ReverseMap();
            CreateMap<Order,DTO.InternalAPIModel.Response.OrderResponse>().ReverseMap();
            CreateMap<DTO.InternalAPIModel.Response.OrderResponse,DTO.ExternalAPIModel.Response.OrderResponse>().ReverseMap();    
            //CreateMap<Customer, DTO.ExternalApiModel.Request.CustomerIdRequest>.ReverseMap();
            //CreateMap<Customer, DTO.InternalAPIModel.Request.CustomerIdRequest>.ReverseMap();
        }
    }
}
