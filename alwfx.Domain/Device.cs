namespace alwfx.Domain
{
    /// <summary>
    /// Device Domain entity
    /// </summary>
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Mode Mode { get; set; }
        public Status Status { get; set; }
        public int ToNotification { get; set; }
        public int ToAlert { get; set; }
    }
}