using Microsoft.Bot.Connector.DirectLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotClientSdk
{
    public class DirectLineWrapper
    {
        private string? _conversationId = null;
        private readonly DirectLineClient _client;
        Action<List<KeyValuePair<string, string>>> _updateMessages;

        public DirectLineWrapper(Action<List<KeyValuePair<string, string>>> updateMessages)
        {
            _client = new DirectLineClient("vXE4N_NUkjc.gSQr8VeUIFRmEfDg8cczc-TEkqtOlhXOHzxWek8-Qso");
            _updateMessages = updateMessages;
        }

        public async Task StartConversation()
        {
            if (string.IsNullOrWhiteSpace(_conversationId))
            {
                var conversation = await _client.Conversations.StartConversationAsync();
                _conversationId = conversation.ConversationId;                

                new System.Threading.Thread(async () => await ReadBotMessagesAsync(_client, conversation.ConversationId)).Start();
            }
        }

        public async Task SendMessage(string message)
        {            
            if (string.IsNullOrWhiteSpace(_conversationId))
            {
                throw new Exception("No active conversation");
            }

            Activity userMessage = new Activity
            {
                From = new ChannelAccount("User"),
                Text = message,
                Type = ActivityTypes.Message
            };

            var resourceResponse = await _client.Conversations.PostActivityAsync(_conversationId, userMessage);            
        }

        private object _lock = new object();

        // https://github.com/microsoft/BotBuilder-Samples/blob/v3-sdk-samples/CSharp
        private async Task ReadBotMessagesAsync(DirectLineClient client, string conversationId)
        {
            string watermark = string.Empty;
            var messages = new List<KeyValuePair<string, string>>();
            
            while (true)
            {
                var activitySet = await client.Conversations.GetActivitiesAsync(conversationId, watermark);

                lock (_lock)
                {
                    watermark = activitySet.Watermark;

                    var activities = from x in activitySet.Activities
                                     select x;

                    messages.Clear();
                    foreach (Activity activity in activities)
                    {
                        messages.Add(new KeyValuePair<string, string>(activity.From.Id, activity.Text));
                    }

                    _updateMessages(messages);
                }
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);                
            }
        }

    }
}
