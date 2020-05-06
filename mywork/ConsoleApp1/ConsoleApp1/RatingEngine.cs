using Newtonsoft.Json; // this is for json
using Newtonsoft.Json.Converters; // fir serializing and deserializing 
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class RatingEngine
    {
        // rating engine reads the policy application
        // and calculate the rating

        public decimal Rating { get; set;}

        public void Rate()
        {
            Console.WriteLine("Starting Rate");
            Console.WriteLine("Loding policy...");

            //open the policy.json file
            // loading the json file
            var policyJson = File.ReadAllText("policy.json");
            // creating a desirialized object from the 
            // json file
            var policy = JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());


            // make a switch statement to find the 
            // policy
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    Console.WriteLine("Rating AUTO policy...");
                    Console.WriteLine("Validating policy.");
                    if (String.IsNullOrEmpty(policy.Make))
                    {
                        Console.WriteLine("Auto policy must specify Make");
                        return;
                    }
                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }
                        Rating = 900m;
                    }
                    break;

                case PolicyType.Land:
                    Console.WriteLine("Rating LAND policy...");
                    Console.WriteLine("Validating policy.");
                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        Console.WriteLine("Land policy must specify Bond Amount and Valuation.");
                        return;
                    }
                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        Console.WriteLine("Insufficient bond amount.");
                        return;
                    }
                    Rating = policy.BondAmount * 0.05m;
                    break;

                case PolicyType.Life:
                    Console.WriteLine("Rating LIFE policy...");
                    Console.WriteLine("Validating policy.");
                    if (policy.DateOfBirth == DateTime.MinValue)
                    {
                        Console.WriteLine("Life policy must include Date of Birth.");
                        return;
                    }
                    if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                    {
                        Console.WriteLine("Centenarians are not eligible for coverage.");
                        return;
                    }
                    if (policy.Amount == 0)
                    {
                        Console.WriteLine("Life policy must include an Amount.");
                        return;
                    }
                    int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                    if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                        DateTime.Today.Day < policy.DateOfBirth.Day ||
                        DateTime.Today.Month < policy.DateOfBirth.Month)
                    {
                        age--;
                    }
                    decimal baseRate = policy.Amount * age / 200;
                    if (policy.IsSmoker)
                    {
                        Rating = baseRate * 2;
                        break;
                    }
                    Rating = baseRate;
                    break;

                default:
                    Console.WriteLine("Unknown policy type");
                    break;
            }

            Console.WriteLine("Rating complete");
        }


    }
}
