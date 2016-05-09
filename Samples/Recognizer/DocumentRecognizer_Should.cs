using FakeItEasy;
using NUnit.Framework;
using Samples.Recognizer.Dependencies;

namespace Samples.Recognizer
{
    [TestFixture]
    public class DocumentRecognizer_Should
    {
        private DocumentRecognizer recognizer;
        private IRecognizeTool fastRecognizeTool;
        private IRecognizeTool defaultRecognizeTool;
        private IDocumentQualityChecker documentQualityChecker;
        private ILog log;
        private IImage image;
        private IDocument fastDocument;
        private IDocument defaultDocument;

        [SetUp]
        public void SetUp()
        {
            image = A.Fake<IImage>();
            fastDocument = A.Fake<IDocument>();
            defaultDocument = A.Fake<IDocument>();

            fastRecognizeTool = A.Fake<IRecognizeTool>();
            defaultRecognizeTool = A.Fake<IRecognizeTool>();
            documentQualityChecker = A.Fake<IDocumentQualityChecker>();
            log = A.Fake<ILog>();

            recognizer = new DocumentRecognizer(fastRecognizeTool, defaultRecognizeTool,
                documentQualityChecker, log);
        }

        [Test]
        public void UseFastTool_WhenItPossible()
        {
            A.CallTo(() => fastRecognizeTool.TryRecognize(image, out fastDocument))
                .Returns(true);
            A.CallTo(() => documentQualityChecker.CheckQualityIsSufficient(fastDocument))
                .Returns(true);

            var actualDocument = recognizer.Recognize(image);

            Assert.AreEqual(fastDocument, actualDocument);
        }

        [Test]
        public void UseDefaultTool_WhenQualityIsNotSufficient()
        {
            A.CallTo(() => fastRecognizeTool.TryRecognize(image, out fastDocument))
                .Returns(true);
            A.CallTo(() => documentQualityChecker.CheckQualityIsSufficient(fastDocument))
                .Returns(false);
            A.CallTo(() => defaultRecognizeTool.Recognize(image))
                .Returns(defaultDocument);

            var actualDocument = recognizer.Recognize(image);

            Assert.AreEqual(defaultDocument, actualDocument);
        }

        [Test]
        public void UseDefaultTool_WhenFastToolFails()
        {
            A.CallTo(() => fastRecognizeTool.TryRecognize(image, out fastDocument))
                .Returns(false);
            A.CallTo(() => defaultRecognizeTool.Recognize(image))
                .Returns(defaultDocument);

            var actualDocument = recognizer.Recognize(image);

            Assert.AreEqual(defaultDocument, actualDocument);
            A.CallTo(() => documentQualityChecker.CheckQualityIsSufficient(A<IDocument>._))
                .MustNotHaveHappened();
        }
    }
}