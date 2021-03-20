using Microsoft.AspNetCore.Http;

namespace Core.Helpers
{
    public static class VideoValidator
    {
        public static bool IsMp4(this IFormFile file)
        {
            try
            {
                if (file.ContentType.IndexOf("mp4") > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
