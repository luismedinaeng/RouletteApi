namespace RouletteApi.Models
{
    public class Bet
    {    
        public long Id { get; set; }
        public int Token { get; set; }
        public long Value { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
        public long RouletteId { get; set; }
        
        public void updateStatus(int resultNumber, int resultColor)
        {
            if (this.Token == resultColor || this.Token == resultNumber)
                this.Status = Constants.WIN;
            else
                this.Status = Constants.LOSE;
        }

    }
}