using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    public class CarryForwardController : CodingControllerBase
    {
        /// <summary>
        /// You have given a string A having Uppercase English letters.
        /// You have to find that how many times subsequence "AG" is there in the given string.
        /// NOTE: Return the answer modulo 109 + 7 as the answer can be very large
        /// </summary>
        /// <returns>Return an integer denoting the number of subsequences.</returns>   
        [HttpPost]
        public int SubsequencesAG(String A)
        {
            int mod = 1000000007;
            int n = A.Length;
            int t = 0, count = 0;
            for (int i = 0; i < n; i++)
            {
                if (A[i] == 'A')
                    t++;
                if (A[i] == 'G')
                    count += t;
            }
            return count%mod;
        }

        /// <summary>
        /// Given an array A. Find the size of the smallest subarray such that 
        /// it contains atleast one occurrence of the maximum value of the array
        /// and atleast one occurrence of the minimum value of the array.
        /// </summary>
        /// <returns>Return length of the smallest subarray which has atleast one occurrence of minimum and maximum element of the array.</returns>   
        [HttpPost]
        public int ClosestMinMax(int[] A)
        {
            int n = A.Length, minValue = A[0], maxValue = A[0], minPos = 0, maxPos = 0, minLen = n;
            for (int i = 0; i < n; i++)
            {
                //if (A[i] < maxValue && A[i] > minValue)
                //    continue;
                if (A[i] > maxValue)
                {
                    maxValue = A[i];
                    maxPos = i;
                    minLen = n;
                }
                else if (A[i] == maxValue)
                    maxPos = i;
                else if (A[i] < minValue)
                {
                    minValue = A[i];
                    minPos = i;
                    minLen = n;
                }
                else if (A[i] == minValue)
                    minPos = i;
                else
                    continue;
                int temp = Math.Abs(maxPos - minPos) + 1;
                minLen = Math.Min(minLen, temp);
            }
            return minLen;
        }
    }
}
