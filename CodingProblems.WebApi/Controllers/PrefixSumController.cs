using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    public class PrefixSumController : CodingControllerBase
    {
        /// <summary>
        /// Given an integer array A of size N.
        /// You can pick B elements from either left or right end of the array A to get maximum sum.
        /// Find and return this maximum possible sum
        /// </summary>
        /// <returns>Return an integer denoting the maximum possible sum of elements you picked.</returns>   
        [HttpPost]
        public int MaximumPossibleSum(List<int> A, int B)
        {
            int n = A.Count();
            int newSum = 0;
            for (int i = 0; i < B; i++)
                newSum += A[i];
            int maxSum = newSum;
            for (int i = 0; i < B; i++)
            {
                // System.out.println(aSum[i] + " " +  rSum[B-2-i]);
                newSum = newSum - A[B - 1 - i] + A[n - 1 - i];
                if (newSum > maxSum)
                    maxSum = newSum;
            }
            return maxSum;
        }

        /// <summary>
        /// You are given an integer array A of length N.
        /// You are also given a 2D integer array B with dimensions M x 2, where each row denotes a[L, R] query.
        /// For each query, you have to find the sum of all elements from L to R indices in A (1 - indexed).
        /// </summary>
        /// <returns>Return an integer array of length M where ith element is the answer for ith query in B.</returns>   
        [HttpPost]
        public long[] RangeSum([FromQuery]int[] A, int[][] B)
        {
            int n = A.Count();
            long[] pf = new long[n];//A.clone();
            pf[0] = (long)A[0];
            int q = B.Count();
            long[] output = new long[q];
            for (int i = 1; i < n; i++)
                pf[i] = pf[i - 1] + A[i];// + a[i]
            for (int i = 0; i < q; i++)
            {
                int l = B[i][0] - 1;
                int r = B[i][1] - 1;
                // System.out.println(l + " " + r + " " + pf[l] + " " + pf[rangeSum]);
                output[i] = pf[r] - (l == 0 ? 0 : pf[l - 1]);
                // System.out.println(output[i]);
            }
            return output;
        }

        /// <summary>
        /// Given an array, arr[] of size N, the task is to find the count of array indices such that 
        /// removing an element from these indices makes the sum of even-indexed and odd-indexed array elements equal
        /// </summary>
        /// <returns>count of array indices.</returns>   
        [HttpPost]
        public int EqualIndexedSum(int[] A)
        {
            int n = A.Count();
            long[] oddSum = new long[n];//A.clone();
            long[] evenSum = new long[n];//A.clone();
            evenSum[0] = (long)A[0];
            oddSum[0] = 0;
            int count = 0;
            for (int i = 1; i < n; i++)
            {
                oddSum[i] = oddSum[i - 1] + (i % 2 == 0 ? 0 : A[i]);
                evenSum[i] = evenSum[i - 1] + (i % 2 != 0 ? 0 : A[i]);
            }
            for (int i = 0; i < n; i++)
            {
                long s1 = i != 0 ? getSum(oddSum, 0, i - 1) : 0;
                long s2 = i != 0 ? getSum(evenSum, 0, i - 1) : 0;
                long s3 = getSum(oddSum, i + 1, n - 1);
                long s4 = getSum(evenSum, i + 1, n - 1);
                if (s1 + s4 == s2 + s3)
                    count++;
                // System.out.println(i + " " + s1+ " " + s2 + " " +s3 + " " +s4 + " " + oddSum[i] + " " + evenSum[i]);
            }
            return count;
        }
        private long getSum(long[] pf, int l, int r)
        {
            return pf[r] - (l == 0 ? 0 : pf[l - 1]);
        }

        /// <summary>
        /// Find Equilibrium index of an array, that is an index such that 
        /// the sum of elements at lower indexes is equal to the sum of elements at higher indexes.
        /// </summary>
        /// <returns>equilibrium index of the given array. If no such index is found then return -1.</returns>   
        [HttpPost]
        public int EquilibriumIndex(int[] A, int B)
        {
            int n = A.Length;
            int[] sum = new int[n];  A.CopyTo(sum, 0);
            for (int i = 1; i < n; i++)
                sum[i] += sum[i - 1];// + a[i]
            for (int i = 0; i < n; i++)
            {
                int s_i_1 = i != 0 ? sum[i - 1] : 0;
                if (s_i_1 == sum[n - 1] - sum[i])
                    return i;
                // System.out.println(sum[0]+ " " + s_1 + " " + sum[n-1] + " " + sum[i]);
            }
            return -1;
        }

        /// <summary>
        /// Given an array with n objects colored red, white or blue, 
        /// sort them so that objects of the same color are adjacent, 
        /// with the colors in the order red, white and blue
        /// Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
        /// </summary>
        /// <returns>integer denoting the minimum time to make all elements equal..</returns>   
        [HttpPost]
        public int[] SortColors(int[] A)
        {
            int n = A.Length, zeroCnt = 0, oneCnt = 0;
            if (n == 1)
                return A;
            for (int i = n - 1; i >= 0; i--)
            {
                if (A[i] == 0)
                    zeroCnt++;
                else if (A[i] == 1)
                    oneCnt++;
            }
            for (int i = 0; i < n; i++)
                A[i] = zeroCnt-- > 0 ? 0 : oneCnt-- > 0 ? 1 : 2;
            return A;
        }
    }
}
