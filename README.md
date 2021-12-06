# QvaPay.Net - SDK for the QvaPay API 

Non official, QvaPay library for the Microsoft.Net framework, **only for version 1**.

### Setup

You can install this package by using Nuget:

```bash

```

### Sign up on **QvaPay**

Register your account to process payments through **QvaPay** at [qvapay.com/register](https://qvapay.com/register).

### Use
```dotnet 
    
	var config = new QvaPayConfig()
    {
        apiversion = "v1",
        appid = "Your App Id",
        appsecret = "Your App Secret",
    };

    Instantiate the object.
    IQvaPayInstance qva = new QvaPayInstance(config);

    var result = await qva.AppInfo();

    var inv = new Invoice()
    {
        amount = new decimal(0.01),
        description = "Test product",
        remote_id = Guid.NewGuid().ToString(),
        signed = true
    };
    var result = await qva.Invoice(inv);

    var result = await qva.Transactions();

    string uuid = "Your transaction id"
    var result = await qva.GetTransaction(uuid);

    decimal balance = await qva.Balance();

```