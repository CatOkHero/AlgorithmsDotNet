using System;

namespace AlgorithmsLeetCodeCSharp.Chapters.ArrayAndString
{
    // https://leetcode.com/explore/learn/card/array-and-string/203/introduction-to-string/
    public class IntroductionToString
    {

        public string LongestCommonPrefix(string[] strs)
        {
            string pattern = string.Empty;
            int longestPatternLength = pattern.Length;
            for (int i = 1; i < strs.Length; i++)
            {
                string firstWord = strs[i - 1];
                string secondWord = strs[i];
                int patternLength = 0;
                for (int j = 0; j < firstWord.Length; j++)
                {
                    for (int z = 0; z < secondWord.Length; z++)
                    {
                        if (firstWord[j] == secondWord[z])
                        {
                            patternLength++;
                        }
                        else if (firstWord[j] != secondWord[z] && patternLength > longestPatternLength)
                        {
                            pattern = firstWord.Substring(j - patternLength + 1, patternLength);
                            longestPatternLength = patternLength;
                        }
                        else
                        {
                            patternLength = 0;
                        }
                    }
                }
            }

            return pattern;
        }

        // https://leetcode.com/explore/learn/card/array-and-string/203/introduction-to-string/1161
        // Implement strStr()
        // N * M
        public int StrStr(string haystack, string needle)
        {
            if (needle == String.Empty)
            {
                return 0;
            }

            if (haystack.Length < needle.Length)
            {
                return -1;
            }

            int index = -1;
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] != needle[0])
                {
                    continue;
                }

                int j = i;
                index = i;
				for (int z = 0; z < needle.Length; z++)
				{
                    if(haystack[j] == needle[z] && j < haystack.Length)
					{
                        j++;
					} else
					{
                        index = -1;
                        break;
					}
				}

                if(index != -1)
				{
                    return index;
				}
            }

            return index;
        }
    }
}
