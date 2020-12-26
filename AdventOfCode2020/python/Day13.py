import aoc


# part 1
data = [i for i in aoc.input(13)]
current_time = 6
earliest_time = int(data[0])

buses = [int(i) for i in data[1].split(',') if i != 'x']

while True:
  bus = [b for b in buses if current_time % b == 0]

  if len(bus) > 0 and current_time >= earliest_time:
    result = bus[0] * abs(earliest_time - current_time)
    print(f'part 1: {result}')
    break
  current_time += 1
