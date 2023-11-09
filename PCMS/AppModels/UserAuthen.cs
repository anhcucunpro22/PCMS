namespace PCMS.AppModels
{
    public class UserAuthen
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? Notes { get; set; } 
        public DateTime CreatedDate { get; set; }

        internal string? UserMessage;
    }
}
