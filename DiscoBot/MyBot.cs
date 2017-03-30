using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Discord;
using Discord.Commands;

namespace DiscoBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] randomBob;


        public MyBot()
        {

            rand = new Random();

            randomBob = new string[]
            {
                "bob/bob1.jpg",
                "bob/bob2.jpg",
                "bob/bob3.jpg",
                "bob/bob4.jpg",
                "bob/bob5.jpg",
                "bob/bob6.jpg",
                "bob/bob7.jpg"
            };


            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            
            commands = discord.GetService<CommandService>();

            RegisterBobCommand();
            RegisterVoetbalCommand();
            RegisterMaxCommand();
            RegisterhahaCommand();


            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Mjk2NjE2MDQxNDUzMTkxMTcw.C71Nlw.Mpl7EKEaWFg2pIX5ke9qcHsj8oo", TokenType.Bot);
            });
        }

        private void RegisterVoetbalCommand()
        {
            commands.CreateCommand("feyenoord")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Feyenoord kampioen!");
                });
        }

        private void RegisterhahaCommand()
        {
            commands.CreateCommand("haHAA")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("HaHAA");
                    
                });
        }

        private void RegisterBobCommand()
        {
            commands.CreateCommand("bob")
                .Do(async (e) =>
                {
                    int randomBobIndex = rand.Next(randomBob.Length);
                    string bobToPost = randomBob[randomBobIndex];
                    await e.Channel.SendFile(bobToPost);
                });
        }

        private void RegisterMaxCommand()
        {
            commands.CreateCommand("max")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("HAHAHAHA Nee");
                    await e.Channel.SendMessage("Geen gekke max foto maar ook gewoon een foto van bob");
                    int randomBobIndex = rand.Next(randomBob.Length);
                    string bobToPost = randomBob[randomBobIndex];
                    await e.Channel.SendFile(bobToPost);
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
