# Advent of code Year 2015 Day 7 solution

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

print("--- Day 7: Some Assembly Required ---")


class Wire(object):

    def __init__(self, line):
        self._line = line
        self.parse_line(line)

    def parse_line(self, line):
        lline = line.split()
        self.output = lline[-1]

        left = lline[:-2]
        self.op = 'ASSIGN'
        for op in ['NOT', 'AND', 'OR', 'LSHIFT', 'RSHIFT']:
            if op in left:
                self.op = op
                left.remove(op)
        self.inputs = [int(i) if i.isdigit() else i for i in left]

    def reset(self):
        self.parse_line(self._line)

    def evaluate(self):
        if self.op == 'ASSIGN':
            return int(self.inputs[0])
        elif self.op == 'NOT':
            return int(65535 - self.inputs[0])
        elif self.op == 'AND':
            return int(self.inputs[0] & self.inputs[1])
        elif self.op == 'OR':
            return int(self.inputs[0] | self.inputs[1])
        elif self.op == 'LSHIFT':
            return int(self.inputs[0] << self.inputs[1])
        elif self.op == 'RSHIFT':
            return int(self.inputs[0] >> self.inputs[1])
        else:
            raise ValueError('invalid operator')

    def fill_inputs(self, signals):
        self.inputs = [signals[i] if i in signals else i for i in self.inputs]

    def iscomplete(self):
        return all([isinstance(i, int) for i in self.inputs])


wires = [Wire(line) for line in input]


def evaluate_circuit(wires, signals):
    local_wires = list(wires)
    while len(local_wires) != 0:
        new_wires = []
        for wire in wires:
            if wire.iscomplete():
                signals[wire.output] = wire.evaluate()
            else:
                wire.fill_inputs(signals)
                new_wires.append(wire)
        local_wires = new_wires
    return signals


ttime = 0
# Part 1
start_time = datetime.datetime.now()
part1 = 0
wires_copy = list(wires)
signals = evaluate_circuit(wires, {})
part1 = signals['a']

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part One: ", part1, "done in", "%.4f" % time_elapsed_ms,  "ms")

# Part 2
[wire.reset() for wire in wires]
wires = [wire for wire in wires if wire.output != 'b']
start_time = datetime.datetime.now()
signals = evaluate_circuit(wires, {'b': signals['a']})
part2 = signals['a']

time_elapsed_ms = (datetime.datetime.now() - start_time).total_seconds() * 1000
ttime += time_elapsed_ms
print(f"Part Two: ", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")

print(ttime, "ms")
