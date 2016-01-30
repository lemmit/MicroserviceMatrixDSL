namespace MicroserviceMatrixDSL.CodeTranspiler.Interfaces
{
    public interface ITranspiler
    {
        string GeneratedCode { get; }
        string CodeBefore();
        string CodeAfter();
    }
}