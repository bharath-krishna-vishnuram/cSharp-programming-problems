using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    public class SubArraysController : CodingControllerBase
    {

        /// <summary>
        /// Find the contiguous non empty subarray within an array, A of length N which has the largest sum
        /// </summary>
        /// <returns>Integer representing the maximum possible sum of the contiguous subarray.</returns>   
        [HttpPost]
        public int MaxSubArraySum(int[] A)
        {
            int maxSum = A[0];
            int currSum = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                currSum = Math.Max(currSum + A[i], A[i]);
                maxSum = Math.Max(maxSum, currSum);
            }
            return maxSum;
        }

        /// <summary>
        /// In an integer array A find the sum of all subarray sums of A
        /// </summary>
        /// <returns>integer denoting the sum of all subarray sums of the given array.</returns>   
        [HttpPost]
        public long AllSubarraySum(int[] A)
        {
            int n = A.Length;
            long overallSum = 0;
            for (int index = 0; index < n; index++)
                overallSum += ((index + 1l) * (n - index) * A[index]);
            return overallSum;
        }

        /// <summary>
        /// In an integer array A, Find the subarray with least average of size k
        /// </summary>
        /// <returns>index of the first element of the subarray of size k that has least average.</returns>   
        [HttpPost]
        public int LeastSubarrayAverage(int[] A, int K)
        {
            int sum = 0;
            int n = A.Length;
            for (int i = 0; i < K; i++)
                sum += A[i];
            int index = 0;
            int prevSum = sum;
            for (int i = 0; i < n - K; i++)
            {
                sum += A[i + K] - A[i];
                if (sum < prevSum)
                {
                    index = i + 1;
                    prevSum = sum;
                }
                // System.out.println(prevSum + " " + sum + " " + A[i] + " " + A[i+B] + " " + index);
            }
            return index;
        }

        /// <summary>
        /// In integer array C. Find a subarray (contiguous elements) so that 
        /// the sum of contiguous elements is maximum.
        /// But the sum must not exceed B
        /// </summary>
        /// <returns>Returns count of good subarrays in A.</returns>   
        [HttpPost]
        public int MaxSubarray(int B, int[] C)
        {

            int curr = 0, prev = 0, max = 0, sum = 0;
            while (curr < C.Length)
            {
                sum += C[curr];
                if (sum <= B && sum > max)
                    max = sum;
                if (sum > B)
                {
                    while (prev <= curr && sum > B)
                    {
                        sum -= C[prev];
                        prev++;
                    }
                    if (sum > max) 
                        max = sum;
                }
                curr++;
            }
            return max;
        }

        /// <summary>
        /// In array A of 0 and 1's, and an integer B.
        /// Find all the indices as centre of 2 * B + 1 length 0-1 of alternating subarray.
        /// Alternating array contains only 0's and 1's, and having no adjacent 0's or 1's.
        /// </summary>
        /// <returns>Return an integer array containing indices(0-based) in sorted order. 
        /// If no such index exists, return an empty integer array.</returns>   
        /// For e.g.arrays[0, 1, 0, 1], [1, 0] and[1] are 0-1 alternating, while [1, 1] and[0, 1, 0, 0, 1] are not.
        [HttpPost]
        public List<int> AlternatingSubarray(List<int> A, int B)
        {
            List<int> C = new List<int>();
            int n = A.Count(), len = 2 * B + 1, prev = A[0], count = 1;
            bool isValid = false;
            for (int i = 0; i < n; i++)
            {
                // Console.WriteLine(prev + " " + A[i] + " " + count +  " " + i + " " + C.Count() + " " + isValid);
                isValid = prev != A[i];
                if (!isValid)
                    count = 1;
                else if (count != len)
                    count++;
                if (count == len)
                {
                    C.Add(i - B);
                    count--;
                }
                prev = A[i];
            }
            return C;
        }
    }
}
