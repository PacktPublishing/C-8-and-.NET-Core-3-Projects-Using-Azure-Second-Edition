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
        private string? _watermark = null;

        public DirectLineWrapper()
        {
            _client = new DirectLineClient("X14UCaCQoP8.QNPYS_u2Z7LhobFce9mA2ZWt47n7VzEuTjTGWHO-oL0");
        }

        public async Task<List<KeyValuePair<string, string>>> SendMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(_conversationId))
            {
                var conversation = await _client.Conversations.StartConversationAsync();
                _conversationId = conversation.ConversationId;
            }
            
            Activity userMessage = new Activity
            {
                From = new ChannelAccount("User"),
                Text = message,
                Type = ActivityTypes.Message
            };

            var resourceResponse = await _client.Conversations.PostActivityAsync(_conversationId, userMessage);
            return await ReadBotMessagesAsync(_client, _conversationId);
        }


        // https://github.com/microsoft/BotBuilder-Samples/blob/v3-sdk-samples/CSharp
        private async Task<List<KeyValuePair<string, string>>> ReadBotMessagesAsync(DirectLineClient client, string conversationId)
        {
            
            var messages = new List<KeyValuePair<string, string>>();

            while (true)
            {
                var activitySet = await client.Conversations.GetActivitiesAsync(conversationId, _watermark);
                if (activitySet == null) return new List<KeyValuePair<string, string>>();

                _watermark = activitySet.Watermark;

                var activities = activitySet.Activities.Where(a => a.Conversation.Id == conversationId);

                foreach (Activity activity in activities)
                {
                    messages.Add(new KeyValuePair<string, string>(activity.From.Id, activity.Text));
                }

                return messages;
            }
        }
    }
}
