import aoc
import re


input = [(i[0],int(re.search('\d+$', i).group(0))) for i in aoc.input(12)]
shx = 0 # WE - horizontal (x)
shy = 0 # NS - longitudal (y)
# waypoint is relative
wpx = 10  # WE - horizontal (x)
wpy = 1 # NS - longitudal (y)
# direction sign
signx = 1
signy = 1
# dirs  E N    E S    W S     W N
signs = [(1,1),(1,-1),(-1,-1),(-1,1)]
length = len(signs)
wpx_zeroes = 0
wpy_zeroes = 0

for cmd,num in input:
  #print(f'\t{(num, turns)}\n')
  if wpx == 0:
    wpx_zeroes += 1
  if wpy == 0:
    wpy_zeroes += 1
  if cmd == 'N':
    wpy += num
  elif cmd == 'S':
    wpy -= num
  elif cmd == 'E':
    wpx += num
  elif cmd == 'W':
    wpx -= num
  elif cmd == 'F':
    shx += wpx * num
    shy += wpy * num
  if cmd not in ['L','R']:
    if wpx != 0:
      signx = abs(wpx) / wpx
    if wpy != 0:
      signy = abs(wpy) / wpy
  else: # LR
    turns = int(num/90)
    if cmd == 'L':
      turns = -turns
    # rotate
    prev_i = signs.index((signx, signy))
    new_i = int(prev_i + turns) % length
    # set wp
    if abs(turns) % 2 == 0:
      wpx = abs(wpx) * signs[new_i][0]
      wpy = abs(wpy) * signs[new_i][1]
    elif abs(turns) % 2 == 1:
      tempx = wpx
      wpx = abs(wpy) * signs[new_i][0]
      wpy = abs(tempx) * signs[new_i][1]
    else:
      raise Exception

  #print(f'$ {cmd}{num}:  {(shx, shy)} {(wpx, wpy)} {(facex, facey)}')

# all my attempts :D It's embarassing ...
# 18835 is too low
# 23563 is not right
# 39877 is not right
# 41155 is not right
# 41323 is not right
# 56138 is not right (output from Day12js.js script)
# 57269 is not right
# 63689 is too high
print(f'part 2: {abs(shx)+abs(shy)}')
