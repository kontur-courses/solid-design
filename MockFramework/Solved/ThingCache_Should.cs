using FakeItEasy;
using NUnit.Framework;

namespace MockFramework.Solved
{
    [TestFixture]
    public class ThingCache_Should
    {
        private IThingService thingService;
        private ThingCache thingCache;

        private const string thingId1 = "TheDress";
        private Thing thing1 = new Thing(thingId1);

        private const string thingId2 = "CoolBoots";
        private Thing thing2 = new Thing(thingId2);

        [SetUp]
        public void SetUp()
        {
            thingService = A.Fake<IThingService>(x => x.Strict());
            thingCache = new ThingCache(thingService);
        }

        [Test]
        public void AskThingAndReturnIt()
        {
            A.CallTo(() => thingService.TryRead(thingId1, out thing1))
                .Returns(true).Once();

            var actualThing = thingCache.Get(thingId1);
            Assert.AreEqual(thingId1, actualThing.ThingId);
        }

        [Test]
        public void AskThingAndReturnNull_WhenNotFound()
        {
            Thing outThing;
            A.CallTo(() => thingService.TryRead(thingId1, out outThing))
                .Returns(false);

            var actualThing = thingCache.Get(thingId1);
            Assert.IsNull(actualThing);
        }

        [Test]
        public void NotAskThing_OnSecondGet()
        {
            A.CallTo(() => thingService.TryRead(thingId1, out thing1))
                .Returns(true).Once();

            thingCache.Get(thingId1);
            var reaskedThing = thingCache.Get(thingId1);
            Assert.AreEqual(thingId1, reaskedThing.ThingId);
        }

        [Test]
        public void AskForEachThing_WhenSeveralThings()
        {
            A.CallTo(() => thingService.TryRead(thingId1, out thing1))
                .Returns(true).Once();

            A.CallTo(() => thingService.TryRead(thingId2, out thing2))
                .Returns(true).Once();

            var actualThing1 = thingCache.Get(thingId1);
            var actualThing2 = thingCache.Get(thingId2);
            Assert.AreEqual(thingId1, actualThing1.ThingId);
            Assert.AreEqual(thingId2, actualThing2.ThingId);
        }

        [Test]
        public void NotAskThing_OnSecondGet_WhenSeveralThings()
        {
            A.CallTo(() => thingService.TryRead(thingId1, out thing1))
                .Returns(true).Once();

            A.CallTo(() => thingService.TryRead(thingId2, out thing2))
                .Returns(true).Once();

            thingCache.Get(thingId1);
            thingCache.Get(thingId2);
            var reaskedThing1 = thingCache.Get(thingId1);
            var reaskedThing2 = thingCache.Get(thingId2);
            Assert.AreEqual(thingId1, reaskedThing1.ThingId);
            Assert.AreEqual(thingId2, reaskedThing2.ThingId);
        }
    }
}