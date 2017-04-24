namespace SquatFinder.Web.Core.Services.Renders
{
	public class PageToImageService : IImageRenderService
	{
		private const string PAGE_TO_IMAGE_API_KEY = "279f978873a18207";

		private const string PAGE_TO_IMAGE_SERVICE_BASE_URL = "http://api.page2images.com/directlink";

		private const int SCREEN_SIZE_WIDTH = 1280;
		private const int SCREEN_SIZE_HEIGHT = 1024;

		private const int THUMBNAIL_SIZE_WIDTH = 240;
		private const int THUMBNAIL_SIZE_HEIGHT = 180;

		private const int RENDERING_DELAY = 5;

		public string GenerateImageUrl(string domainUrl)
		{
			var imageUrl = $"{PAGE_TO_IMAGE_SERVICE_BASE_URL}?" +
			               $"p2i_url=http://{domainUrl}&" +
			               "p2i_device=6&" +
			               $"p2i_screen={SCREEN_SIZE_WIDTH}x{SCREEN_SIZE_HEIGHT}&" +
			               $"p2i_size={THUMBNAIL_SIZE_WIDTH}x{THUMBNAIL_SIZE_HEIGHT}&" +
			               $"p2i_wait={RENDERING_DELAY}&" +
			               $"p2i_key={PAGE_TO_IMAGE_API_KEY}";

			return imageUrl;
		}
	}
}