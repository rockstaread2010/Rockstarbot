using System;
using System.Threading.Tasks;
using RockBot.Twitch;
namespace RockBot.Twitch{
class TwitchBot{
    CommandHandler ch = new CommandHandler();
    public void TwitchBotMain(){
        Console.WriteLine("Fucking Shit Up? 1");
        //Twitch Bot Code Should Start here

        //Temp Class to see How things work :)
        ch.CommandHandlerMain();


        Thread.Sleep(1000);
        Console.WriteLine("Fucking Shit Up 3");

    }
}
}