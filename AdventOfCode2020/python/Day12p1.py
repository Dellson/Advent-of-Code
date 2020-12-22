import aoc
import re


input = [(i[0],int(re.search('\d+$', i).group(0))) for i in aoc.input(12)]
x = 0
y = 0
face = (1,0)
dirs = [(0,-1),(1,0),(0,1),(-1,0)]

for cmd,num in input:
  if cmd == 'N':
    y -= num
  elif cmd == 'S':
    y += num
  elif cmd == 'E':
    x += num
  elif cmd == 'W':
    x -= num
  elif cmd == 'F':
    x += (face[0] * num)
    y += (face[1] * num)
  else:
    num /= 90
    i = dirs.index(face)
    if cmd == 'L':
      face = dirs[int((i-num)%4)]
    elif cmd == 'R':
      face = dirs[int((i+num)%4)]
  
print(f'part 1: {x+y}')
