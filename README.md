# Introduction
This project provides samples of ADO.net Azure SQL AuthN using username/password, secret based ADFS AAD token, and certificate based ADFS AAD token.

# Getting Started
1.	Installation process
    * Replace the 'ida:TenantId' app.config value with the Id of your Azure tenant.
    * An Azure SQL instance must be created, and the App.config connection strings must be updated. 
      For purposes of this sample using the sample Adventure Works database is just fine. 
      Mind the cost involved, and be sure to choose a Basic (5 DTU) database when you create.
      * Be sure to modify both of the connection strings. 
        * The first connection string, 'adventure-works' is the ActiveDirectoryPassword version. 
        * The second connection string, 'adventure-works-token' does not include the credentials as it relies on injection of an access token.
    * An Azure AD (AAD) application needs to be registered.
      * The registered application ClientId should replace the 'ida:ClientId' app.config value.
      * Create a secret in your registered application and replace the 'ida:ClientSecret' app.config value.
    * Lastly, in order to enable AuthN via certificate, create a code-signing certificate on the machine that will be running the 
      tests installed (with private key) in the certmgr.msc context of the user that will be running the tests.
       * By installing it in the correct context the private key can be used to sign client assertions for AAD/ADFS AuthN.
       * Replace the 'CertificateThumbprint" app.config value with the Thumbprint of the code signing certificate. Make sure you remove the hidden unicode character at the beginning, and spaces between the hex values.
       * Once installed on the test machine, run the following Powershell to acquire values that you'll need for the AAD application manifest:
        ```
        $cer = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
        $cer.Import(“c:\your.cer”)
        $bin = $cer.GetRawCertData()
        $base64Value = [System.Convert]::ToBase64String($bin)
        $bin = $cer.GetCertHash()
        $base64Thumbprint = [System.Convert]::ToBase64String($bin)
        $keyid = [System.Guid]::NewGuid().ToString()

        $base64Value
        $base64Thumbprint 
        $keyid
        ```
        * Now, in the Azure Portal AAD blade select the registered application and edit the manifest. You'll want to add a node to the keyCredentials section:
        ```
        "keyCredentials": [
            {
                "customKeyIdentifier": "<<$base64Thumbprint from above powershell>>",
                "keyId": "<<$keyid from above powershell>>",
                "type": "AsymmetricX509Cert",
                "usage": "Verify",
                "value": "<<$base64Value from above powershell>>"
            }
        ],

        ```

2.	Software dependencies
    * Building will restore Nuget packages.
3.	Latest releases
    * n/a
4.	API references
    * n/a

# Build and Test
Run all tests. That's it.
