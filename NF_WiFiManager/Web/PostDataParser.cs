namespace NF_WiFiManager.Web
{
    public static class PostDataParser
    {
        public static string GetValue(string postData, string key)
        {
            string[] pairs = postData.Split('&');
            foreach (string pair in pairs)
            {
                string[] kv = pair.Split('=');
                if (kv.Length == 2 && kv[0] == key)
                {
                    return UrlDecoder.Decode(kv[1]);
                }
            }

            return string.Empty;
        }
    }
}