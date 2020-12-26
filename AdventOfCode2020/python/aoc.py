import os


def input(day: int):
    """
    input: day number
    returns: string[] containing input
    """
    return open(f'{os.getcwd()}\AdventOfCode2020\python\input\Day{str(day).zfill(2)}.txt')

def gcd(x, y):
    if x > y:
        smaller = y
    else:
        smaller = x

    for i in range(1, smaller + 1):
        if ((x % i == 0) and (y % i == 0)):
            gcd = i
    return gcd