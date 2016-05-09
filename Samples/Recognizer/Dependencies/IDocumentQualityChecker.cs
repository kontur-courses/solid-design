namespace Samples.Recognizer.Dependencies
{
    public interface IDocumentQualityChecker
    {
        bool CheckQualityIsSufficient(IDocument document);
    }
}