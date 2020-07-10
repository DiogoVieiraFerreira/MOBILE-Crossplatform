using System;

namespace mobile.Resources
{
    public class API
    {
        public static string Ip = "192.168.1.103";
        public static string url = string.Format(@"http://{0}/", Ip);
        public static Uri uri = new Uri(url);
    }
}
