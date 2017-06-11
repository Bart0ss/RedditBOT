using System;
using System.Linq;
using RedditSharp.Things;
using System.Threading.Tasks;
using Reddit.Classes;

namespace Reddit
{
    class Program
    {
        public static string Login = "";
        public static string Password = "";
        public static string SubredditName = "/r/";
        public static string PathToAsciiArtFile = @"cake.txt";
        public static int PositionOfTextToInput = 472;
        public static int AmountOfPostsToTake = 10;
        static void Main()
        {
            NonApiTasks.CreateLog("Banning Users...");
            NonApiTasks.ListOfBannedUsers();
            NonApiTasks.CreateLog("Checking variables...");
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(SubredditName) || string.IsNullOrEmpty(PathToAsciiArtFile) || PositionOfTextToInput == -1)
            {
                NonApiTasks.CreateLog("Login: ");
                Login = Console.ReadLine();
                NonApiTasks.CreateLog("Password: ");
                Password = Console.ReadLine();
                NonApiTasks.CreateLog("Subreddit (just name e.g 'news', without /r/): ");
                SubredditName = Console.ReadLine();
                NonApiTasks.CreateLog("Paste the path to the file with an ASCII ART");
                PathToAsciiArtFile = Console.ReadLine();
                NonApiTasks.CreateLog("Position (int) of nth char in PathToAsciiArtFile that's gonna be replaced with e.g user name");
                PositionOfTextToInput = Convert.ToInt32(Console.ReadLine());
            }
            try
            { 
                NonApiTasks.CreateLog("Starting...");
                MainAsync(Login, Password, AmountOfPostsToTake).Wait();
            }
            catch (Exception e)
            {
                NonApiTasks.CreateExceptionLog(e);
            }
            Console.ReadKey();
        }

        static async Task MainAsync(string login, string password, int amountOfThreadsToRead)
        {
            NonApiTasks.CreateLog("Grabbing user...");
            var reddit = new RedditSharp.Reddit();
            NonApiTasks.CreateLog("Logging in...");
            reddit.LogIn(login, password);
            NonApiTasks.CreateLog("Subreddit...");
            var subreddit = reddit.GetSubreddit(SubredditName);
            NonApiTasks.CreateLog("Subscribing...");
            subreddit.Subscribe();
            NonApiTasks.CreateLog("Reading ASCII from file...");
            try
            {
                NonApiTasks.Get_ASCII_ArtFromFile();
            }
            catch (Exception e)
            {
                NonApiTasks.CreateExceptionLog(e);
            }
            NonApiTasks.CreateLog("Wait for a while... ");
            NonApiTasks.CreateLog("Waiting time is dependent on subreddit's size");

            while (subreddit.Posts.Any())
            {
                NonApiTasks.CreateLog($"SubReddit: {subreddit.Name} with {subreddit.Posts.Count()}" + $"posts and {subreddit.Subscribers} subs.");

                foreach (var post in subreddit.Hot.Take(amountOfThreadsToRead))
                {
                    NonApiTasks.CreateLog($"Here's {post.CommentCount} comments in that post {post.Title}");
                    foreach (Comment comment in post.Comments)
                    {
                        await Core.CommentManagement(comment);                
                    }
                }
            }
        }
    }
}
