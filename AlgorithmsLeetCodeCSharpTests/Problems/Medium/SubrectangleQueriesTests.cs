using AlgorithmsLeetCodeCSharp.Problems.Medium;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharpTests.Problems.Medium
{
	public class SubrectangleQueriesTests
	{
		SubrectangleQueries solution = null;

		[Test]
		public void Check_SubrectangleQueries_BaseCase()
		{
            var methods = new string[] {
                "SubrectangleQueries", "getValue", "updateSubrectangle", "getValue", "getValue", "updateSubrectangle", "getValue", "getValue"
            };

            // [[[1,2,1],[4,3,4],[3,2,1],[1,1,1]]],
            var paramethers = @"[[0,2],[0,0,3,2,5],[0,2],[3,1],[3,0,3,2,10],[3,1],[0,2]]";
            var results = @"[1,null,5,5,null,10,5]";
            AssertEx.NoExceptionThrown<NullReferenceException>(() =>
            {
                ParseWithReflection(solution, methods, paramethers, results);
            });
        }

        private void ParseWithReflection(SubrectangleQueries solution, string[] methods, string paramethersJson, string resultsJson)
        {
            var paramethers = JsonConvert.DeserializeObject<List<int[]>>(paramethersJson);
            var results = JsonConvert.DeserializeObject<List<object>>(resultsJson);

            solution = new SubrectangleQueries(new int[][] {
                        new int[] {1, 2, 1},
                        new int[] {4, 3, 4},
                        new int[] {3, 2, 1},
                        new int[] {1, 1, 1}
            });

            var thisType = solution.GetType();
            int index = -1;
            foreach (var method in methods)
            {
                if(index == -1)
				{
                    index++;
                    continue;
				}

                char[] arr = method.ToCharArray();
                arr[0] = char.ToUpper(arr[0]);
                var theMethod = thisType.GetMethod(new string(arr));
                var obj = new object?[0] { };
                if(paramethers[index].Length > 1)
				{
                    obj = new object?[paramethers[index].Length];
                    for (int i = 0; i < paramethers[index].Length; i++)
					{
                        obj[i] = paramethers[index]?[i];
                    }
				}

                var result = theMethod.Invoke(solution, obj);
                if (results[index] != null)
                {
                    if (results[index].GetType() == typeof(int))
                    {
                        int res = (int)results[index];
                        Assert.AreEqual(res, (int)result);
                        if (res != (int)result)
                        {
                            throw new NullReferenceException("Failed");
                        }
                    }

                    if (results[index].GetType() == typeof(long))
                    {
                        long res = (long)results[index];
                        Assert.AreEqual(res, (int)result);
                        if (res != (int)result)
                        {
                            throw new NullReferenceException("Failed");
                        }
                    }

                    if (results[index].GetType() == typeof(bool))
                    {
                        bool res = (bool)results[index];
                        Assert.AreEqual(res, (bool)result);
                        if (res != (bool)result)
                        {
                            throw new NullReferenceException("Failed");
                        }
                    }
                }

                index++;
            }
        }
        //["SubrectangleQueries","getValue","updateSubrectangle","getValue","getValue","updateSubrectangle","getValue","getValue"]
        //[[[[1,2,1],[4,3,4],[3,2,1],[1,1,1]]],[0,2],[0,0,3,2,5],[0,2],[3,1],[3,0,3,2,10],[3,1],[0,2]]
        //[null,1,null,5,5,null,10,5]
    }
}
