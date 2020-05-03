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
                });
                mapper = new Mapper(config);
            }
            return mapper;
        }
    }
}