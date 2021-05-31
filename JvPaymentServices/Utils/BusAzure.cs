using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.EnumResourse;

namespace Utils
{
    public class BusAzure
    {

        private string _connectionString;
        private string _queueName;
        private ServiceBusClient client;

        public BusAzure(string connectionString, EnumBusQueu queu)
        {
            _queueName = Enum.GetName(typeof(EnumBusQueu), queu);
            client = new ServiceBusClient(connectionString);
        }

        public async Task setBusAsync(string message) 
        {
            // The sender is responsible for publishing messages to the queue.
            ServiceBusSender sender = client.CreateSender(_queueName);
            ServiceBusMessage messageObj = new ServiceBusMessage(message);
            await sender.SendMessageAsync(messageObj);
        }

        public async Task<string> GetBusAsync()
        {
            ServiceBusReceiver receiver = client.CreateReceiver(_queueName);
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            await receiver.CompleteMessageAsync(receivedMessage);
            return receivedMessage.Body.ToString();
        }

    }
}
