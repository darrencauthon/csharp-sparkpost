# C# Library for [SparkPost](https://www.sparkpost.com)

[![Travis CI](https://travis-ci.org/darrencauthon/csharp-sparkpost.svg?branch=master)](https://travis-ci.org/SparkPost/csharp-sparkpost)

A C# package for the [SparkPost API](https://developers.sparkpost.com/api). Xamarin.iOS and Xamarin.Android support provided in the Portable Package (PCL Profile7).

## Installation

To install via NuGet, run the following command in the [Package Manager Console](http://docs.nuget.org/consume/package-manager-console):

```
PM> Install-Package SparkPost
```

Alternatively, you can get the latest dll from the releases tab.  You can also download this code and compile it yourself.

## Usage

#### Special Note about ```Async```

By default, this library uses .Net 4.5's ```Async``` functionality for better performance  ([read more here](https://msdn.microsoft.com/en-us/library/hh191443.aspx)).  This requires knowledge and execution
of the async/await behavior in C#.  If you're noticing what seems to be weird behavior, or MVC action hangs,
or anything of that nature, just switch your client to ```Sync``` and you'll get the expected (but blocking) behavior.

```c#
client.CustomSettings.SendingMode = SendingModes.Sync;
client.Transmissions.Send(transmission); // now this call will be made synchronously

client.CustomSettings.SendingMode = SendingModes.Async;
client.Transmissions.Send(transmission); // now this call will be made asynchronously
```



### Transmissions

To send an email:

```c#
var transmission = new Transmission();
transmission.Content.From.Email = "testing@sparkpostbox.com";
transmission.Content.Subject = "Oh hey!";
transmission.Content.Text = "Testing SparkPost - the world\'s most awesomest email service!";
transmission.Content.Html = "<html><body><p>Testing SparkPost - the world\'s most awesomest email service!</p></body></html>";

var recipient = new Recipient
{
    Address = new Address { Email = "my@email.com" }
};
transmission.Recipients.Add(recipient);

var client = new Client("<YOUR API KEY>");
client.Transmissions.Send(transmission);
// or client.Transmissions.Send(transmission).Wait();

```

To send a template email:

```c#
var transmission = new Transmission();
transmission.Content.TemplateId = "my-template-id";
transmission.Content.From.Email = "testing@sparkpostbox.com";

transmission.SubstitutionData["first_name"] = "John";
transmission.SubstitutionData["last_name"] = "Doe";

var orders = new List<Order>
{
    new Order { OrderId = "1", Total = 101 },
    new Order { OrderId = "2", Total = 304 }
};

// you can pass more complicated data, so long as it
// can be parsed easily to JSON
transmission.SubstitutionData["orders"] = orders;

var recipient = new Recipient
{
    Address = new Address { Email = "my@email.com" }
};
transmission.Recipients.Add(recipient);

var client = new Client("MY_API_KEY");
client.Transmissions.Send(transmission);
// or client.Transmissions.Send(transmission).Wait();

```

### Sub Accounts

You can use the client to send emails through a sub account by passing the ```subAccountId``` to your client.

```c#
client = new Client(YOUR_API_KEY, YOUR_SUB_ACCOUNT_ID);
// now the emails will be processed through your sub account
```

### Suppression List

The suppression list are users who have opted-out of your emails.  To retrieve this list:

```c#
var client = new Client("MY_API_KEY");

client.Suppressions.List(); // returns a list of

client.Suppressions.List(new { limit = 3 }); // it accepts an anonymous type for filters

client.Suppressions.List(new SuppressionQuery()); // a SuppressionQuery is also allowed for typed help
```

To add email addresses to the list:

```c#
var client = new Client("MY_API_KEY");

var item1 = new Suppression { Email = "testing@testing.com", NonTransactional = true };
var item2 = new Suppression { Email = "testing2@testing.com", Description = "testing" };

client.Suppressions.CreateOrUpdate(new []{ item1, item2 });
```

To delete email addresses from the list:

```c#
var client = new Client("MY_API_KEY");

client.Suppressions.Delete("testing@testing.com");
```

To retrieve details about an email address on (or not on) the list:

```c#
var client = new Client("MY_API_KEY");

client.Suppressions.Retrieve("testing@testing.com");
```


### Contribute

We welcome your contributions!  See [CONTRIBUTING.md](CONTRIBUTING.md) for details on how to help out.

### Change Log

[See ChangeLog here](CHANGELOG.md)
