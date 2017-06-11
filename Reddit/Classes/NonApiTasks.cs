using System;
using System.IO;

namespace Reddit.Classes
{
    class NonApiTasks
    {
        public static string Cake;
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static void ListOfBannedUsers()
        {
            // to be done:
            // instant banning users that won't be receiving messages from your bot
            // can be stored in some kind of database or just via workaround
            // ListOfNames.Add(name);
        }
        public static void Get_ASCII_ArtFromFile()
        {
            // file dat contains ascii art
            Cake = File.ReadAllText(Program.PathToAsciiArtFile);
        }
        public static string TryToCenterTheName_With_Spaces(string name, int amount)
        {
            int length = name.Length / 2;
            string output = new String(' ', 10 + (15-length)); // evil floating point bit level hacking
            return output;                                     // Just trying to put enough spaces to place the name at the center of the line.
        }
        public static string InsertNameInto_ASCII_Art(string authorName)
        {
            // position of nth char in ascii art file where we gonna put user name
            int position = Program.PositionOfTextToInput;
            authorName = TryToCenterTheName_With_Spaces(authorName,22) + authorName;
            return Cake.Insert(position, authorName);
        }
        public static void CreateExceptionLog(Exception e)
        {
            CreateLog("Exception: ");
            CreateLog(e.Message);
            CreateLog(e.HelpLink);
            CreateLog(e.Source);
            CreateLog(e.Data.ToString());
            CreateLog(e.StackTrace);
        }
        public static void CreateLog(string log)
        {
            Console.WriteLine(log);
            string path = $@"C:\Users\{Environment.UserName}\Desktop\RedditBOT_log.txt";
            File.AppendAllText(path,Environment.NewLine + DateTime.Now + "\t" + log);
        }
    }
}
