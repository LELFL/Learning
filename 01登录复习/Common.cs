using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _01登录复习
{
    public static class Common
    {
        public static string StrToMd5(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            using (MD5 md5 = MD5.Create())
            {
                bytes  = md5.ComputeHash(bytes);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string FileToMd5(string path)
        {
            byte[] bytes;
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    bytes = md5.ComputeHash(fs);
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
