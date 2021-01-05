# Advent of code Year 2015 Day 5 solution

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

print("--- Day 5: Doesn't He Have Intern-Elves For This? ---")

ttime = 0
# Part 1
start_time = datetime.datetime.now()
part1 = 0

for line in input:
    text = str(line)
    case1 = re.findall(r'[aeiou]', text, re.I)
    case2 = re.search(r'(.)\1', text, re.I)
    case3 = re.search(r'ab|cd|pq|xy', text, re.I)
    if len(case1) >= 3 and case2 and not case3:
        part1 += 1

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One: ", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
part2 = 0
for line in input:
    text = str(line)
    case1 = re.search(r'(..).*\1', text, re.I)
    case2 = re.search(r'(.).\1', text, re.I)
    if case1 and case2:
        part2 += 1

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part Two: ", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
