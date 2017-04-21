namespace DnsTwisterMonitor.Core.Services.Renders
{
    public interface IImageRenderService
    {
        string GenerateImageUrl(string domainUrl);
    }
}