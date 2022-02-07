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
        /// Check if any good pair exist or not..
        /// </summary>
        /// <returns>1 if good pair exists and 0 if not.</returns>   
        [HttpPost]
        public int GoodPair([FromQuery]int[] A, int B)
        {
            int n = A.Count();
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (A[i] + A[j] == B)
                        return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// You are given an integer array A and an integer B. You have to print the same array after rotating it B times towards right.
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
        /// Given array A and an integer B. You have to tell whether B is present in array A or not.
        /// </summary>
        /// <returns>1 if element exists and 0 if not.</returns>   
        [HttpPost]
        public int LinearSearch(int[] A, int B)
        {
            int n = A.Count();
            for (int i = 0; i < n; i++)
            {
                if (A[i] == B)
                    return 1;
            }
            return 0;
        }

        /// <summary>
        /// Little Ponny is given an array, A, of N integers. In a particular operation, he can set any element of the array equal to -1.
        /// He wants your help for finding out the minimum number of operations required 
        /// such that the maximum element of the resulting array is B.If it is not possible then return -1.
        /// </summary>
        /// <returns>number of operation required if possible and -1 if not.</returns>   
        [HttpPost]
        public int MaxElementPosition(int[] A, int B)
        {
            Array.Sort(A, (a, b) => b.CompareTo(a));
            return Array.IndexOf(A, B);
        }
    }
}
