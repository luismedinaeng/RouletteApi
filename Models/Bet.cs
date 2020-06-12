using System;

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
        
        public Bet(int token, long value)
        {
            if ((token == Constants.BLACK_TOKEN || token == Constants.RED_TOKEN) || (token >= Constants.MIN_TOKEN && token <= Constants.MAX_TOKEN))
                this.Token = token;
            else
                throw new ArgumentOutOfRangeException("token");
            if (value > 0 || value <= Constants.MAX_VALUE)
                this.Value = value;
            else
                throw new ArgumentOutOfRangeException("value");
            
            this.Status = Constants.WAITING;
        }

        public void updateStatus(int resultNumber, int resultColor)
        {
            if (this.Token == resultColor || this.Token == resultNumber)
                this.Status = Constants.WIN;
            else
                this.Status = Constants.LOSE;
        }

    }
}