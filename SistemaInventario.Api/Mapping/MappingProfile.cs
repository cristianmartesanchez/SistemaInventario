using SistemaInventario.Core.DTOs;
using SistemaInventario.Core.Models;
using AutoMapper;

namespace SistemaInventario.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<ProductTypeDto, ProductType>();
            CreateMap<ProductType, ProductTypeDto>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerTypeDto, CustomerType>();
            CreateMap<CustomerType, CustomerTypeDto>();

            CreateMap<NumberSequenceDto, NumberSequence>();
            CreateMap<NumberSequence, NumberSequenceDto>();

            CreateMap<UnitOfMeasureDto, UnitOfMeasure>();
            CreateMap<UnitOfMeasure, UnitOfMeasureDto>();
        }
    }
}
