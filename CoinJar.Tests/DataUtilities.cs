using CoinJar.Core.Domain;
using System.Collections.Generic;

namespace CoinJar.Tests
{
    public static class DataUtilities
    {
        public static Coin GetCoin()
        {
            return new Coin()
            {
                Amount = 100,
                Volume = 10
            };
        }

        public static List<Coin> GetCoinsList()
        {
            return new List<Coin>()
            {
                new Coin()
                {
                    Amount = 200,
                    Volume = 20
                },
                new Coin()
                {
                    Amount = 20,
                    Volume = 1
                },

                new Coin()
                {
                    Amount = 400,
                    Volume = 40
                },

                new Coin()
                {
                    Amount = 100,
                    Volume = 10
                },
            };
        }
    }
}
