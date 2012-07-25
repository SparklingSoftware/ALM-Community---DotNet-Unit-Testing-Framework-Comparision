using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetSharp;
using System.Net;

namespace TwitterFacade
{

    public delegate void TweetResultEventHandler(object sender, TwitterSearchResultEventArgs e);
    public class Twitter 
    {

        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public event TweetResultEventHandler TweetSearchResultRetrieved;

        // Invoke the event; called whenever search is invoked
        protected virtual void OnTweetSearchResultRetrieved(TwitterSearchResultEventArgs e)
        {
            if (TweetSearchResultRetrieved != null)
                TweetSearchResultRetrieved(this, e);
        }
        public void GetTweetsByHashTagAsync(string hashTag)
        {
            var twitterService = new TwitterService();
            var result = twitterService.Search(hashTag,
                (tweets, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OnTweetSearchResultRetrieved(new TwitterSearchResultEventArgs() { TwitterSearchStatuses = tweets.Statuses });
                    }
                });
        }

        //Syncronous
        public IEnumerable<TwitterSearchStatus> GetTweetsByHashTag(string hashTag)
        {
            //To get the consumer key and consumer secret, create an app via hhtp://dev.twitter.com
            var twitterService = new TwitterService("ocLgiNzqasrM6eq6rOTmw",
                                                    "lLT8nzQoWZbdjYDWGnjmzoiA7BTlaLHe8vRFH4JwiY0",
                                                    "22595957-0agngUCx0DnuzGxiovlEpYJvdmUxO8pSraqUpbZn8",
                                                    "3jYeMHhWXstAvooatZOZBEmLHBnxGQv32FpVSBjuZk");
            var result = twitterService.Search(hashTag);
            if (result != null)
            {
                return result.Statuses;
            }
            return null;
        }
    }
}
