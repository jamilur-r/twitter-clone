using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.IO;


namespace API.Utility
{
    public class Utils
    {
        public async Task<string> Upload(IFormFile file, IWebHostEnvironment env)
        {
            try
            {
                var fileName = Path.GetFileName(file.FileName);
                var saveName = "Upload/" + Guid.NewGuid().ToString() + "_" + fileName;
                var serverPath = Path.Combine(env.WebRootPath, saveName);
                await file.CopyToAsync(new FileStream(serverPath, FileMode.Create));
                return saveName;
            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}