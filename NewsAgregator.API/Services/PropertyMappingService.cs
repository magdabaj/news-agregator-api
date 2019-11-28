using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Services;
using NewsAgregator.API.Entities;
using NewsAgregator.API.Models;

namespace NewsAgregator.API.Services
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private Dictionary<string, PropertyMappingValue> _userPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                {"Id", new PropertyMappingValue(new List<string>() {"Id"})},
                {"Email", new PropertyMappingValue(new List<string>() {"Email"})},
                {"Age", new PropertyMappingValue(new List<string>() {"DateOfBirth"}, true)},
                {"Name", new PropertyMappingValue(new List<string>() {"FirstName", "LastName"})}
            };

        private IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<UserDto, User>(_userPropertyMapping));
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            // the string is separated by comma
            var fieldsAfterSplit = fields.Split(',');

            //run through the fields clauses
            foreach (var field in fieldsAfterSplit)
            {
                //trim
                var trimmedField = field.Trim();

                //remove everything after the first " " - if the fields
                // are coming from an orderBy string, this pasrt must be
                // ignored
                var indexOfFirstSpace = trimmedField.IndexOf(" ");
                var propertyName = indexOfFirstSpace == -1 ? trimmedField : trimmedField.Remove(indexOfFirstSpace);

                // find the matching property
                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }

            }

            return true;
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping
            <TSource, TDestination>()
        {
            // get matching mapping
            var matchingMapping = _propertyMappings
                .OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First()._mappingDictionary;
            }

            throw new Exception($"Cannot find exact property mapping instance " +
                                $"for <{typeof(TSource)},{typeof(TDestination)}");
        }
    }
}
