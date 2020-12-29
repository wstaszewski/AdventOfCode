# Advent of code Year 2015 Day 4 solution

import sys
import fileinput
import re

input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
    input = input[0]
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read()

print("Part One:")
print(input.count('(') - input.count(')'))


print("Part Two:")
floor = 0
for i, char in enumerate(input):
    if(char == '('):
        floor += 1
    elif (char == ')'):
        floor -= 1
    if(floor == -1):
        print(i+1)
        break
