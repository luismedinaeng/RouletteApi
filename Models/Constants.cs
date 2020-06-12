using System.Collections.Generic;

namespace RouletteApi.Models
{
    public static class Constants
    {
        public const int BLACK_TOKEN = -1;
        public const int RED_TOKEN = -2;
        public const int MIN_TOKEN = 0;
        public const int MAX_TOKEN = 36;
        public const long MAX_VALUE = 10000;
        public const int WAITING = 0;
        public const int WIN = 1;
        public const int LOSE = 2;
        public const string OPEN = "open";
        public const string CLOSE = "close";
        public const int WITHOUT_RESULT = -1;

        public static int GetTokenColor(int token)
        {
            List<int> black_tokens = new List<int>() {2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35};
            if (black_tokens.Contains(token))
                return Constants.BLACK_TOKEN;
            else
                return Constants.RED_TOKEN;
        }
    }
}