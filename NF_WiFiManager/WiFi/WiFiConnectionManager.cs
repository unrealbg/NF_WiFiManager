namespace NF_WiFiManager.WiFi
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    using nanoFramework.Networking;

    public static class WiFiConnectionManager
    {
        public static bool TryConnect(int timeoutMilliseconds)
        {
            using (CancellationTokenSource cs = new CancellationTokenSource(timeoutMilliseconds))
            {
                try
                {
                    bool connected = WifiNetworkHelper.Reconnect(requiresDateTime: true, token: cs.Token);
                    return connected;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error connecting to WiFi: {ex.Message}");
                    return false;
                }
            }
        }
    }
}