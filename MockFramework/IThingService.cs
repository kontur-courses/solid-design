namespace MockFramework
{
    public interface IThingService
    {
        bool TryRead(string thingId, out Thing value);
    }
}