using AlgorithmsLeetCodeCSharp.Chapters.BinaryTreeProblems;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.BinaryTreeTests
{
    public class SolveProblemsRecursivelyTests
    {
        public SolveProblemsRecursively solution = new SolveProblemsRecursively();
        TreeNode node9 = null;
        TreeNode node8 = null;
        TreeNode node7 = null;
        TreeNode node6 = null;
        TreeNode node5 = null;
        TreeNode node4 = null;
        TreeNode node3 = null;
        TreeNode node2 = null;
        TreeNode node1 = null;

        [Test]
        public void Check_HasPathSum_IsTrue_BaseCase()
        {
            // [5,4,8,11,null,13,4,7,2,null,null,null,1]
            // 22
            node9 = new TreeNode(1);
            node8 = new TreeNode(2);
            node7 = new TreeNode(7);
            node6 = new TreeNode(4, null, node9);
            node5 = new TreeNode(13);
            node4 = new TreeNode(11, node7, node8);
            node3 = new TreeNode(8, node5, node6);
            node2 = new TreeNode(4, node4);
            node1 = new TreeNode(5, node2, node3);

            var hasPathSum1 = solution.HasPathSum(node1, 22);

            Assert.IsTrue(hasPathSum1);
        }

        [Test]
        public void Check_HasPathSum_IsFalse_FirstFailedCase()
        {
            // [1,2,null,3,null,4,null,5]
            // 6
            node5 = new TreeNode(5);
            node4 = new TreeNode(4, node5, null);
            node3 = new TreeNode(3, node4, null);
            node2 = new TreeNode(2, node3, null);
            node1 = new TreeNode(1, node2, null);

            var hasPathSum2 = solution.HasPathSum(node1, 6);

            Assert.IsFalse(hasPathSum2);
        }

        [Test]
        public void Check_IsSymmetric__IsTrue_BaseCase()
        {
            // [1,2,2,3,4,4,3]
            node7 = new TreeNode(3);
            node6 = new TreeNode(4);
            node5 = new TreeNode(4);
            node4 = new TreeNode(3);
            node3 = new TreeNode(2, node6, node7);
            node2 = new TreeNode(2, node4, node5);
            node1 = new TreeNode(1, node2, node3);

            var isSymmetric1 = solution.IsSymmetric(node1);

            Assert.IsTrue(isSymmetric1);
        }

        [Test]
        public void Check_IsSymmetric_IsTrue_FirstFailedCase()
        {
            // [1,2,2,null,3,3]
            node5 = new TreeNode(3);
            node4 = new TreeNode(3);
            node3 = new TreeNode(2, node5, null);
            node2 = new TreeNode(2, null, node4);
            node1 = new TreeNode(1, node2, node3);

            var isSymmetric2 = solution.IsSymmetric(node1);

            Assert.IsTrue(isSymmetric2);
        }

        [Test]
        public void Check_IsSymmetric_IsFalse_SecondFailedCase()
        {
            // [1,2,2,null,3,null,3]
            node5 = new TreeNode(3);
            node4 = new TreeNode(3);
            node3 = new TreeNode(2, null, node5);
            node2 = new TreeNode(2, null, node4);
            node1 = new TreeNode(1, node2, node3);

            var isSymmetric3 = solution.IsSymmetric(node1);

            Assert.IsFalse(isSymmetric3);
        }

        [Test]
        public void Check_IsSymmetric_IsFalse_ThirdFailedCase()
        {
            // [2,97,97,null,47,80,null,-7,null,null,-7]
            node7 = new TreeNode(-7);
            node6 = new TreeNode(-7);
            node5 = new TreeNode(80, null, node7);
            node4 = new TreeNode(47, node6, null);
            node3 = new TreeNode(97, node5, null);
            node2 = new TreeNode(97, null, node4);
            node1 = new TreeNode(1, node2, node3);

            var isSymmetric4 = solution.IsSymmetric(node1);

            Assert.IsFalse(isSymmetric4);
        }
    }
}
