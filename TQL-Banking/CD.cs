using System;
using System.Collections.Generic;
using System.Text;

namespace TQL_Banking
{
    class CD : Account
    {

        public DateTime DepositDate { get; set; }
        public DateTime WithdrawDate { get; set; }
        public decimal APR { get; set; }
        public int CDDuration { get; set; }

        public override bool Deposit(decimal amount)
        {
            if (Balance > 0)
            {
                Console.WriteLine("Cannot make additional deposit");
                return false;
            }
            DepositDate = DateTime.Now;
            WithdrawDate = DepositDate.AddMonths(CDDuration);
            return base.Deposit(amount);
        }
        public override bool Withdraw(decimal amount)
        {
            if(DateTime.Now< WithdrawDate)
            {
                Console.WriteLine($"Cannot withdraw until {WithdrawDate}");
                return false;
            }
            var interest = Balance * (APR / 12.0m) * CDDuration;
            base.Deposit(interest);
            return base.Withdraw(amount);
        }
        public CD (int CDDuration)
        {
            this.CDDuration = CDDuration;
            switch (this.CDDuration)

            {
                case 12: APR = 0.01m;
                    break;
                case 24: APR = 0.02m;
                    break;
                case 36: APR = 0.03m;
                    break;
                case 48: APR = 0.04m;
                    break;
                case 60: APR = 0.04m;
                    break;

            }

        }

    }


}
