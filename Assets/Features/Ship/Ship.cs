namespace Features.Ship
{
    using System.Collections.Generic;

    [System.Serializable]
    public class Ship
    {
        [System.Serializable]
        public class ShipComponentData
        {
            public int x;
            public int y;
        }

        public List<ShipComponentData> components;

        public Ship()
        {
            // Define your ship layout here
            components = new List<ShipComponentData>
            {
                new ShipComponentData { x = 0, y = 0 }, // center
                new ShipComponentData { x = 0, y = 1 }, // up
                new ShipComponentData { x = 0, y = -1 }, // down
                new ShipComponentData { x = 1, y = 0 }, // right
                new ShipComponentData { x = -1, y = 0 } // left
            };
        }
    }
}