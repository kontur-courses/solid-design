namespace Mocks.ThingCache.Dependencies
{
    public interface IThingService
    {
        bool TryRead(string thingId, out Thing value);
    }
}