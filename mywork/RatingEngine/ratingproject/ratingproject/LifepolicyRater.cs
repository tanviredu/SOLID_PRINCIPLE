using System;
using System.Collections.Generic;
using System.Text;

namespace ratingproject
{
    public class LifepolicyRater : Policymanager
    {

        // the Logger is applied autometically

        public override void Rate(LifePolicy lf)
        {
            Log("Rating Life Policy");
            Log("Validating Policy");
            if(lf.DateOfBirth == DateTime.MinValue)
            {
                Log("Life policy must include the date of Birth");
                return;
            }
            if (lf.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (lf.Amount == 0)
            {
                Log("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - lf.DateOfBirth.Year;
            if (lf.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < lf.DateOfBirth.Day ||
                DateTime.Today.Month < lf.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = lf.Amount * age / 200;
            if (lf.Issmoker)
            {
                lf.Rating = baseRate * 2;
                return;
            }

        }

       
    }
}
