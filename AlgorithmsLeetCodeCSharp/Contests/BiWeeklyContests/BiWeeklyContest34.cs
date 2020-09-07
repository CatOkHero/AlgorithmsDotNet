namespace AlgorithmsLeetCodeCSharp.Contests.BiWeeklyContests
{
    // https://leetcode.com/contest/biweekly-contest-34
    public class BiWeeklyContest34
    {
        // https://leetcode.com/problems/matrix-diagonal-sum/
        // 1572. Matrix Diagonal Sum
        public int DiagonalSum(int[][] mat)
        {
            if (mat == null || mat.Length == 0)
            {
                return 0;
            }

            if (mat.Length == 1)
            {
                return mat[0][0];
            }

            if (mat.Length < 3)
            {
                return mat[0][0] + mat[0][1] + mat[1][0] + mat[1][1];
            }

            return Helper(mat, 0, 0, mat.Length - 1, mat.Length - 1, 1);

        }

        private int Helper(int[][] mat, int i, int j, int iEnd, int jEnd, int length)
        {
            if (length == mat.Length || i > iEnd)
            {
                return 0;
            }

            if (i == iEnd)
            {
                return mat[i][j];
            }

            int leftTop = mat[i][j];
            int leftBottom = mat[i][jEnd];
            int rightTop = mat[iEnd][j];
            int rightBottom = mat[iEnd][jEnd];
            i++;
            j++;
            iEnd--;
            jEnd--;
            length++;
            return leftTop + leftBottom + rightTop + rightBottom + Helper(mat, i, j, iEnd, jEnd, length);
        }
    }
}
