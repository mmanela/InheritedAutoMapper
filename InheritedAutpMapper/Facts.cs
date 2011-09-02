using AutoMapper;
using Xunit;

namespace InheritedAutoMapper
{
    public class Facts
    {
        public Facts()
        {
            Mapper.Reset();
        }

        [Fact]
        public void Will_not_map_inherited_properties_when_using_base_mapping()
        {
            Mappings.CreateBasicMapping();
            var source = new SourceChildClass
                             {
                                 ChildProp1 = "child1",
                                 ChildProp2 = "child2",
                                 BaseProp1 = "base1",
                                 BaseProp2 = "base2"
                             };

            var res = Mapper.Map<SourceChildClass, DestChildClass>(source);

            Assert.Equal(source.ChildProp1, res.ChildProp1);
            Assert.Equal(source.ChildProp2, res.ChildPropTwo);
            Assert.Equal(source.BaseProp1, res.BaseProp1);   // Passes, because it matches convention
            Assert.Equal(source.BaseProp2, res.BasePropTwo); // Fails!, since it does not inherit this mapping from the BaseTypes mappings
        }

        [Fact]
        public void Will_map_inherited_properties_when_using_inherited_mapping_for_both_base_types()
        {
            Mappings.CreateInheritedMappingUsingBothBaseTypes();
            var source = new SourceChildClass
                             {
                                 ChildProp1 = "child1",
                                 ChildProp2 = "child2",
                                 BaseProp1 = "base1",
                                 BaseProp2 = "base2"
                             };

            var res = Mapper.Map<SourceChildClass, DestChildClass>(source);

            Assert.Equal(source.ChildProp1, res.ChildProp1);
            Assert.Equal(source.ChildProp2, res.ChildPropTwo);
            Assert.Equal(source.BaseProp1, res.BaseProp1);   // Passes, because it matches convention
            Assert.Equal(source.BaseProp2, res.BasePropTwo); // Passes!, since it does inherit this mapping from the BaseType's mappings
        }

        [Fact]
        public void Will_map_inherited_properties_when_using_inherited_mapping_for_one_base_type()
        {
            Mappings.CreateInheritedMappingUsingRightBaseType();
            var source = new SourceBaseClass
            {
                BaseProp1 = "base1",
                BaseProp2 = "base2"
            };

            var res = Mapper.Map<SourceBaseClass, DestChildClass>(source);

            Assert.Equal(source.BaseProp1, res.BaseProp1);   // Passes, because it matches convention
            Assert.Equal(source.BaseProp2, res.BasePropTwo); // Passes!, since it does inherit this mapping from the BaseType's mappings
        }


        [Fact]
        public void Will_assert_configuration_is_invalid_when_using_inherited_mappings_unfortunately()
        {
            Mappings.CreateInheritedMappingUsingBothBaseTypes();
            Mapper.AssertConfigurationIsValid();
        }
    }
}