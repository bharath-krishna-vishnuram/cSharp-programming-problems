using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    public class TwoDimensionalArraysController : CodingControllerBase
    {

        /// <summary>
        /// Given an integer A, generate a square matrix filled with elements from 1 to A2 in spiral order.
        /// </summary>
        /// <returns>IntegerReturn a 2-D matrix which consists of the elements in spiral order.</returns>   
        [HttpPost]
        public List<List<int>> SpiralOrderMatrix(int A)
        {
            List<List<int>> result = new List<List<int>>();
            int[][] temp = new int[A][];

            for (int i = 0; i < A; i++)
                temp[i] = new int[A];
            int left = 0, right = A - 1, top = 0, down = A - 1, count = 1;
            while (left <= right)
            {
                for (int j = left; j <= right; j++)
                {
                    temp[top][j] = count++;
                    // Console.WriteLine(left + " " + right + " " + top + " " + j + " " + count + " " + temp[top][j]);
                }
                top++;
                for (int i = top; i <= down; i++)
                {
                    temp[i][right] = count++;
                    // Console.WriteLine(top + " " + down + " " + i + " " + right + " " + count + " " + temp[i][right]);
                }
                right--;
                for (int j = right; j >= left; j--)
                {
                    temp[down][j] = count++;
                    // Console.WriteLine(right + " " + left + " " + down + " " + j + " " + count + " " + temp[down][j]);
                }
                down--;
                for (int i = down; i >= top; i--)
                {
                    temp[i][left] = count++;
                    // Console.WriteLine(down + " " + top + " " + i + " " + left + " " + count + " " + temp[i][left]);
                }
                left++;
            }
            for (int i = 0; i < A; i++)
                result.Add(new List<int>(temp[i]));

            return result;
        }

        /// <summary>
        /// You are given a n x n 2D matrix A representing an image, Rotate the image by 90 degrees 
        /// </summary>
        /// <returns>Return the 2D rotated matrix.</returns>   
        [HttpPost]
        public List<List<int>> RotateMatrix(List<List<int>> A)
        {
            int rows = A.Count;
            int columns = A.Count;//As it is square
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = i; j < columns - 1 - i; j++)
                {
                    int leftTop = A[i][j], rightTop = A[j][columns - 1 - i], bottomRight = A[rows - 1 - i][columns - 1 - i - j], bottomLeft = A[rows - 1 - j][i];
                    A[i][j] = bottomLeft;
                    A[j][columns - 1 - i] = leftTop;
                    A[rows - 1 - i][columns - 1 - i - j] = rightTop;
                    A[rows - 1 - j][i] = bottomRight;
                }
            }
            return A;
        }

        /// <summary>
        /// You are given a n x n 2D matrix input, make all the elements in a row or column zero if the A[i][j] = 0
        /// </summary>
        /// <returns>Return the 2D rotated matrix.</returns>   
        [HttpPost]
        public int[][] ZeroRowColumnConvert(int[][] input)
        {
            int rowsCnt = input.Count();
            int colsCnt = input[0].Count();
            HashSet<int> zeroCols = new HashSet<int>();
            int[][] output = new int[rowsCnt][];
            for (int i = 0; i < rowsCnt; i++)
            {
                bool hasZero = false;
                output[i] = new int[colsCnt];
                for (int j = 0; j < colsCnt; j++)
                {
                    if (input[i][j] == 0)
                    {
                        zeroCols.Add(j);
                        hasZero = true;
                    }
                    else
                        output[i][j] = input[i][j];
                }
                if (hasZero)
                    output[i] = new int[colsCnt];
            }
            for (int i = 0; i < rowsCnt; i++)
                foreach (var j in zeroCols)
                    output[i][j] = 0;
            return output;
        }
    }
}
