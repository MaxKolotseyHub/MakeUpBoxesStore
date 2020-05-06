using AutoMapper;
using MakeUpBoxesStore.Models.DbEntities;
using MakeUpBoxesStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Helpers
{
    public class AutoMapperConfig
    {
        private static Mapper mapper;
        public static Mapper GetMapper()
        {
            if (mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductDetailsViewModel>()
                    .ForMember("Images", opt => opt.MapFrom(c => c.Images.Select(x => x.Url).ToList()))
                    .ForMember("ProducerInfo", opt => opt.MapFrom(c => c.Producer.Title + ", " + c.Producer.Address));

                    cfg.CreateMap<Product, PurchaseProduct>()
                    .ForMember("Producer", opt=>opt.MapFrom(x=>x.Producer.Title + ", " + x.Producer.Address));
                    
                    cfg.CreateMap<Product, ProductListViewModel>()
                    .ForMember("Producer", opt=>opt.MapFrom(x=>x.Producer.Title + ", " + x.Producer.Address));

                    cfg.CreateMap<Purchase, EditPurchaseViewModel>()
                    .ForMember("ClientName", opt => opt.MapFrom(x => x.Client.Name))
                    .ForMember("ClientAddress", opt => opt.MapFrom(x => x.Client.Address))
                    .ForMember("ClientPhone", opt => opt.MapFrom(x => x.Client.Phone))
                    .ForMember("Products", opt => opt.MapFrom(x => x.Products));

                });
                mapper = new Mapper(config);
            }
            return mapper;
        }
    }
}