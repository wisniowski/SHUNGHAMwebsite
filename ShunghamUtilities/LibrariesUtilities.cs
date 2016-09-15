using System;
using System.Linq;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;

namespace ShunghamUtilities
{
    public class LibrariesUtilities
    {
        public static string GetMediaUrlByImageId(Guid masterImageId, bool resolveAsAbsolutUrl)
        {
            var manager = LibrariesManager.GetManager();

            // Get the master version of the image
            var image = manager.GetImages().FirstOrDefault(i => i.Id == masterImageId);

            var mediaUlr = String.Empty;

            if (image != null)
            {
                // Resolve the media URL
                mediaUlr = image.ResolveMediaUrl(resolveAsAbsolutUrl);
            }

            return mediaUlr;
        }

        public static IQueryable<Image> GetImagesByAlbumNativeAPI(Guid albumId)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager();

            Album album = librariesManager.GetAlbum(albumId);
            IQueryable<Image> images = album.Images().Where(i => i.Status == ContentLifecycleStatus.Live);

            return images;
        }
    }
}
