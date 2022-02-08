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
        /// In a string A having Uppercase letters.
        /// You have to find that how many times subsequence "AG" is there in the given string.
        /// </summary>
        /// <returns>Return an integer denoting the number of subsequences modulo 109 + 7.</returns>   
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
            return count % mod;
        }

        /// <summary>
        /// Given an array A. Find the size of the smallest subarray with
        /// atleast one occurrence of the maximum value 
        /// and the minimum value of the array.
        /// </summary>
        /// <returns>Return length of the smallest subarray which has 
        /// atleast one occurrence of minimum and maximum element of the array.</returns>   
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

        /// <summary>
        /// Given an initial state of all bulbs, 
        /// find the minimum number of switches you have to press to turn on all the bulbs
        /// </summary>
        /// <returns>integer representing the minimum number of switches required.</returns>   
        [HttpPost]
        public int SwitchBulbs(int[] A)
        {
            int toggle = 0;
            foreach(var a in A)
                toggle += 1 - (a ^ (toggle & 1));
            return toggle;
        }

        /// <summary>
        /// find all the amazing substrings of S.
        /// Amazing Substring is one that starts with a vowel(a, e, i, o, u, A, E, I, O, U).
        /// </summary>
        /// <returns>integer X mod 10003, here X is number of Amazing Substrings in given string.</returns>   
        [HttpPost]
        public int AmazingSubarrays(String A)
        {
            int cnt = 0;
            String vowels = "aeiouAEIOU";
            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (vowels.IndexOf(A[i]) != -1)
                    cnt += A.Length - i;
            }
            return cnt% 10003;
        }

        /// <summary>
        /// In integer array A, decide whether it is possible to divide the array into 
        /// one or more subarrays of even length such that first and last element of all subarrays will be even.
        /// </summary>
        /// <returns>Return "YES" if it is possible otherwise return "NO" (without quotes).</returns>   
        [HttpPost]
        public String EvenSubArrays(int[] A)
        {
            int n = A.Length;
            if (n % 2 != 0 || (A[0] % 2 != 0) || A[n - 1] % 2 != 0)
                return "NO";
            return "YES";
        }

        /// <summary>
        /// In integer array A,  find all the leaders in the array A.
        /// An element is leader if it is strictly greater than all the elements to its right side.
        /// </summary>
        /// <returns>integer array denoting all the leader elements of the array.</returns>   
        [HttpPost]
        public int[] LeadersInArray(int[] A)
        {
            int n = A.Length;
            List<int> t = new List<int>();
            int leader = A[n - 1];
            t.Add(leader);
            for (int j = n - 2; j >= 0; j--)
            {
                if (A[j] > leader)
                {
                    leader = A[j];
                    t.Add(leader);
                }
            }
            return t.ToArray();
        }
    }
}
