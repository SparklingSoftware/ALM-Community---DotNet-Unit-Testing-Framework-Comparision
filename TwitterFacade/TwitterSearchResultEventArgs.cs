using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetSharp;
namespace TwitterFacade
{
    public class TwitterSearchResultEventArgs:EventArgs
    {
        public IEnumerable<TwitterSearchStatus> TwitterSearchStatuses { get; set; }
    }
}
