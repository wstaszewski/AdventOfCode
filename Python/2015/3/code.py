# Advent of code Year 2015 Day 3 solution

import sys
import fileinput
import re
import math
import datetime

input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
    input = input[0]
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read()

print("--- Day 3: Perfectly Spherical Houses in a Vacuum ---")

possibleMoves = {'>': (1, 0), '<': (-1, 0), '^': (0, 1), 'v': (0, -1)}

ttime = 0
# Part 1
start_time = datetime.datetime.now()
part1 = 0
location = (0, 0)
houses = {}
houses[location] = 1
for i, char in enumerate(input):
    location = (location[0] + possibleMoves[char][0],
                location[1] + possibleMoves[char][1])
    houses[location] = houses.get(location, 0) + 1
part1 = len(houses)

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One:", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
part2 = 0
locationSanta = (0, 0)
locationRobot = (0, 0)
houses = {}
houses[locationSanta] = 1
i = 0
for j, char in enumerate(input):
    if(i == 0):
        locationSanta = (locationSanta[0] + possibleMoves[char][0],
                         locationSanta[1] + possibleMoves[char][1])
        houses[locationSanta] = houses.get(locationSanta, 0) + 1
    if (i == 1):
        locationRobot = (locationRobot[0] + possibleMoves[char][0],
                         locationRobot[1] + possibleMoves[char][1])
        houses[locationRobot] = houses.get(locationRobot, 0) + 1
    i = 1-i
part2 = len(houses)

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part Two:", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
