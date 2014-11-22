using System;
using System.Collections.Generic;
using ThingsOfInternet.Models;

namespace ThingsOfInternet.Services
{
    public class ThingsService : ServiceBase
    {
        protected IList<Scene> scenes;
        protected IList<IThing> things;
        protected Location homeLocation;

        public IList<IThing> GetThings()
        {
            if (things == null)
            {
                things = new IThing[]
                    {
                        new LightSwitch { Id = new Guid("{a41739c2-64f1-40ab-a6ea-836ac4d2fecd}"), DisplayName = "Living Room (Main)", DeviceId = "54ff6e066667515135122367" },
                        new LightSwitch { Id = new Guid("{737f08e5-02ef-49be-88e3-efe392b365b6}"), DisplayName = "Living Room (Floor Lamp 1)", DeviceId = "54ff6f066667515137531267" },
//                        new LightSwitch { DisplayName = "Living Room (Floor Lamp 2)", DeviceId = "54ff6a066667515138371467" },
//                        new BlindSwitch { DisplayName = "Living Room", DeviceId = "53ff72065075535148221087" }//,
//                        new BlindSwitch { DisplayName = "Test 2" },
//                        new BlindSwitch { DisplayName = "Test 3" },
//                        new BlindSwitch { DisplayName = "Test 4" },
//                        new BlindSwitch { DisplayName = "Test 1" },
//                        new BlindSwitch { DisplayName = "Test 2" },
//                        new BlindSwitch { DisplayName = "Test 3" },
//                        new BlindSwitch { DisplayName = "Test 4" },
//                        new BlindSwitch { DisplayName = "Test 1" },
//                        new BlindSwitch { DisplayName = "Test 2" },
//                        new BlindSwitch { DisplayName = "Test 3" },
//                        new BlindSwitch { DisplayName = "Test 4" }
                    };
            }

            return things;
        }

        public IList<Scene> GetScenes()
        {
            if (scenes == null)
            {
                scenes = new Scene[]
                    {
                        new Scene 
                        { 
                            DisplayName = "Living Room Lights", 
                            Things = new [] 
                                {
                                    new Guid("{a41739c2-64f1-40ab-a6ea-836ac4d2fecd}"), 
                                    new Guid("{737f08e5-02ef-49be-88e3-efe392b365b6}") 
                                }
                        }
                    };
            }

            return scenes;
        }

        public Location GetHomeLocation()
        {
            if (homeLocation == null)
            {
                homeLocation = new Location
                    {
                        Name = "Home",
                        Radius = 10129.46,
                        Coordinate = new Coordinate { Latitude = +33.839077, Longitude = -84.318861 }
                    };
            }

            return homeLocation;
        }

        public Guid GetMobileIdentifier()
        {
            return new Guid("{c5b1a00d-a0e9-4130-ba57-9578099c7d2b}");
        }
    }
}

