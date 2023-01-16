using AutoMapper;

namespace WCLWebAPI.Server.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config => {
                config.AddProfile(new SourceToViewModelMappingProfile());
            });
        }
    }
}
