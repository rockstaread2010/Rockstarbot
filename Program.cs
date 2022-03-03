using RockBot.Twitch;
using RockBot.Discord;
namespace RockBot{
    class RockBot {
        static void Main(string[] args){
            // Twitch Bot Thread
            TwitchBot twitchBot = new TwitchBot();
            Thread twitchThread = new Thread(new ThreadStart(twitchBot.TwitchBotMain));
            twitchThread.Start();

            // Discord Bot Thread
            DiscordBot discordBot = new DiscordBot();
            Thread discordThread = new Thread(new ThreadStart(discordBot.DiscordBotMain));
            discordThread.Start();

            //Infinate Loop Here

            while (true){
            String? cmd = Console.ReadLine();
            if(String.IsNullOrEmpty(cmd)){}
            else{
            if(cmd.Contains("/exit")){
                //
            }
            }
            }
        }
    }
}
