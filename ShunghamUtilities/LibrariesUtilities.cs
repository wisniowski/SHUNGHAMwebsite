using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
