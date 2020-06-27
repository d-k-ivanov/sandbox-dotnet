using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Exceptions
{
    public enum ResponseCodes
    {
        NoSuchIssuer = 15,
        InsufficientFunds = 16,
        CustomerCancellation = 17,

    }

    public class CreditCardWithdrawalException : Exception
    {
        public sealed override string Message { get; }

        public CreditCardWithdrawalException(ResponseCodes resp)
        {
            switch (resp)
            {
                case ResponseCodes.NoSuchIssuer:
                    Message = $"Error code: {resp}. Description: Bank not found...";
                    break;
                case ResponseCodes.InsufficientFunds:
                    Message = $"Error code: {resp}. Description: Not enough money...";
                    break;
                case ResponseCodes.CustomerCancellation:
                    Message = $"Error code: {resp}. Description: Cancelled by user...";
                    break;
            }

        }
    }

    public static class CreditCard
    {
        public static void Withdraw(double amount, string bank, bool cancelled = false)
        {
            Console.WriteLine("Trying to Withdraw money");

            if (bank != "Santander")
            {
                throw new CreditCardWithdrawalException(ResponseCodes.NoSuchIssuer);
            }

            if (amount > 1000)
            {
                throw new CreditCardWithdrawalException(ResponseCodes.InsufficientFunds);
            }

            if (cancelled)
            {
                throw new CreditCardWithdrawalException(ResponseCodes.CustomerCancellation);
            }

            Console.WriteLine("Got Some money");

        }
    }
}
