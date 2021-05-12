using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MartinPulgar.Services.Media
{
    public static class MediaService
    {
        public static async Task<string> PickPhotoAsync()
        {
            string filePath = null;
            // Must run on MainThread for Xamarin.Essentials to handle permissions request
           await MainThread.InvokeOnMainThreadAsync(async () => 
           {
               try
               {
                   var photo = await MediaPicker.PickPhotoAsync();
                   string photoPath = await LoadPhotoAsync(photo);

                   if (photoPath != null)
                       filePath = photoPath;
                   // if null, operation was cancelled
               }
               catch (PermissionException)
               {
                   throw new Exception("Permission was not granted. Please grant the app permission to access your photos.");
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.Message);
               }
           });

            return await Task.FromResult(filePath);
        }

        private static async Task<string> LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                return null;
            }

            // save the file into local storage
            var filePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(filePath))
                await stream.CopyToAsync(newStream);

            return filePath;
        }
    }
}
