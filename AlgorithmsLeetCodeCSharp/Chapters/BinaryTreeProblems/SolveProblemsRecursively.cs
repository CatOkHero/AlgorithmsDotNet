namespace AlgorithmsLeetCodeCSharp.Chapters.BinaryTreeProblems
{
	public class SolveProblemsRecursively
    {
        // https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/536/
        // Symmetric Tree
        public bool IsSymmetric(TreeNode root)
        {
            return AreLeavesSymetric(root, root);
        }

        private bool AreLeavesSymetric(TreeNode left, TreeNode right)
        {
            if(left == null && right == null)
			{
                return true;
			} else if(left == null || right == null) 
            {
                return false;
			}

            var result = left.val == right.val;
            var leftResult = AreLeavesSymetric(left.left, right.right);
            var rightResult = AreLeavesSymetric(left.right, right.left);
            return result && leftResult && rightResult;
		}


        // https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/537/
        // Path Sum
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.val == sum && (root.left == null) && (root.right == null))
            {
                return true;
            }

            var left = false;
            var right = false;
            if (root.left != null)
            {
                left = HasPathSumRecursion(root.left, sum, root.val);
            }

            if (root.right != null)
            {
                right = HasPathSumRecursion(root.right, sum, root.val);
            }

            return left || right;
        }

        private bool HasPathSumRecursion(TreeNode root, int sum, int rootSum)
        {
            int leaveSum = root.val + rootSum;
            if (leaveSum == sum && root.left == null && root.right == null)
            {
                return true;
            }

            var left = false;
            var right = false;
            if (root.left != null)
            {
                left = HasPathSumRecursion(root.left, sum, leaveSum);
            }

            if (root.right != null)
            {
                right = HasPathSumRecursion(root.right, sum, leaveSum);
            }

            return left || right;
        }
    }
}
