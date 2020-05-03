using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Faitout.Data.Model
{
    public class UploadedFileInfo
    {
        public UploadedFileInfo()
        {

        }
        public UploadedFileInfo(string userFileName, string internalFileName,string fileType)
        {
            UserFileName = userFileName;
            InternalFileName = internalFileName;
            Type = fileType;
        }

        public string UserFileName { get; set; }

        public string InternalFileName { get; set; }

        public string Type { get; set; }

        public bool IsImage()
        {
            return Type.StartsWith("image");
        }
    }
}
