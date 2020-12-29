# Advent of code Year 2015 Day 1 tests
from code import part1


def test_1_1():

    input = "(())"
    assert part1(input) == 0


def test_1_2():

    input = "((("
    assert part1(input) == 3


def test_1_3():

    input = "))((((("
    assert part1(input) == 3


def test_1_4():

    input = "())"
    assert part1(input) == -1


def test_1_5():

    input = ")))"
    assert part1(input) == -3
