using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    //[Route("api/[controller]/[action]")]
    //[ApiController]
    public class BitWiseController : CodingControllerBase
    {
        /// <summary>
        /// Switch the least significant high bit in input integer.
        /// </summary>
        /// <returns>Binary represenation of input and integer after switching.</returns>
        [HttpGet]
        public Tuple<string, string> SwitchLastHighBit(int input)
        {
            var t = (input & (input - 1));
            return new Tuple<string, string>(IntToBinary(input), IntToBinary(t));
        }
        [HttpGet]
        public Tuple<string, string> GetLastDiffBit(int aXorb)
        {
            var t = (aXorb & (aXorb - 1)) ^ aXorb;
            return new Tuple<string, string>(IntToBinary(aXorb), IntToBinary(t));
        }
        private string IntToBinary(int decVal) =>  Convert.ToString(decVal, 2);

        /// <summary>
        /// Given an array of integers A, every element appears twice except for one. Find .
        /// </summary>
        /// <returns>Returns that integer that occurs once.</returns>
        [HttpPost]
        public int SingleNumber(List<int> A)
        {
            int result = A[0];
            for (int i = 1; i < A.Count; i++)
                result ^= A[i];
            return result;
        }

        [HttpPost]
        public String AddBinary(String A, String B)
        {
            int n = A.Length, m = B.Length;
            int len = Math.Max(n, m)+1;
            
            bool carryOver = false;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < len; i++)
            {
                bool value1 = false, value2 = false;
                if (i < n)
                    value1 = A[n - 1 - i] == '1';
                if (i < m)
                    value2 = B[m - 1 - i] == '1';
                if (value1 ^ value2 ^ carryOver)
                    sb.Append('1');
                else
                    sb.Append('0');
                carryOver = carryOver ? (value1 || value2) : (value1 && value2);
            }
            if (sb[len - 1] == '0')
                sb.Length--;

            return sb.ToString().Reverse().ToString();
        }
    }
}