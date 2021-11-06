#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'miniMaxSum' function below.
#
# The function accepts INTEGER_ARRAY arr as parameter.
#

def miniMaxSum(arr):
    # Write your code here
    arr = sorted(arr)
    length = len(arr)
    if length != 0:
        arr_sum = sum(arr, 0)
        min_sum = arr_sum - arr[length - 1]
        max_sum = arr_sum - arr[0]
        print(min_sum, max_sum)
    else:
        print(0, 0)

# if __name__ == '__main__':
    # arr = list(map(int, input().rstrip().split()))
    # miniMaxSum(arr)

def staircase(n):
    # Write your code here
    strings = [" " for i in range(0, n)]
    for i in range(0, n):
        strings[n - i-1] = "#"
        print(''.join(strings))

# if __name__ == '__main__':
    # n = int(input().strip())

    # staircase(n)

def birthdayCakeCandles(candles):
    # Write your code here
    max_candle = -1
    max_count = 0
    for i in candles:
        if i > max_candle:
            max_candle = i
            max_count = 1
        elif i == max_candle:
            max_count += 1
        else:
            ()
            
    return max_count

# if __name__ == '__main__':
    # fptr = open(os.environ['OUTPUT_PATH'], 'w')
    # candles_count = int(input().strip())
    # candles = list(map(int, input().rstrip().split()))
    # result = birthdayCakeCandles(candles)
    # fptr.write(str(result) + '\n')
    # fptr.close()

def timeConversion(s):
    # Write your code here
    ending = s[8:10]
    starting = int(s[0:2])
    if ending == "PM":
        if starting < 12:
            starting = 12 + starting
            start = str(starting)
            end = s[2:8]
            if starting < 10:
                return "0" + start + end
            else:
                return start + end
        else:
            return str(s[0:8])
    else:
        if starting == 12:
            return "00" + s[2:8]
        else:
            return str(s[0:8])

# if __name__ == '__main__':
    # fptr = open(os.environ['OUTPUT_PATH'], 'w')
    # s = input()
    # result = timeConversion("07:05:45PM")
    # print(result)
    # fptr.write(result + '\n')
    # fptr.close()
    
def gradingStudents(grades, grades_count):
    # Write your code here
    for i in range(grades_count):
        grade = grades[i]
        rest = grade % 5
        if grade < 38:
            ()
        else:
            if rest >= 3:
                grades[i] = grade + (5 - rest)
            else:
                ()
    return grades

# if __name__ == '__main__':
#     fptr = open(os.environ['OUTPUT_PATH'], 'w')
#     grades_count = int(input().strip())
#     grades = []
#     for _ in range(grades_count):
#         grades_item = int(input().strip())
#         grades.append(grades_item)
#     result = gradingStudents(grades, grades_count)
#     fptr.write('\n'.join(map(str, result)))
#     fptr.write('\n')
#     fptr.close()

from collections import Counter
from heapq import heapify, heappop, heappush

# Complete the cutTheSticks function below.
def cutTheSticks(arr):
    ans = list()
    heap = []
    heapify(heap)	# Heapify a min heap
    counter = Counter(arr)	# O(N) - Create a hash table with distinct length of sticks as keys and their amounts as values
    ans.append(len(arr))		# O(1) - Initialize the list with len(arr)
    length = len(arr)

    for i in list(counter.keys()):	# O(N) - Add length of sticks to heap
        heappush(heap, i)
        
    while length > 1:	# O(N) - Loop through arr
        minimum = heap[0]	# O(1) - Get the root value of min heap which is the length of shortest sticks
        ans.append(length - counter.get(minimum))	# 0(1) - Append the remain length after subtract all the shortest sticks
        length = ans[-1]	# O(1) - Update the new length of arr
        del(counter[minimum])	# O(1) - Delete the shortest length
        heappop(heap)		# O(1) - Update the min heap
    if ans[-1] == 0:			# O(1) - Check if there are more than 1 stick at the end that can be removed altogether, and make the list append 0 stick
        ans.remove(0)			# O(1) - Remove 0
    return ans

    # TODO: bad O(n^2)
    # arr_len = len(arr)
    # counting_arr = [0]
    # counting_index = 0
    # arr = sorted(arr)
    # for i in range(arr_len):
    #     eli = arr[i]
    #     if eli == 0:
    #         continue
    #     else:
    #         arr[i] = 0
    #         if len(counting_arr) <= counting_index:
    #             counting_arr.append(0)
    #         else:
    #             ()
    #         for j in range(i, arr_len):
    #             elj = arr[j]
    #             diff = elj - eli
    #             if diff == 0:
    #                 arr[j] = 0
    #                 counting_arr[counting_index] += 1
    #             else:
    #                 arr[j] = diff
    #                 counting_arr[counting_index] += 1
                    
    #         counting_index += 1
            
    # return counting_arr

    # not working =( TODO: fix
    # arr_len = len(arr)
    # counting_arr = [0]
    # counting_index = 0
    # last_item = 0
    # arr = sorted(arr)
    # print(arr)
    # for i in range(arr_len):
    #     eli = arr[i]
    #     j = i + 1
    #     print(eli)
    #     if eli != 0 and last_item != eli:
    #         counting_arr[counting_index] = arr_len - i
    #         counting_arr.append(0)
    #         counting_index += 1
            
    #     if eli != 0:
    #         last_item = eli
            
    #     if j == arr_len:
    #         ()
    #     else:
    #         elj = arr[j]
    #         diff = elj - eli
    #         arr[i] = 0
    #         arr[j] = diff
    
    # if counting_arr[-1] == 0:
    #     counting_arr.pop()
        
    # return counting_arr

# if __name__ == '__main__':
#     fptr = open(os.environ['OUTPUT_PATH'], 'w')
#     n = int(input().strip())
#     arr = list(map(int, input().rstrip().split()))
#     result = cutTheSticks(arr)
#     fptr.write('\n'.join(map(str, result)))
#     fptr.write('\n')
#     fptr.close()

#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'breakingRecords' function below.
#
# The function is expected to return an INTEGER_ARRAY.
# The function accepts INTEGER_ARRAY scores as parameter.
#

def breakingRecords(scores, fptr):
    # Write your code here
    minScore = scores[0]
    minScoreRecord = 0
    maxScore = scores[0]
    maxScoreRecord = 0
    for score in scores:
        if score > maxScore:
            maxScore = score
            maxScoreRecord += 1
        elif score < minScore:
            minScore = score
            minScoreRecord += 1
        else:
            ()
            
    fptr.write(str(maxScoreRecord))
    fptr.write(" ")
    fptr.write(str(minScoreRecord))


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input().strip())

    scores = list(map(int, input().rstrip().split()))
    breakingRecords(scores, fptr)
    # result = breakingRecords(scores)

    # fptr.write(' '.join(map(str, result)))
    # fptr.write('\n')

    fptr.close()


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')
    grades_count = int(input().strip())
    grades = []
    for _ in range(grades_count):
        grades_item = int(input().strip())
        grades.append(grades_item)

    result = gradingStudents(grades, grades_count)
    fptr.write('\n'.join(map(str, result)))
    fptr.write('\n')

    fptr.close()
