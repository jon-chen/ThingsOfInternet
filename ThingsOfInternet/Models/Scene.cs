using System;
using System.Collections.Generic;
using System.Linq;

namespace ThingsOfInternet.Models
{
    public class Scene
    {
        public string DisplayName { get; set; }
        public IEnumerable<Guid> Things { get; set; }
    }
}

