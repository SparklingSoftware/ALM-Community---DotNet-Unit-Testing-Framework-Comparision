using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using TweetSharp;
using TwitterFacade;
using System.Windows.Threading;

namespace TwitterClient.ViewModels
{
    //Please note that for 1st cut of this project, I have not used the commands as I want to demonstrate the refactoring and unit testing as we go along 
    public class MainWindowViewModel
    {
        Twitter _twitter;
        Dispatcher _dispatcher;
        public MainWindowViewModel(Dispatcher dispatcher)
        {
            _twitter = new Twitter();
            _dispatcher = dispatcher;
            TweetSearchStatues = new ObservableCollection<TwitterSearchStatus>();
        }

        public ObservableCollection<TwitterSearchStatus> TweetSearchStatues { get; set; }

        public String HashTag { get; set; }
        
        public void SearchByHashTag()
        {
           // _twitter.TweetSearchResultRetrieved += _twitter_TweetSearchResultRetrieved;
            PopulateTweets(_twitter.GetTweetsByHashTag(this.HashTag));
                
        }
        //Consider using Weak Events
        void _twitter_TweetSearchResultRetrieved(object sender, TwitterSearchResultEventArgs e)
        {
            //Unregister the event.
            _twitter.TweetSearchResultRetrieved -= _twitter_TweetSearchResultRetrieved;
            //Populate the observable collection
            //_dispatcher.BeginInvoke(PopulateTweets,DispatcherPriority.Background,null)
            //TweetSearchStatues = new ObservableCollection<TwitterSearchStatus>(e.TwitterSearchStatuses);
        }

        void PopulateTweets(IEnumerable<TwitterSearchStatus> items)
        {
            TweetSearchStatues.Clear();
            foreach (var item in items)
            {
                TweetSearchStatues.Add(item);
            }
        
        }
    }
}
