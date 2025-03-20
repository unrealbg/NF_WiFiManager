namespace NF_WiFiManager.Web
{
    using System.Text;

    public static class UrlDecoder
    {
        public static string Decode(string url)
        {
            if (string.IsNullOrEmpty(url))
                return url;

            string result = ReplaceString(url, "+", " ");
            result = ReplaceString(result, "%20", " ");
            result = ReplaceString(result, "%21", "!");
            result = ReplaceString(result, "%22", "\"");
            result = ReplaceString(result, "%23", "#");
            result = ReplaceString(result, "%24", "$");
            result = ReplaceString(result, "%25", "%");
            result = ReplaceString(result, "%26", "&");
            result = ReplaceString(result, "%27", "'");
            result = ReplaceString(result, "%28", "(");
            result = ReplaceString(result, "%29", ")");
            result = ReplaceString(result, "%2A", "*");
            result = ReplaceString(result, "%2B", "+");
            result = ReplaceString(result, "%2C", ",");
            result = ReplaceString(result, "%2D", "-");
            result = ReplaceString(result, "%2E", ".");
            result = ReplaceString(result, "%2F", "/");

            return result;
        }

        private static string ReplaceString(string original, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(oldValue))
                return original;

            int pos = 0;
            int index = original.IndexOf(oldValue, pos);
            if (index == -1)
                return original;

            StringBuilder result = new StringBuilder();
            while (index != -1)
            {
                result.Append(original.Substring(pos, index - pos));
                result.Append(newValue);
                pos = index + oldValue.Length;
                index = original.IndexOf(oldValue, pos);
            }

            result.Append(original.Substring(pos));
            return result.ToString();
        }
    }
}