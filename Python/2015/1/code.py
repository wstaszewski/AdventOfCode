# Advent of code Year 2015 Day 1 solution

import sys
import fileinput
import re
import datetime

input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
    input = input[0]
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read()

print("--- Day 1: Not Quite Lisp ---")
ttime = 0
# Part 1
start_time = datetime.datetime.now()
part1 = input.count('(') - input.count(')')
time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One:", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
part2 = 0
start_time = datetime.datetime.now()
floor = 0
for i, char in enumerate(input):
    if(char == '('):
        floor += 1
    elif (char == ')'):
        floor -= 1
    if(floor == -1):
        part2 = i+1
        time_elapsed_ms = (datetime.datetime.now() -
                           start_time).total_seconds() * 1000
        ttime += time_elapsed_ms
        break
print(f"Part Two:", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
