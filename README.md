# NF_WiFiManager

## Contents
- [Project Overview](#project-overview)
- [Key Features](#key-features)
- [Installation Instructions](#installation-instructions)
  - [Prerequisites](#prerequisites)
  - [Installation Steps](#installation-steps)
- [Usage Examples](#usage-examples)
  - [Initial Configuration](#initial-configuration)
  - [Reconfiguring Wi-Fi](#reconfiguring-wi-fi)
  - [Integration with Your Application](#integration-with-your-application)
- [API Reference](#api-reference)
  - [WiFiConnectionManager](#wificonnectionmanager)
  - [WiFiConfigurationManager](#wificonfigurationmanager)
  - [AccessPointManager](#accesspointmanager)
  - [WebServer](#webserver)
  - [HtmlTemplates](#htmltemplates)
  - [PostDataParser](#postdataparser)
- [Customization](#customization)
- [License](#license)

## Project Overview

**NF_WiFiManager** is a robust web-based Wi-Fi configuration manager designed for ESP32 devices running .NET nanoFramework. It allows dynamic and secure configuration of Wi-Fi settings through a built-in web portal, eliminating the need for hardcoded network credentials. If the device fails to connect to previously saved credentials, it automatically transitions into Access Point (AP) mode for easy configuration.

## Key Features

- **Automatic Wi-Fi Connection:** Tries to reconnect to known networks, and automatically falls back to AP mode if unsuccessful.
- **Web-based Configuration Portal:** Easy-to-use built-in web server accessible via any standard browser.
- **Persistent Storage:** Securely saves Wi-Fi credentials across device reboots.
- **WPA2 Security:** The configuration portal AP is secured by WPA2 encryption.
- **Lightweight Implementation:** Minimal resource usage tailored for .NET nanoFramework and ESP32.

## Installation Instructions

### Prerequisites
- ESP32 board with the latest nanoFramework firmware installed.
- Visual Studio 2019/2022 with nanoFramework extension installed.

### Installation Steps

1. **Clone the repository**
```bash
git clone https://github.com/unrealbg/NF_WiFiManager.git
```

2. **Open and Build**
- Open `NF_WiFiManager.sln` in Visual Studio.
- Ensure NuGet packages are restored, including:
  - `nanoFramework.System.Device.Wifi`
  - `nanoFramework.Networking`
  - `nanoFramework.Runtime.Native`
- Build the solution.

3. **Deploy**
- Deploy the solution to your ESP32 device via the Visual Studio nanoFramework extension.

## Usage Examples

### Initial Configuration

1. Flash and reboot the device.
2. The device enters AP mode, broadcasting `nF_Config` (default password `password123`).
3. Connect your device (smartphone/laptop) to the AP network.
4. Navigate to `http://192.168.4.1/` in a web browser.
5. Fill out the Wi-Fi SSID and password fields, then submit.
6. The device saves the credentials and reboots automatically to connect to your network.

### Reconfiguring Wi-Fi

- Turn off the previously configured Wi-Fi network or force AP mode programmatically.
- Follow the same steps as the initial configuration to update Wi-Fi credentials.

### Integration with Your Application

Below is an example of integrating NF_WiFiManager into your application's startup logic:

```csharp
using NF_WiFiManager.AP;
using NF_WiFiManager.WiFi;
using NF_WiFiManager.Web;

bool connected = WiFiConnectionManager.TryConnect(60000);

if (!connected)
{
    AccessPointManager.SetupAccessPoint();
    WebServer.Start();
}
```

## API Reference

### WiFiConnectionManager
- `TryConnect(int timeoutMilliseconds)`: Attempts to connect to stored Wi-Fi within a given timeout period.

### WiFiConfigurationManager
- `SaveConfiguration(string ssid, string password)`: Saves new Wi-Fi network credentials.

### AccessPointManager
- `SetupAccessPoint()`: Initializes and starts the device in AP mode for configuration.

### WebServer
- `Start()`: Launches the built-in web server and configuration portal.

### HtmlTemplates
- Provides HTML pages for Wi-Fi configuration, success messages, and error messages.

### PostDataParser
- Parses URL-encoded form submissions for the web server.

## Customization

Modify AP settings (SSID/password) and other parameters by editing `AccessPointManager.cs` before deployment.

## License

NF_WiFiManager is released under the **MIT License**. For more information, see the [LICENSE.txt](LICENSE.txt) file included in the repository.

---

Feel free to contribute, suggest features, or report issues through GitHub!

