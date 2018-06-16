using AutoMapper;

namespace GMS.UI.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(x =>
            {
                x.AddProfile(new DomainToViewModelMappingProfile());
                x.AddProfile(new ViewModelToDomainMappingProfile());
            });

        }
    }
}