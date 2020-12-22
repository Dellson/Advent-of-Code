import os


def input(day: int):
    """
    input: day number
    returns: string[] containing input
    """
    return open(f'{os.getcwd()}\AdventOfCode2020\python\input\Day{str(day).zfill(2)}.txt')