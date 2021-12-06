using System;

namespace QvaPayDotnet.ResultResponse
{
    public class AppInfoResponse
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string desc { get; set; }
        public string callback { get; set; }
        public string success_url { get; set; }
        public string cancel_url { get; set; }
        public string logo { get; set; }
        public string uuid { get; set; }
        public bool active { get; set; }
        public bool enabled { get; set; }
        public bool card { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
