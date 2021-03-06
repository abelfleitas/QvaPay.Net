# QvaPay.Net - SDK for the QvaPay API 

Non official, QvaPay library for the Microsoft.Net framework, **only for version 1**.

### Setup

You can install this package by using Nuget:

```bash
Install-Package QvaPay.Net -Version 1.0.0
```

### Sign up on **QvaPay**

Register your account to process payments through **QvaPay** at [qvapay.com/register](https://qvapay.com/register).

### Usage
```C# 
    
    //Configure the QvaPay object
    var config = new QvaPayConfig() 
    {
        apiversion = "v1",
        appid = "Your App Id",
        appsecret = "Your App Secret",
    };

    //Instantiate the object.
    IQvaPayInstance qva = new QvaPayInstance(config);

    //Get your application information.
    var result = await qva.AppInfo();

    //Create an invoice
    Params
    # amount //Amount of money to receive (in dollars and with 2 decimal places)
    # description //Description of the invoice to be generated, useful to provide
    //information to the payer. (No more than 300 characters)
    # remote_id //Invoice ID in remote system (not required)
    # signed //Generation of a signed URL or not (signed URLs expire after 30 minutes,
    //providing more security or expiration)
    var inv = new Invoice()
    {
        amount = new decimal(0.01),
        description = "Test product",
        remote_id = Guid.NewGuid().ToString(),
        signed = true 
    };
    var result = await qva.Invoice(inv);

    //List transactions
    var result = await qva.Transactions();


    //Get a particular transaction
    string uuid = "Your transaction id"
    var result = await qva.GetTransaction(uuid);

    //Get your account balance
    decimal balance = await qva.Balance();

```
## Note

```
Once the payment of your transaction is confirmed, 
QvaPay will notify the status through a webhook in your APP.
It is done in GET format and has implicit as parameters,
the remote_id defined at the time of the invoice generation
and the QvaPay internal invoice id.
It is recommended to place in the webhook address to be used,
a keyword or unique token to avoid false calls to your endpoint.
```