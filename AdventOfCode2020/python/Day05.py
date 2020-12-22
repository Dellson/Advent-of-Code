import aoc


ids = []

for line in aoc.input(5):
  seat = 0
  vert = list(map(lambda v: '1' if v == 'B' else '0', line[:7][::-1]))
  hori = list(map(lambda h: '1' if h == 'R' else '0', line[7:10][::-1]))
  
  for i in range(7):
    seat += int(vert[i]) * (2**i)
  seat *= 8
  
  for i in range(3):
    seat += int(hori[i]) * (2**i)
    
  if seat not in ids:
    ids.append(seat)
  
ids.sort()

print(f'part 1: {max(ids)}')

for i in range(1, len(ids)):
  if ids[i-1] + 2 == ids[i]:
    print(f'part 2: {ids[i]-1}') 
