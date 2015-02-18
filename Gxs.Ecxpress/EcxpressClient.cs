using EnterpriseDT.Net.Ftp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gxs.Ecxpress
{
    public class EcxpressClient : IDisposable
    {
        private readonly FTPClient _client;
        private readonly string _user;
        private readonly string _password;

        public EcxpressClient(string host, string user, string password)
        {
            _client = new FTPClient { RemoteHost = host };
            _user = user;
            _password = password;
        }

        public void Connect()
        {
            _client.Connect();
            _client.Login(_user, _password);
            _client.TransferType = FTPTransferType.ASCII;
            _client.ConnectMode = FTPConnectMode.ACTIVE;
        }

        public IList<MailboxItem> Mailbox()
        {
            return MailboxItem.Parse(_client.Dir("mb"));
        }

        public IList<PostboxItem> Postbox()
        {
            return PostboxItem.Parse(_client.Dir("pb"));
        }

        public IList<TradingRelationship> TradingRelationships()
        {
            return TradingRelationship.Parse(_client.Dir("tr"));
        }

        public string GetMessage(string messageId)
        {
            if (string.IsNullOrEmpty(messageId))
                throw new ArgumentException("messageId");

            var item = _client.Get(messageId);
            return Encoding.ASCII.GetString(item);
        }

        public void SendMessage(string partnerId, string messageId, string content)
        {
            var messageReference = string.Format("%{0}%*Null%{1}%E", partnerId, messageId);
            var encodedContent = Encoding.ASCII.GetBytes(content);
            _client.Put(encodedContent, messageReference);
        }

        public void DeleteBefore(DateTime date)
        {
            var format = date.ToString("yyyyMMdd");
            _client.Delete(string.Format("%BEFORE%{0}", format));
        }

        public void Disconnect()
        {
            if (_client.IsConnected)
                _client.Quit();
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
