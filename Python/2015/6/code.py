# Advent of code Year 2015 Day 6 solution

import sys
import fileinput
import re
import math
import datetime
import numpy as np


input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read().split("\n")

print("--- Day 6: Probably a Fire Hazard ---")


ttime = 0
# Part 1
start_time = datetime.datetime.now()
grid = np.zeros((1000, 1000), 'int32')
part1 = 0

for line in input:
    line = line.strip().split()

    if line[0] == 'turn':
        x1, y1 = line[2].split(',')
        x2, y2 = line[4].split(',')
        x1, x2, y1, y2 = int(x1), int(x2), int(y1), int(y2)
        if line[1] == 'on':
            grid[x1:x2+1, y1:y2+1] = 1
        else:
            assert line[1] == 'off'
            grid[x1:x2+1, y1:y2+1] = 0
    else:
        assert line[0] == 'toggle'
        x1, y1 = line[1].split(',')
        x2, y2 = line[3].split(',')
        x1, x2, y1, y2 = int(x1), int(x2), int(y1), int(y2)
        grid[x1:x2+1, y1:y2+1] = np.logical_not(grid[x1:x2+1, y1:y2+1])
part1 = np.sum(grid)

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One: ", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
start_time = datetime.datetime.now()
part2 = 0
grid = np.zeros((1000, 1000), 'int32')

for line in input:
    line = line.strip().split()

    if line[0] == 'turn':
        x1, y1 = line[2].split(',')
        x2, y2 = line[4].split(',')
        x1, x2, y1, y2 = int(x1), int(x2), int(y1), int(y2)
        if line[1] == 'on':
            grid[x1:x2+1, y1:y2+1] += 1
        else:
            assert line[1] == 'off'
            grid[x1:x2+1, y1:y2+1] += -1
            grid[grid < 0] = 0
    else:
        assert line[0] == 'toggle'
        x1, y1 = line[1].split(',')
        x2, y2 = line[3].split(',')
        x1, x2, y1, y2 = int(x1), int(x2), int(y1), int(y2)
        grid[x1:x2+1, y1:y2+1] += 2
part2 = np.sum(grid)

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part Two: ", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
