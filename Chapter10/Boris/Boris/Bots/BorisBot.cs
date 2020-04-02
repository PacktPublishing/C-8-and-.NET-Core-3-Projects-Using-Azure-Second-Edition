// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;

namespace Boris.Bots
{
    public class BorisBot : ActivityHandler
    {
        private readonly IConfiguration _configuration;
        private Random _rnd = new Random();

        public BorisBot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var luisApplication = new LuisApplication(
                            _configuration["LuisAppId"],
                            _configuration["LuisAPIKey"],
                            _configuration["LuisAPIHostName"]
                        );

            var recognizer = new LuisRecognizer(luisApplication);

            var recognizerResult = await recognizer.RecognizeAsync(turnContext, cancellationToken);

            var (intent, score) = recognizerResult.GetTopScoringIntent();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Boris.Data.Intent-Response.json";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            var response = ReadResponse(result, intent);

            string selectedResponse = response[_rnd.Next(response.Length)];
            await turnContext.SendActivityAsync(MessageFactory.Text(selectedResponse), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and Welcome!"), cancellationToken);
                }
            }
        }

        public static string[] ReadResponse(string jsonString, string key)
        {
            using var document = JsonDocument.Parse(jsonString);

            var root = document.RootElement;            
            var possibleResponses = root.GetProperty(key);

            return possibleResponses.EnumerateArray().Select(a => a.GetString()).ToArray();
        }
    }
}
