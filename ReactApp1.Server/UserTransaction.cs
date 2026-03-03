namespace ReactApp1.Server
{
    public class UserTransaction
    {
        public Guid Id { get; set; }
        public string? EntryType { get; set; }
        public string? Source { get; set; }
        public decimal Amount { get; set; } = 0;
    }
}
