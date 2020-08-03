using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharp.Chapters.ArrayAndString
{
	// https://leetcode.com/explore/learn/card/array-and-string/202/introduction-to-2d-array
	public class IntroductionTo2DArray
	{
		// https://leetcode.com/explore/learn/card/array-and-string/202/introduction-to-2d-array/1170/
		// Pascal's Triangle
		public IList<IList<int>> Generate(int numRows)
		{
			if(numRows == 0)
			{
				return new List<IList<int>>();
			}

			var triangle = new List<IList<int>>()
			{
				new List<int>{ 1 }
			};

			for (int i = 1; i < numRows; i++)
			{
				var row = new List<int>() { 1 };
				for (int j = 1; j <= i - 1; j++)
				{
					row.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
				}

				row.Add(1);
				triangle.Add(row);
			}

			return triangle;
		}

		// https://leetcode.com/explore/learn/card/array-and-string/202/introduction-to-2d-array/1168/
		// Spiral Matrix
		public IList<int> SpiralOrder(int[][] matrix)
		{
			var list = new List<int>();
			if (matrix.Length == 0 || matrix[0].Length == 0)
			{
				return list;
			}

			int index = 0;
			int i = 0;
			int j = 0;
			int contraction = 0;
			int length = matrix.Length * matrix[0].Length;

			bool reachedRowRightEnd = false;
			bool reachedColDownEnd = false;
			bool reachedRowLeftEnd = false;
			bool reachedColUpEnd = false;
			bool shouldScip = false;

			while (index < length)
			{
				if(!shouldScip)
				{
					list.Add(matrix[i][j]);
				}

				shouldScip = false;
				if(!reachedRowRightEnd)
				{
					j++;
					if(j == matrix[0].Length - 1 - contraction 
						&& contraction != 0)
					{
						reachedRowRightEnd = true;
					}

					if(j == matrix[0].Length - 1)
					{
						reachedRowRightEnd = true;
					}

					if(j == matrix[0].Length)
					{
						j--;
						shouldScip = true;
						reachedRowRightEnd = true;
						continue;
					}
				} else if (!reachedColDownEnd)
				{
					i++;
					if (i == matrix.Length - 1 - contraction
						&& contraction != 0)
					{
						reachedColDownEnd = true;
					}

					if (i == matrix.Length - 1)
					{
						reachedColDownEnd = true;
					}

					if (i == matrix.Length)
					{
						i--;
						shouldScip = true;
						reachedColDownEnd = true;
						continue;
					}
				} else if (!reachedRowLeftEnd)
				{
					j--;
					if (j == contraction
						&& contraction != 0)
					{
						j++;
						if(index + 1 == length - 1)
						{
							j--;
						}

						reachedRowLeftEnd = true;
					}

					if (j == contraction)
					{
						reachedRowLeftEnd = true;
					}

					if (j < 0)
					{
						j++;
						shouldScip = true;
						reachedRowLeftEnd = true;
						continue;
					}
				} else if (!reachedColUpEnd)
				{
					i--;
					if(contraction == i)
					{
						i++;
						if (index + 1 == length - 1)
						{
							i--;
						}

						contraction++;
						shouldScip = true;
						reachedRowRightEnd = false;
						reachedColDownEnd = false;
						reachedRowLeftEnd = false;
						reachedColUpEnd = false;
						continue;
					}

					if (i < 0)
					{
						i++;
						reachedColUpEnd = true;
						shouldScip = true;
					}
				}

				index++;
			}

			return list;
		}

		// https://leetcode.com/explore/learn/card/array-and-string/202/introduction-to-2d-array/1167/
		// Diagonal Traverse
		public int[] FindDiagonalOrder(int[][] matrix)
		{
			if (matrix == null || matrix.Length == 0)
			{
				return new int[] { };
			}

			bool upRight = false;
            bool downLeft = true;
            int i = 0;
            int j = 0;
			int length = matrix.Length * matrix[0].Length;
			int rowLength = matrix.Length - 1;
			int columnLength = matrix[0].Length - 1;
			int[] diagonal = new int[length];
			diagonal[0] = matrix[i][j];
			for (int index = 1; index < length; index++)
			{
				if (upRight)
				{
					if (i != rowLength)
					{
						i++;
						diagonal[index] = matrix[i][j];
					}
					else
					{
						j++;
						diagonal[index] = matrix[i][j];
					}

					while (i >= 0 
						&& j < columnLength
						&& i <= rowLength)
					{
						if (i == 0)
						{
							break;
						}

						i--;
						j++;
						index++;
						diagonal[index] = matrix[i][j];
					}

					downLeft = true;
					upRight = false;
					continue;
				}

				if (downLeft)
				{
					if(j != columnLength)
					{
						j++;
						diagonal[index] = matrix[i][j];
					} else
					{
						i++;
						diagonal[index] = matrix[i][j];
					}

					while (j >= 0 
						&& i < rowLength 
						&& j <= columnLength)
					{
						if(j == 0)
						{
							break;
						}

						j--;
						i++;
						index++;
						diagonal[index] = matrix[i][j];
					}

					downLeft = false;
					upRight = true;
				}
			}

			return diagonal;
        }
    }
}
