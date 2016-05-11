using FakeItEasy;
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
            //thingService = ...
            thingCache = new ThingCache(thingService);
        }
    }
}