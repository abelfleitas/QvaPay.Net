using QvaPayDotnet.Models;
using System.Collections.Generic;

namespace QvaPayDotnet.ResultResponse
{
    public class TransactionsResponse
    {
        public int current_page { get; set; }
        public List<Transaction> data { get; set; }
        public string first_page_url { get; set; }
        public int from { get; set; }
        public int last_page { get; set; }
        public string last_page_url { get; set; }
        public string next_page_url { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public string prev_page_url { get; set; }
        public int to { get; set; }
        public int total { get; set; }
    }
}
