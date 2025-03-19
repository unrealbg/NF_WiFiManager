namespace NF_WiFiManager.Web
{
    public static class HtmlTemplates
    {
        public static string ConfigurationForm => @"
<html>
  <head>
    <title>WiFi configuration</title>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <style>
      body { font-family: Arial, sans-serif; margin: 20px; }
      input { width: 100%; padding: 8px; margin: 10px 0; }
      input[type='submit'] { background-color: #4CAF50; color: white; cursor: pointer; }
    </style>
  </head>
  <body>
    <h1>WiFi configuration </h1>
    <form method='POST' action='/configure'>
      <label for='ssid'>SSID:</label><br/>
      <input type='text' id='ssid' name='ssid' required /><br/>
      <label for='password'>Password:</label><br/>
      <input type='password' id='password' name='password' required /><br/>
      <input type='submit' value='Save and connect' />
    </form>
  </body>
</html>";

        public static string SuccessPage => @"
<html>
  <head>
    <title>WiFi configuration</title>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <style>
      body { font-family: Arial, sans-serif; margin: 20px; }
      .success { color: green; }
    </style>
  </head>
  <body>
    <h1 class='success'>Configuration saved successfully</h1>
    <p>The device will restart to apply the new configuration.</p>
  </body>
</html>";

        public static string ErrorPage => @"
<html>
  <head>
    <title>WiFi configuration</title>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <style>
      body { font-family: Arial, sans-serif; margin: 20px; }
      .error { color: red; }
    </style>
  </head>
  <body>
    <h1 class='error'>Error saving configuration</h1>
    <p>Please try again.</p>
    <a href='/'>Back to configuration</a>
  </body>
</html>";
    }
}