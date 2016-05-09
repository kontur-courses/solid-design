using Samples.Recognizer.Dependencies;

namespace Samples.Recognizer
{
    public class DocumentRecognizer
    {
        private readonly IRecognizeTool fastRecognizeTool;
        private readonly IRecognizeTool defaultRecognizeTool;
        private readonly IDocumentQualityChecker documentQualityChecker;
        private readonly ILog log;

        public DocumentRecognizer(
            IRecognizeTool fastRecognizeTool,
            IRecognizeTool defaultRecognizeTool,
            IDocumentQualityChecker documentQualityChecker,
            ILog log)
        {
            this.fastRecognizeTool = fastRecognizeTool;
            this.defaultRecognizeTool = defaultRecognizeTool;
            this.documentQualityChecker = documentQualityChecker;
            this.log = log;
        }

        public IDocument Recognize(IImage image)
        {
            log.LogInfo("Used fast recognize tool");
            IDocument document;
            if (fastRecognizeTool.TryRecognize(image, out document))
                if (documentQualityChecker.CheckQualityIsSufficient(document))
                    return document;

            log.LogInfo("Used default recognize tool");
            return defaultRecognizeTool.Recognize(image);
        }
    }
}
