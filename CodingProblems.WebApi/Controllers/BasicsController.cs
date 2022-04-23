using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    public class BasicsController : CodingControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>.</returns>
        [HttpPost]
        public int fun(int x, int n)
        {
            if (n == 0)
                return 1;
            if (n % 2 == 0)
                return fun(x * x, n / 2);
            else
                return x * fun(x * x, (n - 1) / 2);
        }

        [HttpPost]
        public int foo(int x, int y)
        {
            if (y == 0)
                return 1;
            return bar(x, foo(x, y - 1));
        }
        private int bar(int x, int y)
        {
            if (y == 0)
                return 0;
            return x + bar(x, y - 1);
        }


        [HttpPost]
        public int SecondLargest(int[] input)
        {
            int Largest = input[0];
            int secLargest = input[0];
            foreach(int a in input)
            {
                if (Largest == secLargest && a != secLargest)
                    secLargest = a;
                if (a > Largest)
                {
                    secLargest = Largest;
                    Largest = a;
                }
                else if (a>secLargest)
                {
                    secLargest = a;
                }
            }
            return secLargest;
        }
        [HttpPost]
        public bool IsRotated(string original, string rotatedString)
        {
            int n = original.Length;
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                while (i + j < n && original[i + j] == rotatedString[j])
                {
                    Console.WriteLine($"loop 1:{i} {j} {original[i + j]} {rotatedString[j]}");
                    j++;
                }
                if (j == n)
                    return true;
                int k = 0;
                if (i + j == n)
                {
                    while (j + k < n && original[k] == rotatedString[j + k])
                    {
                        Console.WriteLine($"loop 2:{i} {j} {k} {original[k]} {rotatedString[j + k]}");
                        k++;
                    }
                    if (j + k == n)
                        return true;
                }
            }
            return false;
        }
        [HttpPost]
        public bool HasDuplicate(string input)
        {
            bool[] arr = new bool[26];
            foreach(var a in input)
            {
                if (arr[a - 'a'])
                    return false;
                arr[a - 'a'] = true;
            }
            return true;
        }
        [HttpPost]
        public bool IsPalindrome(string input)
        {
            int n = input.Length;
            for (int i = 0; i < n / 2; i++)
            {
                if (input[i] != input[n - i - 1])
                    return false;
            }
            return true;
        }
        [HttpPost]
        public string[] FizzBuzz(int[] input)
        {
            int n = input.Length;
            string[] res = new string[n];
            for (int i = 0; i < n; i++)
            {
                if (input[i] % 15 == 0)
                    res[i] = "FizzBuzz";
                else if (input[i] % 5 == 0)
                    res[i] = "Buzz";
                else if (input[i] % 3 == 0)
                    res[i] = "Fizz";
                else
                    res[i] = input[i].ToString();
            }
            return res;
        }
        [HttpPost]
        public int[][] ZeroRowColumnConvert(int[][] input)
        {
            int rowsCnt = input.Count();
            int colsCnt = input[0].Count();
            HashSet<int> zeroCols = new HashSet<int>();
            int[][] output = new int[rowsCnt][];
            for (int i=0;i<rowsCnt;i++)
            {
                bool hasZero = false;
                output[i] = new int[colsCnt];
                for (int j = 0; j < colsCnt; j++)
                {
                    if(input[i][j] == 0)
                    {
                        zeroCols.Add(j);
                        hasZero = true;
                    }
                    else 
                        output[i][j] = input[i][j];
                }
                if(hasZero)
                    output[i] = new int[colsCnt];
            }
            for (int i = 0; i < rowsCnt; i++)
                foreach (var j in zeroCols)
                    output[i][j] = 0;
            return output;
        }
        [HttpPost]
        public int LargestOneSquareMat(int[][] input)
        {
            int rowsCnt = input.Count();
            int colsCnt = input[0].Count();
            int[][] output = new int[rowsCnt][];
            List<HashSet<int>> oneIndex = new List<HashSet<int>>();
            var prev = new HashSet<int>();

            for (int i = 0; i < rowsCnt; i++)
            {
                var row = new HashSet<int>();
                int t = 0;
                for (int j = 0; j < colsCnt; j++)
                {
                    if (input[i][j] == 1)
                        row.Add(j);
                    if (prev.Contains(j))
                        t++;
                    else
                        t = 0;
                }
                oneIndex.Add(row);
                prev = row;
            }

            //for (int i = 0; i < rowsCnt; i++)
            //    foreach (var j in zeroCols)
            //        output[i][j] = 0;
            return rowsCnt;
        }
        [HttpPost]
        public int StartingPoint([FromQuery] int[] dist, [FromBody] int[] fuel)
        {
            var distPf = new int[dist.Length];
            var fuelPf = new int[fuel.Length];
            var requiresReset = true;
            distPf[0] = dist[0];
            fuelPf[0] = fuel[0];
            int startingIdx = 0;
            for (int i = 1; i < dist.Length; i++)
            {
                distPf[i] = dist[i] + distPf[i - 1];
                fuelPf[i] = fuel[i] + distPf[i - 1];
                if (fuel[i] >= dist[i] && requiresReset)
                {
                    startingIdx = i;
                    requiresReset = false;
                }
                if (fuel[i] < dist[i])
                    requiresReset = true;

            }
            return fuelPf[^1] != distPf[^1] ? -1: startingIdx;
        }

        [HttpPost]
        public List<string> Permutations(string input)
        {
            int n = input.Length;
            List<string> result = new List<string>();
            findPermutations(string.Empty, input.Remove(0,1), n, result);
            return null;
        }

        private List<string> findPermutations(string v1, string v2, int n, List<string> result)
        {
            if (v1.Length == n)
                result.Add(v1);
            v1.Append(v2[0]);
            findPermutations(v1, v2.Remove(0, 1), n, result);
            findPermutations(v1, v2.Remove(0, 1).Reverse().ToString(), n, result);

            throw new NotImplementedException();
        }
        [HttpPost]
        public int StringToInt(string input)
        {
            int result = 0;
            foreach(var a in input)
            {
                int value = a - '0';
                result *= 10;
                result += value;
            }
            return result;
        }
    }
}