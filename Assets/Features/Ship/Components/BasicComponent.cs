namespace Features.Ship.Components
{
    public class BasicComponent : IShipComponent
    {
        public float XSize { get; set; }
        public float YSize { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
    }
}