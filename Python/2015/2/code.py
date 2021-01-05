# Advent of code Year 2015 Day 2 solution

import sys
import fileinput
import re
import math
import datetime

input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read().split("\n")

print("--- Day 2: I Was Told There Would Be No Math ---")

ttime = 0
# Part 1
start_time = datetime.datetime.now()
part1 = 0
for ele in input:
    arr = list(map(int, ele.split("x")))
    lw = arr[0] * arr[1]
    wh = arr[1] * arr[2]
    lh = arr[0] * arr[2]
    part1 += 2*lw + 2*wh + 2*lh + min([lw, wh, lh])

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One:", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
part2 = 0
for ele in input:
    arr = list(map(int, ele.split("x")))
    arr.sort()
    part2 += 2*arr[0] + 2*arr[1] + math.prod(arr)
time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part Two:", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
