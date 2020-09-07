using System;

namespace AlgorithmsLeetCodeCSharp.Contests.WeeklyContests
{
    // https://leetcode.com/contest/weekly-contest-205
    public class WeeklyContest205
    {
        private char[] alphabet = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        // https://leetcode.com/contest/weekly-contest-205/problems/replace-all-s-to-avoid-consecutive-repeating-characters/
        public string ModifyString(string s)
        {
            if (s.Length == 1)
            {
                return s[0] == '?' ? new string(new char[1] { alphabet[0] }) : s;
            }

            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (s[i] == '?' && s[i + 1] == '?')
                {
                    if (i == 0)
                    {
                        chars[i] = 'a';
                    }
                    else
                    {
                        int indexOf = Array.IndexOf(alphabet, chars[i - 1]);
                        if (indexOf == 25)
                        {
                            indexOf = 0;
                        }

                        chars[i] = alphabet[indexOf + 1];
                    }
                }
                else if (s[i] == '?' && s[i + 1] != '?')
                {
                    int indexOfLast = Array.IndexOf(alphabet, chars[i + 1]);
                    if (i == 0)
                    {
                        if (indexOfLast == 0)
                        {
                            chars[i] = alphabet[1];
                        }
                        else
                        {
                            chars[i] = alphabet[indexOfLast - 1];
                        }
                    }
                    else
                    {
                        int indexOfFirst = Array.IndexOf(alphabet, chars[i - 1]);
                        int index = -1;
                        if (indexOfLast > indexOfFirst)
                        {
                            if (indexOfLast - indexOfFirst == 0 ||
                                indexOfLast - indexOfFirst == 1)
                            {
                                index = indexOfFirst - 1;
                            }
                            else
                            {
                                index = (indexOfLast + indexOfFirst) / 2;
                            }
                        }
                        else
                        {
                            if (indexOfFirst - indexOfLast == 0 ||
                                indexOfFirst - indexOfLast == 1)
                            {
                                index = indexOfLast - 1;
                            }
                            else
                            {
                                index = (indexOfLast + indexOfFirst) / 2;
                            }
                        }

                        if (index < 0)
                        {
                            index = 25;
                        }
                        else if (index > 25)
                        {
                            index = 0;
                        }

                        chars[i] = alphabet[index];
                    }
                }
            }

            if (chars[chars.Length - 1] == '?')
            {
                int indexOf = Array.IndexOf(alphabet, chars[chars.Length - 2]);
                if (indexOf == 0)
                {
                    chars[chars.Length - 1] = alphabet[1];
                }
                else
                {
                    chars[chars.Length - 1] = alphabet[indexOf - 1];
                }
            }

            return new string(chars);
        }

        // https://leetcode.com/contest/weekly-contest-205/problems/number-of-ways-where-square-of-number-is-equal-to-product-of-two-numbers/
        // 5508. Number of Ways Where Square of Number Is Equal to Product of Two Numbers
        public int NumTriplets(int[] nums1, int[] nums2)
        {
            int count = 0;
            int i = 0;
            int j = 0;
            int k = 1;
            int nums2Length = nums2.Length;
            int nums1Length = nums1.Length;

            if (nums2Length > 1)
            {
                while (i < nums1.Length)
                {
                    long square1 = (nums1[i] * nums1[i]) / 10000000007;
                    long numsJK1 = (nums2[j] * nums2[k]) / 10000000007;

                    if (square1 == numsJK1)
                    {
                        count++;
                    }
                    k++;

                    if (k >= nums2Length)
                    {
                        j++;
                        k = j + 1;
                    }

                    if (k >= nums2Length || j >= nums2Length - 1)
                    {
                        i++;
                        j = 0;
                        k = 1;
                    }
                }
            }

            i = 0;
            j = 0;
            k = 1;
            if (nums1Length > 1)
            {
                while (i < nums2.Length)
                {
                    long square2 = (nums2[i] * nums2[i]) / 10000000007;
                    long numsJK2 = (nums1[j] * nums1[k]) / 10000000007;
                    if (square2 == numsJK2)
                    {
                        count++;
                    }

                    k++;

                    if (k >= nums1Length)
                    {
                        j++;
                        k = j + 1;
                    }

                    if (k >= nums1Length || j >= nums1Length - 1)
                    {
                        i++;
                        j = 0;
                        k = 1;
                    }
                }
            }

            return count;
        }
    }
}
