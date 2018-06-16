using System;
using System.IO;
using System.Web;

namespace GMS.Helpers
{
    public static class FileHelper
    {
        public static string Save(string folder, HttpPostedFileBase file)
        {
            var extension = Path.GetExtension(file.FileName);
            string fileName = Guid.NewGuid().ToString() + extension;

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
                
            var path = Path.Combine(folder, fileName);
            file.SaveAs(path);

            return fileName;
        }
    }
}
