
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;
using System.Data.OleDb;
using System.Data;
namespace TestBot
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{

       private static string[,] str;
        private static Telegram.Bot.TelegramBotClient BOT;
        static Label l1;
        public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
            

            BOT = new Telegram.Bot.TelegramBotClient("455535082:AAGeMMob7ty-q_QFSN4kV2icxt-L7_7PGr0");  //"вставь сюда свой токен");	
            BOT.OnMessage += BotOnMessageReceived;
			BOT.StartReceiving( new UpdateType[] {UpdateType.MessageUpdate} );
  			button1.Enabled = false;
            l1 = label1;
		}
		

		private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            
             List<string> name = new List<string>();
             DateTime date = new DateTime(1992, 02, 12);
            string fast;
            DB db = new DB();
        Telegram.Bot.Types.Message msg = messageEventArgs.Message;
			if (msg == null || msg.Type != MessageType.TextMessage) return;

            var dict = new Dictionary<DateTime, List<string>>();
            String Answer = "";

            switch (msg.Text)
            {
                //case date 
            }
            l1.Text = msg.Text;
            date = new DateTime(2017, 12, 31);
            fast = date.ToShortDateString();
            date = Convert.ToDateTime(fast);
            name.Reverse();
            db.Method(dict, name, date);

            /*    switch (msg.Text){
                     case "/start": Answer = "/stone - твой камень\r\n/scissors - твои ножницы\r\n/paper - твоя бумага\r\n/baba - показать бабу";break;
                     case "/stone": Answer = "А у меня бумага - ты проиграл"; break;
                     case "/scissors": Answer = "А у меня камень - ты проиграл"; break;
                     case "/paper": Answer = "А у меня ножницы - ты проиграл"; break;
                     case "/baba": Answer = "Вот тебе баба -http://sandi-rzn.ru/wp-content/uploads/c5b6dac3b02717e7fd6781b7515d64b4.jpg"; break;
                     default: Answer = "иди нахуй!"; break;
                }*/
            await BOT.SendTextMessageAsync(msg.Chat.Id,Answer);	
			
		}
	
 
}
    public class DB
    {
        public List<string> celebr { get; set; }

        public DateTime dtime { get; set; }
        public void Method(Dictionary<DateTime, List<string>> obj, List<string> Name, DateTime date)
        {
            obj.Add(new DateTime(date.Year, date.Month, date.Day), new List<string>(Name));// { "new year", "buhastus" });

        }
    }

}
