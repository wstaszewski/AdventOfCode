# Advent of code Year 2020 Day 1 solution

import sys
import fileinput
import re
import datetime

input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read()

print("--- Day 1: Report Repair ---")
ttime = 0
X = [int(line) for line in fileinput.input()]
n = len(X)

# Part 1
start_time = datetime.datetime.now()
for i in range(n):
    for j in range(i, n):
        if X[i]+X[j] == 2020:
            part1 = X[i]*X[j]
            end_time = datetime.datetime.now()
            time_diff = (end_time - start_time)
            time_elapsed_ms = time_diff.total_seconds() * 1000
            ttime += time_elapsed_ms
print(f"Part One: ", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
part2 = 0
start_time = datetime.datetime.now()
for i in range(n):
    for j in range(i+1, n):
        for k in range(j+1, n):
            if X[i]+X[j]+X[k] == 2020:
                part2 = X[i]*X[j]*X[k]
                end_time = datetime.datetime.now()
                time_diff = (end_time - start_time).total_seconds() * 1000
                time_elapsed_ms = time_diff
                ttime += time_elapsed_ms
print(f"Part Two: ", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
