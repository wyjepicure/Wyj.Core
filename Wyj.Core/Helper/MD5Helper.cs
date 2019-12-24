using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wyj.Core.Helper
{
    public static class MD5Helper
    {
        public static string GetMd5String(this string content)
        {
            var contentBytes = Encoding.UTF8.GetBytes(content ); //指定编码方式
            var md5 = new MD5CryptoServiceProvider();
            return Convert.ToBase64String(md5.ComputeHash(contentBytes));
        }
    }
}
