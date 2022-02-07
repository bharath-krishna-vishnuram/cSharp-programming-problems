using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

            //return (aXorb & (aXorb - 1)) ^ aXorb;
        }
        [HttpGet]
        public Tuple<string, string> GetLastDiffBit(int aXorb)
        {
            var t = (aXorb & (aXorb - 1)) ^ aXorb;
            return new Tuple<string, string>(IntToBinary(aXorb), IntToBinary(t));

            //return (aXorb & (aXorb - 1)) ^ aXorb;
        }
        private string IntToBinary(int decVal)
        {
            int val;
            string a = "";
            Console.WriteLine("Decimal: {0}", decVal);
            while (decVal >= 1)
            {
                val = decVal / 2;
                a += (decVal % 2).ToString();
                decVal = val;
            }
            string binValue = "";
            for (int i = a.Length - 1; i >= 0; i--)
            {
                binValue = binValue + a[i];
            }
            return binValue;
        }

    }
}