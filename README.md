# Gxs.Ecxpress
.Net FTP Bindings For Sending And Receiving EDI Messages With [GXS/OpenText Ecxpress](http://www.opentext.com/)

GXS Ecxpress only supports Active FTP, which means your network/firewalls need to be [correctly configured](http://fetchsoftworks.com/fetch/help/Contents/Concepts/ActiveAndPassive.html)
This project was an effort in trying to remove old legacy software and was mostly derived from reverse engineering production software using WireShark.

This library only sends and recieves EDI messages and doesn't support parsing/reading them.

```c#
public static void Main()
{
  using (var client = new EcxpressClient("{endpoint}", "{user}", "{password}"))
  {
    client.Connect();

    //Delete All Messages Older Than 30 Days
    client.DeleteBefore(DateTime.UtcNow.AddDays(-30));

    //Retrieve a list of all configured trading relationships
    var tradingRelationships = client.TradingRelationships();

    //Retrieve a list of all messages sent to partners
    var postbox = client.Postbox();

    //Retrieve a list of all messages to be recieved
    var mailbox = client.Mailbox();

    //Send a message to partner
    client.SendMessage("{partner gln}", "{your reference}", "EDIFACT/X12 Content");

    //Recieve a message sent from partner
    var response = client.GetMessage("{message-id}");
  }
}
```
