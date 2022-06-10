using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HeyatdanBezmek.Utilites
{
    public static class Ex
    {
        public static bool CheckSize( this IFormFile file , int kb)
        {
            if (file.Length/1024>kb)
            {
                return true;

            }
            return false;
        }
        public static bool CheckType(this IFormFile file,string typee)
        {
            if (file.ContentType.Contains("image/"))
            {
                return true;


            }
            return false;

        }
        public static async Task<string> SaveFileAsync( this IFormFile formFile, string pathh)
        {
            string Musi= Guid.NewGuid().ToString()+formFile.FileName;   
            string path= Path.Combine(pathh, Musi);
            using(FileStream stream= new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
            return Musi;
        }
    }
}
