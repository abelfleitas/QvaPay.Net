using QvaPayDotnet.Models;
using System;

namespace QvaPayDotnet.ResultResponse
{
    public class TransactionResponse
    {
        public string uuid { get; set; }
        public int user_id { get; set; }
        public string app_id { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public string remote_id { get; set; }
        public string status { get; set; }
        public int paid_by_user_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int signed { get; set; }
        public AppInfo app { get; set; }
        public Owner owner { get; set; }
    }
}
