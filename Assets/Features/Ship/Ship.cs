using Features.Ship.Components;

namespace Features.Ship
{
    using System.Collections.Generic;

    [System.Serializable]
    public class Ship
    {
        public List<BasicComponent> Components = new()
        {
            new BasicComponent { XSize = 0.25f, YSize = 0.5f, XPosition = -0.125f, YPosition = 0.5f },
            new BasicComponent { XSize = 0.25f, YSize = 0.5f, XPosition = 2.125f, YPosition = 0.5f },
            new BasicComponent { XSize = 1, YSize = 0.5f, XPosition = 1, YPosition = 0.75f },
            new BasicComponent { XSize = 2, YSize = 1, XPosition = 1, YPosition = 0 },
            new BasicComponent { XSize = 2, YSize = 1, XPosition = 1, YPosition = -1 },
            new BasicComponent { XSize = 2, YSize = 2, XPosition = 1, YPosition = -2.5f },
            new BasicComponent { XSize = 0.5f, YSize = 2, XPosition = -0.25f, YPosition = -3f },
            new BasicComponent { XSize = 0.5f, YSize = 2, XPosition = 2.25f, YPosition = -3f },
        };
    }
}