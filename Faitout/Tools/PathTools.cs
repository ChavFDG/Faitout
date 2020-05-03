using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faitout.Pages;
using Faitout.Data;

namespace Faitout.Tools
{
    public static class PathTools
    {
        public static string GetFilePath(this string fileName)
        {
            return "upload/" +fileName;

        }
    }
}
