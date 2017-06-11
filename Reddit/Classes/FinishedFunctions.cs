using System;
using RedditSharp.Things;
using System.Threading.Tasks;
using System.Threading;

namespace Reddit.Classes
{
    class FinishedFunctions
    {
        public static async Task ReplyOnBirthDay(Comment comment)
        {
            if (!Core.ListOfNames.Contains(comment.AuthorName) && !Redditor.ImBot(comment.AuthorName))
            {
                NonApiTasks.CreateLog($"Comments count: {comment.Comments.Count}. Current comment: {comment.Shortlink}");
                await Task.Run(() =>
                {
                    if (Redditor.HasBirthtDayToday(comment.AuthorName) && Redditor.NameIsLegal(comment.AuthorName))
                    {
                        Core.ListOfNames.Add(comment.AuthorName);
                        try
                        {
                            comment.Reply(NonApiTasks.InsertNameInto_ASCII_Art(comment.AuthorName + "!"));
                        }
                        catch (Exception e)
                        {
                            NonApiTasks.CreateExceptionLog(e);
                            throw;
                        }
                        NonApiTasks.CreateLog($"SENT TO: {comment.Shortlink}" + Environment.NewLine);
                    }
                    else
                    {
                        NonApiTasks.CreateLog($"I DID NOT SEND: {comment.Shortlink}" + Environment.NewLine);
                    }
                    Thread.Sleep(1000); // need to be done better
                });
            }
        }
    }
}
