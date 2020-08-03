namespace AlgorithmsLeetCodeCSharp.Contests.MonthlyContests
{
    // https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/
    public class AugustLeetCondingChallenge
    {
        // https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3411/
        // Valid Palindrome
        public bool IsPalindrome(string s)
        {
            if (s == null || s == string.Empty)
            {
                return true;
            }

            s = s.ToUpper();
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if ((s[i] < 65 || s[i] > 90) && (s[i] > 57 || s[i] < 48))
                {
                        i++;
                        continue;
                }

                if ((s[j] < 65 || s[j] > 90) && (s[j] > 57 || s[j] < 48))
                {
                    j--;
                    continue;
                }

                if (s[i] != s[j])
                {
                    return false;
                }

                i++;
                j--;
            }

            return true;
        }

        // https://leetcode.com/explore/featured/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3409/
        // Detect Capital
        public bool DetectCapitalUse(string word)
        {
            bool firstCondition = word[0] < 96;
            bool secondCondition = word[0] > 96;
            bool thirdCondition = word[0] < 96;
            for (int i = 1; i < word.Length; i++)
            {
                if (firstCondition)
                {
                    firstCondition = word[i] < 96;
                }

                if (secondCondition)
                {
                    secondCondition = word[i] > 96;
                }

                if (thirdCondition)
                {
                    thirdCondition = word[i] > 96;
                }
            }

            return firstCondition || secondCondition || thirdCondition;
        }
    }
}
