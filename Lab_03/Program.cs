using System;
namespace Lab03
{
    //Algorytmy zachłanne
    class CasheRegister
    {
        private int _one, _two, _five;
        public CasheRegister(int one, int two, int five)
        {
            _one = one;
            _two = two;
            _five = five;
        }
        public int[] Payment(int[] income, int ammout)
        {
            int[] rezult = new int[3];
            if (getAmmoutFromCoins(income) < ammout)
            {
                return new int[] { };
            }
            else
            {
                int rest = getAmmoutFromCoins(income) - ammout;
                rezult[2] = rest % 5;
                rezult[1] = rest % 2;
                rezult[0] = rest % 1;
                if (income[0] > 0)
                {
                    rest = rest - 1 * rezult[0];
                }
                else if (income[1] > 0)
                {
                    rest = rest - 2 * rezult[1];
                }
                else if (income[2] > 0)
                {
                    rest = rest - 5 * rezult[2];
                }
                RegisterCoins(income);
                unRegisterCoins(rezult);
                return rezult;
            }
        }
        private void RegisterCoins(int[] income)
        {
            _one += income[0];
            _two += income[1];
            _five += income[2];
        }
        private void unRegisterCoins(int[] outcome)
        {
            _one -= outcome[0];
            _two -= outcome[1];
            _five -= outcome[2];
        }
        private int getAmmoutFromCoins(int[] coins)
        {
            return coins[0] + coins[1] * 2 + coins[2] * 5;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CasheRegister casheRegister = new CasheRegister(0, 1, 2);
            int[] payment = { 5, 5, 5, 5, 1, 1, 0 };
            Console.WriteLine(string.Join(' ', casheRegister.Payment(payment, 22)));
        }

    }
}
