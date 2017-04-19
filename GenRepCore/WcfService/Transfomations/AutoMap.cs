using AutoMapper;

namespace WcfService.Transfomations
{
    public static class AutoMap
    {
        private static AutoMapper.IMapper Mapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InventoryService.Customer, Models.Customer>().ReverseMap();
            });

            return config.CreateMapper();
        }

        public static DestinationType ConvertTo<DestinationType, T1>(T1 source)
        {
            return Mapper().Map<DestinationType>(source);
        }
    }
}
