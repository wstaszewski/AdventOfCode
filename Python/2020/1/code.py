# Advent of code Year 2020 Day 1 solution

import sys
import fileinput
import re
import time

input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read()

print("--- Day 1: Report Repair ---")
ttime = 0
# Part 1
start = time.perf_counter()
X = [int(line) for line in fileinput.input()]
n = len(X)
for i in range(n):
    for j in range(i, n):
        if X[i]+X[j] == 2020:
            part1 = X[i]*X[j]
end = time.perf_counter()
time_elapsed_ms = (end-start)*100
ttime += time_elapsed_ms
print(f"Part One: ", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
part2 = 0
time_elapsed_ms = 0
start = time.perf_counter()
X = [int(line) for line in fileinput.input()]
n = len(X)
for i in range(n):
    for j in range(0, n):
        for k in range(0, n):
            if X[i]+X[j]+X[k] == 2020:
                part2 = X[i]*X[j]*X[k]
end = time.perf_counter()
time_elapsed_ms = (end-start)*100
print(f"Part Two: ", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

ttime += time_elapsed_ms
print(ttime, "ms")
