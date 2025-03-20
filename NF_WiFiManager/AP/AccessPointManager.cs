namespace NF_WiFiManager.AP
{
    using System;
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Threading;

    public static class AccessPointManager
    {
        public static void SetupAccessPoint()
        {
            Debug.WriteLine("Setting up AP mode...");
            WirelessAPConfiguration apConfig = new WirelessAPConfiguration(0)
                                                   {
                                                       Options = WirelessAPConfiguration.ConfigurationOptions.Enable,
                                                       Ssid = "nF_Config",
                                                       Password = "password123",
                                                       Channel = 6,
                                                       MaxConnections = 4,
                                                       Authentication = AuthenticationType.WPA2,
                                                       Encryption = EncryptionType.WPA2,
                                                       Radio = RadioType._802_11g
                                                   };

            try
            {
                apConfig.SaveConfiguration();
                Debug.WriteLine("AP configuration saved successfully.");
                Thread.Sleep(3000);
                Debug.WriteLine("AP mode is now active.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving AP configuration: {ex.Message}");
            }
        }
    }
}