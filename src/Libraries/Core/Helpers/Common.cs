using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace Core.Helpers
{
    public class Common
    {

        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }
        public static string UploadImage(IFormFile file, string uploadsFolder = "images", bool isThumb = false)
        {
            string uniqueFileName = null;
            try
            {
                if (file.FileName != null)
                {
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string thumbnails = Path.Combine("wwwroot\\" + uploadsFolder + "\\thumbnails", uniqueFileName);
                    string fullImages = Path.Combine("wwwroot\\images", uniqueFileName);
                    if (isThumb)
                    {
                        using (var fileStream = file.OpenReadStream())
                        {
                            using (var image = Image.Load(fileStream))
                            {
                                image.Mutate(x => x.Resize(200, 100));
                                image.Save(thumbnails);
                            }

                        }
                    }

                    using (var fileStream = file.OpenReadStream())
                    {
                        using (var full_image = Image.Load(fileStream))
                        {
                            full_image.Save(fullImages);
                        }
                    }
                }
                return uniqueFileName;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
