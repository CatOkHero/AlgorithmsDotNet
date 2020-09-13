using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharp.Contests.MonthlyContests
{
    // https://leetcode.com/explore/featured/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/
    public class SeptemberLeetCodingChallange
    {
        // https://leetcode.com/explore/featured/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3458/
        // TODO: REALLY! REALLY! Don't like this code)
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return new int[1][] {
                    new int[2] { newInterval[0], newInterval[1] }
                };
            }

            if (newInterval == null || newInterval.Length == 0)
            {
                return intervals;
            }

            int i1 = -1;
            int i2 = -1;

            var result = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                if (i2 != -1)
                {
                    result.Add(new int[2] { intervals[i][0], intervals[i][1] });
                    continue;
                }

                if (intervals[i][0] > newInterval[0]
                  && i1 == -1)
                {
                    i1 = -2;
                }

                if (intervals[i][0] <= newInterval[0]
                  && intervals[i][1] >= newInterval[0])
                {
                    i1 = i;
                }

                if (i1 == -1)
                {
                    result.Add(new int[2] { intervals[i][0], intervals[i][1] });
                }
                else
                {
                    if (intervals[i][0] > newInterval[1]
                        && i1 >= 0)
                    {
                        i2 = i;
                        result.Add(new int[2] { intervals[i1][0], newInterval[1] });
                        result.Add(new int[2] { intervals[i][0], intervals[i][1] });
                    }  else if (intervals[i][0] > newInterval[1]
                                && i1 == -2)
                    {
                        i2 = i;
                        result.Add(new int[2] { newInterval[0], newInterval[1] });
                        result.Add(new int[2] { intervals[i][0], intervals[i][1] });
                    }
                    else if (intervals[i][0] <= newInterval[1]
                          && intervals[i][1] >= newInterval[1])
                    {
                        i2 = i;

                        if (i1 == -2)
                        {
                            result.Add(new int[2] { newInterval[0], intervals[i][1] > newInterval[1] ? intervals[i][1] : newInterval[1] });
                            continue;
                        }

                        result.Add(new int[2] { intervals[i1][0], intervals[i][1] });
                    }
                }
            }

            if (i1 >= 0 && i2 == -1)
            {
                result.Add(new int[2] { intervals[i1][0], newInterval[1] });
            }

            if (i1 == -1 && i2 == -1)
            {
                result.Add(new int[2] { newInterval[0], newInterval[1] });
            }

            if(i1 == -2 && i2 == -1)
            {
                if(intervals[intervals.Length -1][1] < newInterval[1])
                {
                    result.Add(newInterval);
                } else
                {
                    result.Add(newInterval);
                    result.AddRange(intervals);
                }
            }

            return result.ToArray();
        }
    }
}
