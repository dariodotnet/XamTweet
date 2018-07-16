using System;

namespace XamTweet.Forms.Views
{

    public class MainViewMenuItem
    {
        public MainViewMenuItem()
        {
            TargetType = typeof(MainViewDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}