using DataAccess;
using System;

namespace BusinessLogic
{
    public class PrimeNumberLogic
    {


        //public User GetUserByToken(User userfound)
        //{
        //    return _users.FirstOrDefault(e => e.TokenIdentifier == token);
        //}


        public static bool IsPrime(string numberStr)
        {

            int number = int.Parse(numberStr);

            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }




    }
}
