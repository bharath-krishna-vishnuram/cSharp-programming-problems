using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    public class BasicDsaController : CodingControllerBase
    {
        /// <summary>
        /// Perfect number is a positive integer which is equal to the sum of its proper positive divisors.
        /// Check if input is Perfect or not..
        /// </summary>
        /// <returns>true if Perfect Number and false if not.</returns>   
        [HttpPost]
        public bool PerfectNumber(int A)
        {
            int sum = -1 * A;
            for (int j = 1; j * j <= A; j++)
            {
                if (A % j == 0)
                {
                    sum += j;
                    if (j * j != A)
                        sum += A / j;
                    // System.out.println(sum + " " + j);
                }
            }
            return A == sum;
        }

        /// <summary>
        /// Given a number A. Return square root of the number if it is perfect square otherwise return -1.
        /// </summary>
        /// <returns>Perfect square root if exists and -1 if not.</returns>   
        [HttpPost]
        public int PerfectSquareRoot(int A)
        {
            int i = 1;
            for (; i * i <= A; i++)
                if (i * i == A)
                    return i;
            return -1;
        }

        /// <summary>
        /// Armstrong number is a positive integer with sum of cubes of each digit of the number is equal to the number itself.
        /// Check if input is Armstrong or not..
        /// </summary>
        /// <returns>true if Armstrong Number and false if not.</returns>   
        [HttpPost]
        public static bool ArmstrongNumber(int A)
        {
            int a = A;
            int sum = 0;
            while (A > 0)
            {
                int digit = A % 10;
                sum += (digit * digit * digit);
                A /= 10;
            }
            return sum == a;
        }
    }
}
