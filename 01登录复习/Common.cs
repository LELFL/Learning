using System;
using System.Collections.Generic;
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
                byte[] byte1 = md5.ComputeHash(bytes);
            }
        }
    }
}
