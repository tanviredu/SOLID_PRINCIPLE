using System;
using System.Globalization;

namespace ratingproject
{
    class Program
    {
        static void Main(string[] args)
        {

            // createa dummy object
            LifePolicy lf = new LifePolicy
            {
                FullName = "Tanvir rahman",
                Issmoker = false,
                Amount = (decimal)300.00,
                DateOfBirth = DateTime.Now
            };
            LifepolicyRater lfr = new LifepolicyRater();
            lfr.Rate(lf);





        }
    }
}
