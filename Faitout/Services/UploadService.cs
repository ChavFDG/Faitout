using Faitout.Data;
using Faitout.Data.Model;
using MatBlazor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Faitout.Services
{
    public class UploadService
    {
        private readonly IWebHostEnvironment _env;

        public UploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public Result Remove(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_env.WebRootPath, "upload", fileName);
                File.Delete(filePath);
                return new Result();
            }
            catch(Exception e)
            {
                return new Result("Impossible de supprimer " + fileName + ". " + e.Message);
            }
        }

        public async Task<UploadedFileInfo> WriteFile(IMatFileUploadEntry file)
        {
            try
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    await file.WriteToStreamAsync(stream);

                    stream.Seek(0, System.IO.SeekOrigin.Begin);

                    var fileName = System.IO.Path.ChangeExtension(System.IO.Path.GetRandomFileName(), System.IO.Path.GetExtension(file.Name));
                    var filePath = System.IO.Path.Combine(_env.WebRootPath, "upload", fileName);


                    using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                    {
                        stream.WriteTo(fs);
                    }
                    return new UploadedFileInfo(file.Name, fileName, file.Type);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur lors de l'écriture du fichier", e);
            }
        }
    }
}
