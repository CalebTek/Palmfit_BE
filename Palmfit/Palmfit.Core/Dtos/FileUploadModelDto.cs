using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Dtos
{
    public class FileUploadModelDto
    {
        public string? ImageName { get; set; }
        public byte[]? ImageData { get; set; }
        public string CloudinaryPublicId { get; set; } = string.Empty;
        public string CloudinaryUrl { get; set; } = string.Empty;
    }
}
