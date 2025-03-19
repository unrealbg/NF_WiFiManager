namespace NF_WiFiManager
{
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Threading;

    using nanoFramework.Networking;

    using NF_WiFiManager.AP;
    using NF_WiFiManager.Web;
    using NF_WiFiManager.WiFi;

    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Starting WiFiManager...");
            bool wifiConnected = WiFiConnectionManager.TryConnect(60000);
            if (wifiConnected)
            {
                Debug.WriteLine("WiFi connected successfully.");
                NetworkInterface ni = NetworkInterface.GetAllNetworkInterfaces()[0];
                Debug.WriteLine($"IP address: {ni.IPv4Address}");
                Thread.Sleep(Timeout.Infinite);
            }
            else
            {
                Debug.WriteLine("WiFi connection failed.");
                if (WifiNetworkHelper.HelperException != null)
                {
                    Debug.WriteLine($"Error: {WifiNetworkHelper.HelperException.Message}");
                }

                AccessPointManager.SetupAccessPoint();
                WebServer.Start();
            }
        }
    }
}
