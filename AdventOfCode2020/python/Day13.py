import aoc
import itertools


# part 1
# data = [i for i in aoc.input(13)]
# current_time = 6
# earliest_time = int(data[0])

# buses = [int(i) for i in data[1].split(',') if i != 'x']

# while True:
#   bus = [b for b in buses if current_time % b == 0]

#   if len(bus) > 0 and current_time >= earliest_time:
#     result = bus[0] * abs(earliest_time - current_time)
#     print(f'part 1: {result}')
#     break
#   current_time += 1

# part 2
data = [i for i in aoc.input(13)]
arrivals = [1 if i == 'x' else int(i) for i in data[1].split(',')]
#buses = list(filter(lambda x: x != 1, arrivals))
buses = [arrivals[i] + i if arrivals[i] != 1 else 1 for i in range(len(arrivals))]
buses.sort()

z = lambda x, y: x % y == 0

ids_multiplied = 1

for i in range(len(arrivals) - 1):
  ids_multiplied *= (arrivals[i] + i)



depth = 0

# def get_ts(cur_ts, max_ts, depth):
#   depth += 1
#   cur_id = buses[depth]
#   max_ts = int(ids_multiplied / cur_id)

#   print((ids_multiplied, cur_id, buses, max_ts))

#   for ts in range(cur_id, ids_multiplied, cur_id):
#     #print(0)
#     if ts % cur_ts == 0 and depth == len(buses) - 1:
#       #print(ts)
#       return ts
#     elif ts % cur_ts == 0:
#       return get_ts(cur_ts, ids_multiplied, depth)

# print(get_ts(buses[0], int(ids_multiplied / max(buses)), depth))

#print(ids_divisors)




# while True:
#   are_all_valid = True
#   for i in range(len(arrivals)):
#     if arrivals[i] != 1 and not z(t + i, arrivals[i]):
#       are_all_valid = False
#       #print(i)
#       break
#   if are_all_valid:
#     print(t)
#     break
#   t += max(arrivals) * min(arrivals)
  #print(t)

# def find_next(ti,i):
#   res = 0
#   while True:
#     if arrivals[i] != 1 and z(ti + i, arrivals[i]):
#       return find_next(ti,i)
  

    
