using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace ThingsOfInternet.Serialization
{
    /// <summary>
    /// http://www.tecsupra.com/serializing-only-some-properties-of-an-object-to-json-using-newtonsoft-json-net/
    /// </summary>
    public class DynamicContractResolver : DefaultContractResolver
    {
        private ICollection<string> _propertiesToSerialize = null;

        public DynamicContractResolver(ICollection<string> propertiesToSerialize)
        {
            _propertiesToSerialize = propertiesToSerialize;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            return properties.Where(p => _propertiesToSerialize.Contains(p.PropertyName)).ToList();
        }
    }
}

