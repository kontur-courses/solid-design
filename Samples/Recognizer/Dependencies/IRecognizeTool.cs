namespace Samples.Recognizer.Dependencies
{
    public interface IRecognizeTool
    {
        IDocument Recognize(IImage image);
        bool TryRecognize(IImage image, out IDocument document);
    }
}
