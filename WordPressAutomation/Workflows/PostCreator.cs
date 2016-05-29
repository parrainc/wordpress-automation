using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordPressAutomation
{
    public class PostCreator
    {
        public static string PreviousTitle { get; set; }

        public static string PreviousBody { get; set; }

        public static void CreatePost()
        {
            NewPostPage.GoTo();

            PreviousTitle = CreateTitle();
            PreviousBody = CreateBody();

            NewPostPage.CreatePost(PreviousTitle)
                        .WithBody(PreviousBody)
                        .Publish();
        }

        private static string CreateBody()
        {
            return CreateRandomString() + ", body";
        }

        private static string CreateTitle()
        {
            return CreateRandomString() + ", title";
        }

        private static string CreateRandomString()
        {
            var s = new StringBuilder();

            var random = new Random();
            var cycles = random.Next(5 + 1);

            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" ");
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
            }

            return s.ToString();
        }

        private static string[] Words = new[]
        {
            "Boy", "Cat", "Dog", "Rabbit", "Baseball", 
            "Throw", "Find", "Scary", "Mustard"
        };

        private static string[] Articles = new[]
        {
            "The", "an", "and", "a", "of", "to",
            "it", "as"
        };
    }
}
