namespace AlgorithmsLeetCodeCSharp.Chapters.ArrayAndString
{
	// https://leetcode.com/explore/learn/card/array-and-string/202/introduction-to-2d-array
	public class IntroductionTo2DArray
	{
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
