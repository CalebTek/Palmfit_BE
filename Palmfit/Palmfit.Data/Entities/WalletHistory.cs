namespace Palmfit.Data.Entities
{
    public class WalletHistory
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public string Details { get; set; }
        public int WalletAppUserId { get; set; }
        public Wallet Wallet { get; set; }
    }
}