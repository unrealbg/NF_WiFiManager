namespace NF_WiFiManager.WiFi
{
    using System;
    using System.Diagnostics;
    using System.Net.NetworkInformation;

    using nanoFramework.Networking;

    public static class WiFiConfigurationManager
    {
        public static bool SaveConfiguration(string ssid, string password)
        {
            try
            {
                WifiNetworkHelper.Disconnect();
                Wireless80211Configuration wifiConfig = new Wireless80211Configuration(0)
                                                            {
                                                                Ssid = ssid,
                                                                Password = password,
                                                                Authentication = AuthenticationType.WPA2,
                                                                Encryption = EncryptionType.WPA2
                                                            };
                wifiConfig.SaveConfiguration();
                Debug.WriteLine("WiFi configuration saved successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving WiFi configuration: {ex.Message}");
                return false;
            }
        }
    }
}