using System;
using System.Linq;
using static DddInPractice.Logic.Money;

namespace DddInPractice.Logic
{
    public class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; }
        public Money MoneyInTransition { get; private set; }

        public void InsertMoney(Money money)
        {
            Money[] conins =
            {
                OnePenny, TwoPence, FivePence, TenPence, TwoPence, FiftyPence, OnePound, TwoPound
            };
            if(!conins.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransition += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransition = None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransition;
            MoneyInTransition = None;
        }
    }
}