using AutoMapper;
using System;

namespace ClientAutoMapper
{
    public class MapClient
    {
        
        public MapClient()
        {
            var mapperConfig = new MapperConfiguration(m => { });
            IMapper mapper = mapperConfig.CreateMapper();
        }

    }
}
