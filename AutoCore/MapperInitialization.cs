using AutoMapper;

namespace AutoCore
{
    public static class MapperInitialization
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });
        }
    }
}
