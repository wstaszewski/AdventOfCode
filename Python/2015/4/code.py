# Advent of code Year 2015 Day 4 solution

import sys
import fileinput
import re
import math
import datetime
from hashlib import md5

input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read()

print("--- Day 4: The Ideal Stocking Stuffer ---")

ttime = 0
# Part 1
start_time = datetime.datetime.now()
part1 = 0
for i in range(1000000):
    h = md5((input + str(i)).encode()).hexdigest()
    if h[:5] == '00000':
        part1 = i
        break

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One:", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
start_time = datetime.datetime.now()
part2 = 0
for i in range(100000000):
    h = md5((input + str(i)).encode()).hexdigest()
    if h[:6] == '000000':
        part2 = i
        break

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part Two:", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
