using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    public class ArraysController : CodingControllerBase
    {

        /// <summary>
        /// Given an array A and a integer B. A pair(i,j) in the array is a good pair if i!=j and (A[i]+A[j]==B). 
        /// Check if any good pair exist or not.
        /// </summary>
        /// <returns>1 if good pair exists and 0 if not.</returns>   
        [HttpPost]
        public int TwoSum([FromQuery]int[] A, int B)
        {
            int n = A.Length;
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if(visited.Contains(A[i]))
                    return 1;
                visited.Add(B-A[i]);
            }
            return 0;
        }

        /// <summary>
        /// You are given an integer array A and an integer B. 
        /// You have to print the same array after rotating it B times towards right.
        /// </summary>
        /// <returns>Array after rotations</returns>   
        [HttpPost]
        public int[] RotateRight(int[] A, int K)
        {
            int n = A.Count();
            ReverseSubArray(A, 0, n - 1);
            ReverseSubArray(A, 0, K - 1);
            ReverseSubArray(A, K, n - 1);
            return A;
        }
        /// <summary>
        /// You are given an integer array A and an integer B. You have to print the same array after rotating it B times towards Left.
        /// </summary>
        /// <returns>Array after rotations</returns>   
        [HttpPost]
        public int[] RotateLeft(int[] A, int K)
        {
            int n = A.Count();
            K %= n;
            ReverseSubArray(A, 0, n - 1);
            ReverseSubArray(A, 0, n - K - 1);
            ReverseSubArray(A, n-K, n - 1);
            return A;
        }

        private void ReverseSubArray(int[] a, int v1, int v2)
        {
            int size = v2 - v1 + 1;
            for (int i = 0; i < size / 2; i++)
                a[i + v1] = a[v2 - i] + a[i + v1] - (a[v2 - i] = a[i + v1]);
        }

        /// <summary>
        /// Given an array A consisting of heights of Christmas trees and 
        /// array B of the same size consisting of the cost of each of the trees.
        /// Return an integer denoting the minimum cost of choosing 3 trees 
        /// whose heights are strictly in increasing order, if not possible, -1.
        /// </summary>
        /// <returns>number of operation required if possible and -1 if not.</returns>   
        [HttpPost]
        public int ChristmasTreesCost(int[] A, [FromQuery] int[] B)
        {
            int n = A.Length;
            int minCost = int.MaxValue;
            for (int i = 1; i < n - 1; i++)
            {
                int smaller = Int32.MaxValue, larger = Int32.MaxValue;
                for (int j = 0; j < i; j++)
                    if (A[i] > A[j])
                        smaller = Math.Min(smaller, B[j]);
                for (int j = i + 1; j < n; j++)
                    if (A[i] < A[j])
                        larger = Math.Min(larger, B[j]);
                if (smaller != Int32.MaxValue && larger != Int32.MaxValue)
                    minCost = Math.Min(minCost, smaller + larger + B[i]);
            }
            return minCost == Int32.MaxValue ? -1 : minCost;
        }

        /// <summary>
        /// Given a binary string A. It is allowed to do at most one swap between any 0 and 1.
        /// </summary>
        /// <returns>Return the length of the longest consecutive 1’s that can be achieved.</returns>   
        [HttpPost]
        public int LongestConsecutiveOnes(string A)
        {
            int l = 0, ans = 0, zeroCount = 0, n = A.Count();
            for (int i = 0; i < n; i++)
            {
                if (A[i] == '0')
                {
                    zeroCount++;
                    if (zeroCount == 1)
                        l = i;
                }
            }
            if (zeroCount < 2)
                return n - zeroCount;
            for (int i = l; i < n; i++)
            {
                if (A[i] == '0')
                {
                    int j = i + 1;
                    while (++j < n && A[j] != '0');
                    var r = j - i - 1;
                    var extraOne = (l + r < (n - zeroCount)) ? 1 : 0;
                    ans = Math.Max(ans, l + r + extraOne);
                    l = r;
                    if (r != 0)
                        i = j-1;
                }
            }
            return ans;
        }

        /// <summary>
        /// Given an array of integers A, of size N.maximum size subarray of A having only non-negative elements.
        /// </summary>
        /// <returns>Return the maximum size subarray of A having only non-negative elements.</returns>   
        [HttpPost]
        public List<int> MaximumPositivity(List<int> A)
        {
            int beg = 0, end = -1, tempBeg = 0;

            for (int i = 0; i <= A.Count; i++)
            {
                if (i == A.Count || A[i] < 0)
                {
                    int tempEnd = i - 1;
                    if (tempEnd - tempBeg > end - beg)
                    {
                        end = tempEnd;
                        beg = tempBeg;
                    }
                    while (++i < A.Count && A[i] < 0) ;
                    tempBeg = i;
                }
            }
            var result = A.GetRange(beg, end - beg + 1);
            return result;
        }
    }
}
