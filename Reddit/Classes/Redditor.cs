using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace Reddit.Classes
{
    class Redditor
    {
        public static int[] GetDateOfAccountCreation(string name)
        {
            int[] output = new int[3];
            try
            {
                WebClient web = new WebClient();
                string url = "http://www.reddit.com/user//about.json";
                url = url.Insert(27, name);

                var json = web.DownloadString(url);
                dynamic data = JObject.Parse(json);
                double unixTime = Convert.ToDouble(data.data.created_utc);
                DateTime convertedFromUnix = NonApiTasks.UnixTimeStampToDateTime(unixTime);

                output[0] = convertedFromUnix.Month;
                output[1] = convertedFromUnix.Day;
                output[2] = convertedFromUnix.Year;
                return output;
            }
            catch
            {
                // Why these weird values are here? It is just 210th month, 100th day and 333th year, thus its impossible so bot won't reply anyway
                // he's using those kind of random values when something "unexpected" happened.
                // Need to be done better.
                output[0] = 210;
                output[1] = 100;
                output[2] = 333;
                return output;
            }
        }
        public static bool HasBirthtDayToday(string name)
        {
            int[] monthDay = GetDateOfAccountCreation(name);
            return (monthDay[0] == DateTime.Now.Month && monthDay[1] == DateTime.Now.Day && monthDay[2] != DateTime.Now.Year);
        }
        public static bool ImBot(string author)
        {
            author = author.ToLower();
            string bot = Program.Login.ToLower();
            return (author == bot);
        }
        public static bool NameIsLegal(string name)
        {
            return (name != "[deleted]" && name != "[removed]");
        }
    }
}
