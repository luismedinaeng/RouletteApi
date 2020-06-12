using System;
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
            Bets = new List<Bet>();
        }
        public bool AddBet(Bet newBet)
        {
            if (string.Compare(this.Status, Constants.OPEN) == 0)
            {
                newBet.RouletteId = this.Id;
                Bets.Add(newBet);
                return true;
            }
            else
                return false;
        }
        public void CleanBets()
        {
            this.Bets.Clear();
        }

        public void CloseBets()
        {
            foreach(Bet bet in this.Bets)
            {
                bet.updateStatus(this.Result, Constants.GetTokenColor(this.Result));
            }
        }
        public bool Open()
        {
            if (this.Status == Constants.CLOSE)
            {
                this.Result = Constants.WITHOUT_RESULT;
                this.Status = Constants.OPEN;
                return true;
            }
            else
                return false;
        }
        public bool Close()
        {
            if (this.Status == Constants.OPEN && Bets.Count > 0)
            {
                Random random = new Random();
                this.Result = random.Next(Constants.MIN_TOKEN, Constants.MAX_TOKEN);
                this.Status = Constants.CLOSE;
                this.CloseBets();
                return true;
            }
            else
                return false;

        }
    }
}