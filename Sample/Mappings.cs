using AutoMapper;
using AutoMapper.Extensions;

namespace InheritedAutoMapper
{
    public static class Mappings
    {
        public static void CreateBasicMapping()
        {
            Mapper.CreateMap<SourceBaseClass, DestBaseClass>()
                .ForMember(x => x.BasePropTwo, m => m.MapFrom(x => x.BaseProp2));

            Mapper.CreateMap<SourceChildClass, DestChildClass>()
                .ForMember(x => x.ChildPropTwo, m => m.MapFrom(x => x.ChildProp2));
        }

        public static void CreateInheritedMappingUsingBothBaseTypes()
        {
            Mapper.CreateMap<SourceBaseClass, DestBaseClass>()
                .ForMember(x => x.BasePropTwo, m => m.MapFrom(x => x.BaseProp2));

            Mapper.CreateMap<SourceChildClass, DestChildClass>()
                .ForMember(x => x.ChildPropTwo, m => m.MapFrom(x => x.ChildProp2))
                .InheritMappingFromBaseType();
        }


        public static void CreateInheritedMappingUsingRightBaseType()
        {
            Mapper.CreateMap<SourceBaseClass, DestBaseClass>()
                .ForMember(x => x.BasePropTwo, m => m.MapFrom(x => x.BaseProp2));

            Mapper.CreateMap<SourceBaseClass, DestChildClass>()
                .InheritMappingFromBaseType(WithBaseFor.Destination);
        }
    }
}