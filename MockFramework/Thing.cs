namespace MockFramework
{
    public class Thing
    {
        public Thing(string thingId)
        {
            ThingId = thingId;
        }

        public string ThingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}