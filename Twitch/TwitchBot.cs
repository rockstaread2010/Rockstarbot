using System;
using System.Threading.Tasks;
using RockBot.Twitch;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace RockBot.Twitch{
class TwitchBot{
    CommandHandler ch = new CommandHandler();

    static TwitchClient twitchClient = new TwitchClient();
    public void TwitchBotMain(){
        
        ConnectionCredentials credentials = new ConnectionCredentials("twitch_username", "access_token");
	    var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 500,
                    ThrottlingPeriod = TimeSpan.FromSeconds(60)
                };
            WebSocketClient twitchWSClient = new WebSocketClient(clientOptions);
            twitchClient = new TwitchClient(twitchWSClient);
            twitchClient.Initialize(credentials, "channel");
        
            twitchClient.OnLog += Client_OnLog;
            twitchClient.OnJoinedChannel += Client_OnJoinedChannel;
            twitchClient.OnMessageReceived += Client_OnMessageReceived;
            //twitchClient.OnWhisperReceived += Client_OnWhisperReceived;
            //twitchClient.OnNewSubscriber += Client_OnNewSubscriber;
            twitchClient.OnConnected += Client_OnConnected;

            twitchClient.Connect();
    }

    private void Client_OnLog(object sender, OnLogArgs e)
        {
            twitchConsoleWrite($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}", ConsoleColor.Red);
        }
  
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }
  
        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Hey guys! I am a bot connected via TwitchLib!");
            twitchClient.SendMessage(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.Contains("badword"))
                twitchClient.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        }

    public static void twitchConsoleWrite(String message, ConsoleColor consoleColor = ConsoleColor.Black){
        Console.ForegroundColor = consoleColor;
        Console.WriteLine($"{DateTime.UtcNow.ToString()}: <Twitch> ${message}");
        Console.ForegroundColor = ConsoleColor.Black;
    }
}
}