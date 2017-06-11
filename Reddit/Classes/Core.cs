using System;
using System.Collections.Generic;
using RedditSharp.Things;
using System.Threading.Tasks;

namespace Reddit.Classes

{
    class Core
    {
        public static List<string> ListOfNames = new List<string>();

        public static async Task CommentManagement(Comment comment)
        {
            await FinishedFunctions.ReplyOnBirthDay(comment);
            await GoingIntoChainOfComments(comment);
        }

        public static async Task GoingIntoChainOfComments(Comment comment)
        {
            if (comment.Comments.Count > 0)
            {
                foreach (Comment commentChain in comment.Comments)
                {
                    if (!string.IsNullOrEmpty(commentChain.AuthorName))
                    {
                        NonApiTasks.CreateLog($"Going into chain: {commentChain.Shortlink}" + Environment.NewLine);
                        await CommentManagement(commentChain);
                    }
                }
            }
        }
    }
}
