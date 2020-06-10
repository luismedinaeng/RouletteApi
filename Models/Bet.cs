namespace RouletteApi.Models
{
    public class Bet {
        public long Id { get; set; }
        public string Token { get; set; }
        public long Value { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
        public long RouletteId { get; set; }
        
    }
}