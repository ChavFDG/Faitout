using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Faitout.Data.Model
{
    public class UploadedFileInfo
    {
        private static readonly string[] _validExtensions = { ".jpg", ".bmp", ".gif", ".png" }; //  etc

        public static bool IsImage(string fileName)
        {
            return _validExtensions.Contains(Path.GetExtension(fileName).ToLower());
        }

        public UploadedFileInfo()
        {

        }
        public UploadedFileInfo(string internalFileName)
        {
            OriginalFile = true;
            if (IsImage(internalFileName))
                Type = "image\\"+ Path.GetExtension(internalFileName);
            InternalFileName = internalFileName;
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

        public bool Show { get; set; } = true;

        public bool OriginalFile { get; set; } = false;


    }

    public static class UploadHelper
    {

        public static List<string> ToStringList(this List<UploadedFileInfo> files)
        {
            List<string> toReturn = new List<string>();
            files.Where(x=>x.Show).ToList().ForEach(x => toReturn.Add(x.InternalFileName));
            return toReturn;
        }
    }
}
