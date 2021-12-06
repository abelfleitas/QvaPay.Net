
namespace QvaPayDotnet.ResultResponse
{
    public class InvoiceResponse
    {
        public string app_id { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public string remote_id { get; set; }
        public int signed { get; set; }
        public string transation_uuid { get; set; }
        public string url { get; set; }
        public string signedUrl { get; set; }
    }
}
