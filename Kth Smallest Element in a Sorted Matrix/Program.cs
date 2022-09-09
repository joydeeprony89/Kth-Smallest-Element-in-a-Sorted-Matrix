using System;

namespace Kth_Smallest_Element_in_a_Sorted_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[3][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            Solution s = new Solution();
            var answer = s.KthSmallest(matrix, 8);
            Console.WriteLine(answer);
        }
    }

    public class Solution
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            int n = matrix.Length;
            // first element
            int l = matrix[0][0];
            // last element
            int r = matrix[n - 1][n - 1];
            while(l <= r)
            {
                int mid = l + (r - l) / 2;
                // count no of elements 
                int count = GetLessEqual(matrix, mid);
                if (count < k) l = mid + 1;
                else r = mid - 1;
            }

            return l;
        }

        private int GetLessEqual(int[][] matrix, int mid)
        {
            int count = 0;
            int n = matrix.Length;
            // last row
            int i = n - 1;
            // first column
            int j = 0;
            // check boundary, i should run till the first row and column till last column
            while (i >= 0 && j < n)
            {
                int current = matrix[i][j];
                // if the current element bigger than mid, we need to move to previous row as the column values are sorted
                if (current > mid) i--;
                // if the current element is smaller than mid, we can move to right(next column) as the row values are sorted.
                else
                {
                    // magic happen here.
                    count += i + 1;
                    j++;
                }
            }
            return count;
        }
    }
}
