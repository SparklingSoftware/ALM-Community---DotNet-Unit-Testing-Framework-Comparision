using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TwitterFacade;
namespace UnitTests.Nunit
{
    [TestFixture]
    public class ATwitterFacade
    {

        [TestCase]
        public void CanSearchForHashTag()
        {
            var twitterFacade = new Twitter();
            //twitterFacade.TweetSearchResultRetrieved += (sender, e) => {
            //    Assert.IsNotNull(e.TwitterSearchStatuses);
            //}; 
            
            var result = twitterFacade.GetTweetsByHashTag("#UnitTests");
            Assert.IsNotNull(result);
            
        }

        
    }
}
