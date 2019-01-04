using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
using NetTelegramBotApi.Util;

namespace Gamealon
{
    class Program
    {
        public class Users
        {
            private string Name;
            private long UserID;
            public int Score;
            public string ComputerGuess = "0";
            public byte Counter;
            public Users(string Name, long UserID, int Score)
            {
                this.Name = Name;
                this.UserID = UserID;
                this.Score = Score;
                this.Counter = 5;
            }
        }
        private static string RandomGenerator(ref string RandomG)
        {
            Random Generator = new Random();
            string[] CmNumber = new string[4];
            byte Counter = 0;
            do
            {
                Counter = 0;
                //CmNumber[0] = null;
                //CmNumber[1] = null;
                //CmNumber[2] = null;
                //CmNumber[3] = null;
                foreach (var item in CmNumber)
                {
                    CmNumber[Counter] = Convert.ToString(Generator.Next(1, 9));
                    Counter++;
                }
            } while (CmNumber[0] == CmNumber[1] || CmNumber[0] == CmNumber[2] || CmNumber[0] == CmNumber[3] || CmNumber[1] == CmNumber[2] || CmNumber[1] == CmNumber[3] || CmNumber[2] == CmNumber[3]);


            //do
            //{
            //    CmNumber[0] = Convert.ToString(generator.Next(1, 9));
            //    CmNumber[1] = Convert.ToString(generator.Next(1, 9));
            //    CmNumber[2] = Convert.ToString(generator.Next(1, 9));
            //    CmNumber[3] = Convert.ToString(generator.Next(1, 9));
            //} while (CmNumber[0] == CmNumber[1] || CmNumber[0] == CmNumber[2] || CmNumber[0] == CmNumber[3] || CmNumber[1] == CmNumber[2] || CmNumber[1] == CmNumber[3] || CmNumber[2] == CmNumber[3]);
            return RandomG = Convert.ToString(CmNumber[0] + CmNumber[1] + CmNumber[2] + CmNumber[3]);
        }
        private static string Token = "648939177:AAH-wxagSRhCIySBg2dPCZ0VJCsNGzWJXOM";
        private static ReplyKeyboardMarkup MainMenu;
        static void Main(string[] args)
        {
            MainMenu = new ReplyKeyboardMarkup
            {
                Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("شروع بازی جدید")
                    }
                    ,
                    new KeyboardButton[]
                    {
                        new KeyboardButton("امتیاز شما")
                        ,
                        new KeyboardButton("برترین بازیکنان")
                    }
                    ,
                    new KeyboardButton[]
                    {
                        new KeyboardButton("درباره ی ما")
                    }
                }
            };
            Task.Run(() => RunBot());
            Console.ReadKey();
        }
        private static string GuessTrueOrFalse(string ComputerGuess, string Guess)
        {
            string[] ComputerGuessArray = new string[ComputerGuess.Length];
            byte Counter = 0;
            foreach (char item in ComputerGuess.ToCharArray())
            {
                ComputerGuessArray[Counter] = Convert.ToString(int.Parse(item.ToString()));
                Counter++;
            }
            int[] CPA = new int[ComputerGuess.Length];
            Counter = 0;
            foreach (string item in ComputerGuessArray)
            {
                CPA[Counter] = Convert.ToInt32(item);
                Counter++;
            }
            int[] UserGuess = new int[Guess.Length];
            Counter = 0;
            foreach (char item in Guess.ToCharArray())
            {
                UserGuess[Counter] = int.Parse(item.ToString());
                Counter++;
            }
            //int[] MemberG = new int[4];
            while (UserGuess[0] <= 1 && UserGuess[0] >= 9 && UserGuess[1] <= 1 && UserGuess[1] >= 9 && UserGuess[2] <= 1 && UserGuess[2] >= 9 && UserGuess[3] <= 1 && UserGuess[3] >= 9) ;
            //UserGuess
            string[] Guesss = new string[11];
            if (UserGuess[0] == CPA[0])
            {
                Guesss[0] = (UserGuess[0] + " " + "این عدد درست است.");
            }
            if (UserGuess[0] == CPA[1] || UserGuess[0] == CPA[2] || UserGuess[0] == CPA[3])
            {
                Guesss[1] = (UserGuess[0] + " " + "This Number is correct but its not in right position.");
            }
            if (!(UserGuess[0] == CPA[1] || UserGuess[0] == CPA[2] || UserGuess[0] == CPA[3]) && !(UserGuess[0] == CPA[0]))
            {
                Guesss[2] = (UserGuess[0] + " " + "This number is wrong.");
            }
            if (UserGuess[1] == CPA[1])
            {
                Guesss[3] = (UserGuess[1] + " " + "This Number is Right");
            }
            if (UserGuess[1] == CPA[0] || UserGuess[1] == CPA[2] || UserGuess[1] == CPA[3])
            {
                Guesss[4] = (UserGuess[1] + " " + "This Number is correct but its not in right position.");
            }
            if (!(UserGuess[1] == CPA[0] || UserGuess[1] == CPA[2] || UserGuess[1] == CPA[3]) && !(UserGuess[1] == CPA[1]))
            {
                Guesss[5] = (UserGuess[1] + " " + "This number is wrong.");
            }
            if (UserGuess[2] == CPA[2])
            {
                Guesss[6] = (UserGuess[2] + " " + "This Number is Right");
            }
            if (UserGuess[2] == CPA[0] || UserGuess[2] == CPA[1] || UserGuess[2] == CPA[3])
            {
                Guesss[7] = (UserGuess[2] + " " + "This Number is correct but its not in right position.");
            }
            if (!(UserGuess[2] == CPA[0] || UserGuess[2] == CPA[1] || UserGuess[2] == CPA[3]) && !(UserGuess[2] == CPA[2]))
            {
                Guesss[8] = (UserGuess[2] + " " + "This number is wrong.");
            }
            if (UserGuess[3] == CPA[3])
            {
                Guesss[9] = (UserGuess[3] + " " + "This Number is Right");
            }
            if (UserGuess[3] == CPA[0] || UserGuess[3] == CPA[1] || UserGuess[3] == CPA[2])
            {
                Guesss[10] = (UserGuess[3] + " " + "This Number is correct but its not in right position.");
            }
            if (!(UserGuess[3] == CPA[0] || UserGuess[3] == CPA[1] || UserGuess[3] == CPA[2]) && !(UserGuess[3] == CPA[3]))
            {
                Guesss[11] = (UserGuess[3] + " " + "This number is wrong.");
            }
            //if (UserGuess[0] == CPA[0] && UserGuess[1] == CPA[1] && UserGuess[2] == CPA[2] && UserGuess[3] == CPA[3])
            //{

            //}
            string Result = Guesss[0] + Guesss[1] + Guesss[2] + Guesss[3] + Guesss[4] + Guesss[5] + Guesss[6] + Guesss[7] + Guesss[8] + Guesss[9] + Guesss[10] + Guesss[11];
            return Result;

        }
        public static async Task RunBot()
        {
            List<Users> BotDataList = new List<Users>();
            var bot = new TelegramBot(Token);
            var me = await bot.MakeRequestAsync(new GetMe());
            Console.WriteLine("UserName Is: {0} And My Name Is {1}", me.Username, me.FirstName);
            var User = new User();
            Console.WriteLine(User.Id);
            long offset = 0;
            int whilecount = 0;
            while (true)
            {
                Console.WriteLine("WhileCount is:{0} ", whilecount);
                whilecount++;
                var Updates = await bot.MakeRequestAsync(new GetUpdates() { Offset = offset });
                Console.WriteLine("Update Count Is:{0}", Updates.Count());
                Console.WriteLine("--------------------------------------------");
                try
                {
                    foreach (var Update in Updates)
                    {
                        offset = Update.UpdateId++;
                        var text = Update.Message.Text;
                        if (text == "/start")
                        {
                            var req = new SendMessage(Update.Message.Chat.Id, "لطفا یک گزینه انتخاب کنید.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(req);
                            continue;

                        }
                        else if (text != null && text.Contains("شروع بازی جدید"))
                        {
                            var Message1 = new SendMessage(Update.Message.Chat.Id, "سیستم درحال حدس عدد.")
                            { ReplyMarkup = new ReplyKeyboardRemove() { RemoveKeyboard = true } };
                            await bot.MakeRequestAsync(Message1);
                            Users NewUser = new Users(me.FirstName + me.LastName, me.Id, 0);
                            RandomGenerator(ref NewUser.ComputerGuess);
                            var Message2 = new SendMessage(Update.Message.Chat.Id, "حدس عدد انجام شد.");
                            await bot.MakeRequestAsync(Message2);
                            var Message3 = new SendMessage(Update.Message.Chat.Id, "لطفا یک عدد 4 رقمی حدس بزنید.");
                            await bot.MakeRequestAsync(Message3);
                            NewUser.Counter = 5;
                            while (NewUser.Counter > 0)
                            {
                                offset = Update.UpdateId++;
                                var Guess = Update.Message.Text; 
                                try
                                {
                                    if (Guess != null && Guess.Contains(NewUser.ComputerGuess))
                                    {
                                        var Message4 = new SendMessage(Update.Message.Chat.Id, "درست حدس زدید.");
                                        await bot.MakeRequestAsync(Message4);
                                        NewUser.Score += 5;
                                        var Message5 = new SendMessage(Update.Message.Chat.Id, "امتیاز شما:" + NewUser.Score);
                                        await bot.MakeRequestAsync(Message5);
                                        NewUser.Counter = 0;
                                        continue;
                                    }
                                    else if (Guess != null)
                                    {
                                        var Message4 = new SendMessage(Update.Message.Chat.Id, GuessTrueOrFalse(NewUser.ComputerGuess, Guess));
                                        await bot.MakeRequestAsync(Message4);
                                        continue;
                                    }
                                    else if (NewUser.Counter == 0)
                                    {
                                        var Message4 = new SendMessage(Update.Message.Chat.Id, GuessTrueOrFalse(NewUser.ComputerGuess, Guess));
                                        await bot.MakeRequestAsync(Message4);
                                    }
                                    NewUser.Counter--;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    var Message4 = new SendMessage(Update.Message.Chat.Id, "لطفا عدد وارد کنید.");
                                    continue;
                                }
                            }

                        }
                        else if (text != null && text.Contains("امتیاز شما"))
                        {
                            var req = new SendMessage(Update.Message.Chat.Id, "درحال توسعه.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(req);
                            continue;
                        }
                        else if (text != null && text.Contains("برترین بازیکنان"))
                        {
                            var req = new SendMessage(Update.Message.Chat.Id, "درحال توسعه.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(req);
                            continue;
                        }
                        else if (text != null && text.Contains("درباره ی ما"))
                        {

                        }
                        else
                        {
                            var req = new SendMessage(Update.Message.Chat.Id, "لطفا یک گزینه انتخاب کنید.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(req);
                            continue;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }
    }
}
