namespace NF_WiFiManager.Web
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;

    using NF_WiFiManager.WiFi;

    public static class WebServer
    {
        private static HttpListener _listener;

        public static void Start()
        {
            Debug.WriteLine("Start WebServer");
            string urlPrefix = "http://*:80/";
            _listener = new HttpListener(urlPrefix);

            try
            {
                _listener.Start();
                Debug.WriteLine("The WebServer is started and listening for requests.");
                Thread serverThread = new Thread(ServerLoop);
                serverThread.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting the WebServer: {ex.Message}");
            }
        }

        private static void ServerLoop()
        {
            while (true)
            {
                try
                {
                    HttpListenerContext context = _listener.GetContext();
                    ProcessRequest(context);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing request: {ex.Message}");
                }
            }
        }

        private static void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            Debug.WriteLine("Request received: " + request.RawUrl);

            if (request.HttpMethod == "GET")
            {
                string html = HtmlTemplates.ConfigurationForm;
                byte[] buffer = Encoding.UTF8.GetBytes(html);
                response.ContentType = "text/html";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else if (request.HttpMethod == "POST" && request.RawUrl == "/configure")
            {
                string postData;
                using (StreamReader reader = new StreamReader(request.InputStream))
                {
                    postData = reader.ReadToEnd();
                }
                Debug.WriteLine("Data received: " + postData);
                string ssid = PostDataParser.GetValue(postData, "ssid");
                string password = PostDataParser.GetValue(postData, "password");
                Debug.WriteLine($"New data - SSID: {ssid}, Password: {password}");

                bool success = WiFiConfigurationManager.SaveConfiguration(ssid, password);

                string responseHtml = success ? HtmlTemplates.SuccessPage : HtmlTemplates.ErrorPage;
                byte[] responseBuffer = Encoding.UTF8.GetBytes(responseHtml);
                response.ContentType = "text/html";
                response.ContentLength64 = responseBuffer.Length;
                response.OutputStream.Write(responseBuffer, 0, responseBuffer.Length);

                if (success)
                {
                    Debug.WriteLine("Configuration saved successfully. Rebooting device...");
                    Thread.Sleep(3000);
                    nanoFramework.Runtime.Native.Power.RebootDevice();
                }
            }
            else
            {
                response.StatusCode = 405;
            }

            response.OutputStream.Close();
        }
    }
}