using System;
using System.Linq;

namespace AutoMapper.Extensions
{
    public static class Inheritance
    {
        public enum WithBaseFor
        {
            Left,
            Right,
            Both
        }

        public static void InheritMappingFromBaseType<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression,
                                                                             WithBaseFor baseFor = WithBaseFor.Both)
        {
            var sourceType = typeof (TSource);
            var destinationType = typeof (TDestination);
            var sourceParentType = baseFor == WithBaseFor.Both || baseFor == WithBaseFor.Left
                                       ? sourceType.BaseType
                                       : sourceType;

            var destinationParentType = baseFor == WithBaseFor.Both || baseFor == WithBaseFor.Right
                                            ? destinationType.BaseType
                                            : destinationType;


            mappingExpression
                .BeforeMap((x, y) => Mapper.Map(x, y, sourceParentType, destinationParentType))
                .ForAllMembers(x => x.Condition(r => NotAlreadyMapped(sourceParentType, destinationParentType, r)));
        }


        private static bool NotAlreadyMapped(Type sourceType, Type desitnationType, ResolutionContext r)
        {
            return !r.IsSourceValueNull &&
                   Mapper.FindTypeMapFor(sourceType, desitnationType).GetPropertyMaps().Where(
                       m => m.DestinationProperty.Name.Equals(r.MemberName)).Select(y => !y.IsMapped()).All(b => b);
        }
    }
}