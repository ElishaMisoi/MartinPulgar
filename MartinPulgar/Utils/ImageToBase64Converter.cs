using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MartinPulgar.Utils
{
    public static class ImageToBase64Converter
    {
        public static async Task<string> ConvertToBase64String(string filePath)
        {
            string base64String = string.Empty;
            await Task.Run(() => 
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] ImageData = new byte[fs.Length];
                fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                base64String = Convert.ToBase64String(ImageData);
            });
            return await Task.FromResult(base64String);
        }
    }
}
