# Advent of code Year 2015 Day 9 solution

import sys
import fileinput
import re
import math
import datetime
import itertools

input = ""
if(len(sys.argv) > 1):
    input = list(fileinput.input())
else:
    with open((__file__.rstrip("code.py")+"input.txt"), 'r') as input_file:
        input = input_file.read().split("\n")

print("--- Day 9: All in a Single Night ---")

path = {}
locations = []
for line in input:
    lline = line.split()
    city1 = lline[0]
    city2 = lline[2]
    distance = int(lline[4])

    path[city1 + city2] = distance
    path[city2 + city1] = distance

    locations.append(city1)
    locations.append(city2)

# find unique locations
locations = set(locations)

ttime = 0
# Part 1
start_time = datetime.datetime.now()
part1 = 0
shortest_route_length = 999999
for route in itertools.permutations(locations):
    route_length = 0
    for city1, city2 in zip(route[:-1], route[1:]):
        route_length += path[city1 + city2]
    if route_length < shortest_route_length:
        shortest_route_length = route_length

part1 = shortest_route_length
time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One: ", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
start_time = datetime.datetime.now()
part2 = 0
longest_route_length = 0
for route in itertools.permutations(locations):
    route_length = 0
    for city1, city2 in zip(route[:-1], route[1:]):
        route_length += path[city1 + city2]
    if route_length > longest_route_length:
        longest_route_length = route_length
part2 = longest_route_length
time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part Two: ", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
