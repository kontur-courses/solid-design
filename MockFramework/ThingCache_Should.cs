using FakeItEasy;
using Mocks.ThingCache.Dependencies;
using NUnit.Framework;

namespace MockFramework
{
    [TestFixture]
    public class ThingCache_Should
    {
        private IThingService thingService;
        private ThingCache thingCache;

        [SetUp]
        public void SetUp()
        {
            thingCache = new ThingCache(thingService);
        }
    }
}