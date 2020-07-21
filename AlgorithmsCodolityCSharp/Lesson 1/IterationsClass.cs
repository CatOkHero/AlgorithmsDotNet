using System;

namespace AlgorithmsCodolityCSharp.Lesson1
{
	public class IterationsClass
    {
        public int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            char[] bytes = Convert.ToString(N, 2).ToCharArray();

            int maxNumberOfZeros = 0;
            int currentNumberOfZeros = 0;
            for (int i = 1; i < bytes.Length; i++)
            {
                if (bytes[i] == '1' && currentNumberOfZeros > 0)
                {
                    if (maxNumberOfZeros < currentNumberOfZeros)
                    {
                        maxNumberOfZeros = currentNumberOfZeros;
                    }

                    currentNumberOfZeros = 0;
                    continue;
                }

                if (bytes[i] == '0' && (currentNumberOfZeros > 0 || bytes[i - 1] == '1'))
                {
                    currentNumberOfZeros++;
                }
            }

            return maxNumberOfZeros;
        }
    }
}
