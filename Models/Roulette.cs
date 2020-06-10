using System.Collections.Generic;

namespace RouletteApi.Models
{   
    public class Roulette
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public int Result { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }

        public Roulette()
        {
            this.Status = Constants.CLOSE;
            this.Result = Constants.WITHOUT_RESULT;
        }
        public bool AddBet(Bet newBet)
        {
            if (string.Compare(this.Status, Constants.OPEN) == 0)
            {
                Bets.Add(newBet);
                return true;
            }
            else
                return false;
        }
        public void Open()
        {
            if (this.Status == Constants.CLOSE)
            {
                this.Result = Constants.WITHOUT_RESULT;
                this.Status = Constants.OPEN;
            }
        }
    }
}