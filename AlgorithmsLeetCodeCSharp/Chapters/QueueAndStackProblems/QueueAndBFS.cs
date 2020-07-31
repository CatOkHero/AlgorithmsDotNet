using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsLeetCodeCSharp.Chapters.QueueAndStackProblems
{
	// https://leetcode.com/explore/learn/card/queue-stack/231/practical-application-queue/1376/
	public class QueueAndBFS
	{
		// https://leetcode.com/explore/learn/card/queue-stack/231/practical-application-queue/1371/
		// Perfect Squares
		// TODO: FIX, DOESNT" WORK
		public int NumSquares(int n)
		{
			if (n == 0)
			{
				return n;
			}

			int sqrt = (int)Math.Sqrt(n);
			var queue = new Queue<int>();

			int minCount = int.MaxValue;
			for (int i = sqrt; i >= 1 ; i--)
			{
				var number = i;
				var count = 0;
				queue.Enqueue(n);
				while (queue.Count != 0)
				{
					var root = queue.Dequeue();
					var change = root % number;
					var square = number * number;
					var prevSquare = 0;
					if (number > 1)
					{
						prevSquare = (number - 1) * (number - 1);
					}

					var subtraction = root - square;
					if (change == 0 && subtraction >= square && subtraction % square == 0)
					{
						count++;
						queue.Enqueue(subtraction);
						continue;
					}
					else if (change == 1 && subtraction >= square && subtraction % square == 1)
					{
						count++;
						queue.Enqueue(subtraction);
						continue;
					}
					else if (subtraction == prevSquare && prevSquare != 1)
					{
						number--;
						queue.Enqueue(subtraction);
						continue;
					}
					else if (subtraction == 0)
					{
						count++;
						minCount = count < minCount ? count : minCount;
						break;
					}
					else if (subtraction < 0)
					{
						number--;
						queue.Enqueue(root);
						continue;
					} else if(subtraction > square)
					{
						count++;
						queue.Enqueue(subtraction);
						continue;
					} 

					count++;
					if (subtraction < 0)
					{
						minCount = count < minCount ? count : minCount;
						break;
					}

					root = subtraction;
					number--;
					if (number == 1)
					{
						count += root;
						minCount = count < minCount ? count : minCount;
						break;
					}
					queue.Enqueue(root);
				}
			}

			return minCount;
		}


		// https://leetcode.com/explore/learn/card/queue-stack/231/practical-application-queue/1374/
		// Number of Islands
		public int NumIslandsWithoutQueue(char[][] grid)
		{
			if (grid == null)
			{
				return 0;
			}

			int rowLength = grid.Length;
			if(rowLength == 0)
			{
				return 0;
			}

			int columnLength = grid[0].Length;
			int islands = 0;
			for (int i = 0; i < rowLength; i++)
			{
				for (int j = 0; j < columnLength; j++)
				{
					var charValue = grid[i][j];
					var root = new KeyValuePair<int, int>(i, j);
					if (charValue == '1')
					{
						islands++;
						grid[root.Key][root.Value] = '0';

						RecursionCall(root, rowLength, columnLength, grid);
					}
				}
			}

			return islands;
		}

		private void RecursionCall(KeyValuePair<int, int> root, int rowLength, int columnLength, char[][] grid)
		{
			int up = root.Key - 1;
			int down = root.Key + 1;
			int left = root.Value - 1;
			int right = root.Value + 1;

			if (up >= 0 && up < rowLength)
			{
				var upValue = grid[up][root.Value];
				var upKeyValuePair = new KeyValuePair<int, int>(up, root.Value);
				if(upValue == '1')
				{
					grid[up][root.Value] = '0';
					RecursionCall(upKeyValuePair, rowLength, columnLength, grid);
				}
			}

			if (down >= 0 && down < rowLength)
			{
				var downValue = grid[down][root.Value];
				var downKeyValuePair = new KeyValuePair<int, int>(down, root.Value);
				if (downValue == '1')
				{
					grid[down][root.Value] = '0';
					RecursionCall(downKeyValuePair, rowLength, columnLength, grid);
				}
			}

			if (left >= 0 && left < columnLength)
			{
				var leftValue = grid[root.Key][left];
				var leftKeyValuePair = new KeyValuePair<int, int>(root.Key, left);
				if (leftValue == '1')
				{
					grid[root.Key][left] = '0';
					RecursionCall(leftKeyValuePair, rowLength, columnLength, grid);
				}
			}

			if (right >= 0 && right < columnLength)
			{
				var rightValue = grid[root.Key][right];
				var rightKeyValuePair = new KeyValuePair<int, int>(root.Key, right);
				if (rightValue == '1')
				{
					grid[root.Key][right] = '0';
					RecursionCall(rightKeyValuePair, rowLength, columnLength, grid);
				}
			}
		}

		Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
		public int NumIslandsWithQueue(char[][] grid)
		{
			if (grid == null)
			{
				return 0;
			}

			int rowLength = grid.Length;
			if (rowLength == 0)
			{
				return 0;
			}

			int columnLength = grid[0].Length;
			int islands = 0;
			for (int i = 0; i < rowLength; i++)
			{
				for (int j = 0; j < columnLength; j++)
				{
					var charValue = grid[i][j];
					var root = new KeyValuePair<int, int>(i, j);
					if (charValue == '1')
					{
						grid[root.Key][root.Value] = '0';
						queue.Enqueue(new KeyValuePair<int, int>(i, j));
						GetSons(i, j, grid);

						while (queue.Count > 0)
						{
							var child = queue.Dequeue();
							if(grid[child.Key][child.Value] == '1')
							{
								grid[child.Key][child.Value] = '0';
								GetSons(child.Key, child.Value, grid);
							}
						}

						islands++;
					}
				}
			}

			return islands;
		}

		private void GetSons(int i, int j, char[][] grid)
		{
			int up = i - 1;
			int down = i + 1;
			int left = j - 1;
			int right = j + 1;
			if (up >= 0 && up < grid.Length && grid[up][j] == '1')
			{
				queue.Enqueue(new KeyValuePair<int, int>(up, j));
			}

			if (down >= 0 && down < grid.Length && grid[down][j] == '1')
			{
				queue.Enqueue(new KeyValuePair<int, int>(down, j));
			}

			if (left >= 0 && left < grid[0].Length && grid[i][left] == '1')
			{
				queue.Enqueue(new KeyValuePair<int, int>(i, left));
			}

			if (right >= 0 && right < grid[0].Length && grid[i][right] == '1')
			{
				queue.Enqueue(new KeyValuePair<int, int>(i, right));
			}
		}
	}
}
