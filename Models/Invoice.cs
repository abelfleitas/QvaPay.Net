
namespace QvaPayDotnet.Models
{
    public class Invoice
    {
        public decimal amount { get; set; }
        public string description { get; set; }
        public string remote_id { get; set; }
        public bool signed { get; set; }
    }
}
