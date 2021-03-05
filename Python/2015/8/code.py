# Advent of code Year 2015 Day 8 solution

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

print("--- Day 8: Matchsticks ---")


def size_in_memory(string):
    assert string[0] == '"'
    assert string[-1] == '"'
    in_mem = string[1:-1]
    in_mem = in_mem.replace("\\\\", "x")
    in_mem = in_mem.replace("\\\"", "x")
    in_mem, _ = re.subn('\\\\x..', 'x', in_mem)
    return len(in_mem)


def size_escaped(string):
    escaped = string
    escaped = escaped.replace("\\", "\\\\")
    escaped = escaped.replace('"', '\\"')
    escaped = '"' + escaped + '"'
    return len(escaped)


total_chars_code = 0
total_chars_memory = 0
total_chars_escaped = 0

ttime = 0
# Part 1
start_time = datetime.datetime.now()
part1 = 0
for line in input:
    line = line.strip()
    chars = len(line)
    in_mem = size_in_memory(line)

    total_chars_code += len(line)
    total_chars_memory += size_in_memory(line)

part1 = total_chars_code - total_chars_memory
time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One: ", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
start_time = datetime.datetime.now()
total_chars_code = 0
total_chars_memory = 0
part2 = 0
for line in input:
    line = line.strip()
    chars = len(line)
    in_mem = size_in_memory(line)
    escaped = size_escaped(line)

    total_chars_code += len(line)
    total_chars_memory += size_in_memory(line)
    total_chars_escaped += escaped
part2 = total_chars_escaped - total_chars_code
time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part Two: ", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
