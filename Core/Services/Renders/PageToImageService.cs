namespace DnsTwisterMonitor.Core.Services.Renders
{
    public class PageToImageService : IImageRenderService
    {
        private const string PageToImageApiKey = "279f978873a18207";

        private const string PageToImageServiceBaseUrl = "http://api.page2images.com/directlink";

        private const int ScreenSizeWidth = 1280;
        private const int ScreenSizeHeight = 1024;

        private const int ThumbnailSizeWidth = 240;
        private const int ThumbnailSizeHeight = 180;

        private const int RenderingDelay = 5;

        public string GenerateImageUrl(string domainUrl)
        {
            var imageUrl = $"{PageToImageServiceBaseUrl}?" +
                           $"p2i_url=http://{domainUrl}&" +
                            "p2i_device=6&" +
                           $"p2i_screen={ScreenSizeWidth}x{ScreenSizeHeight}&" +
                           $"p2i_size={ThumbnailSizeWidth}x{ThumbnailSizeHeight}&" +
                           $"p2i_wait={RenderingDelay}&" +
                           $"p2i_key={PageToImageApiKey}";

            return imageUrl;
        }
    }
}