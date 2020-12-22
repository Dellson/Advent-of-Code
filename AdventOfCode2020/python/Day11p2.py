import aoc
from copy import deepcopy


input = ['.' + i[:-1] + '.' for i in aoc.input(11)]
input.insert(0, '.' * len(input[0]))
input.append('.' * len(input[0]))

  
def update_seating(temp, lst, row, col):
  occupied = 0
  iters = 0

  for r in range(-1,2):
    for c in range(-1,2):
      iters += 1
      if lst[row][col] == '#' and iters >= 5 and occupied == 0:
        return
      if r == 0 and c == 0:
        continue
      elif is_dir_occupied(lst,row,col,r,c):
        occupied += 1
      if occupied >= 5 and lst[row][col] == '#':
        r = list(temp[row])
        r[col] = 'L'
        temp[row] = ''.join(r)
        return
        
  if occupied == 0 and lst[row][col] == 'L':
    r = list(temp[row])
    r[col] = '#'
    temp[row] = ''.join(r)

# offset is dynamic and changes by 1, 0 or -1
def is_dir_occupied(lst, row, col, r_offset, c_offset):
  #print(row,col,r_offset,c_offset)
  r = r_offset
  c = c_offset
  while True:
    if row+r >= len(lst)-1 or row+r < 1 or col+c >= len(lst[0])-1 or col+c < 1:
      return False
    if lst[row+r][col+c] == '#':
      return True
    elif lst[row+r][col+c] == 'L':
      return False
    else:
      r += r_offset
      c += c_offset

def run_round(lst):
  temp = deepcopy(lst)
  for row in range(1,len(lst)-1):
    for col in range(1,len(lst[row])-1):
      if lst[row][col] != '.':
        update_seating(temp,lst,row,col)
  return temp

def count_occupied(lst):
  return sum([r.count('#') for r in lst])

prev_count = 0
counter = 0
while counter < 100:
  input = run_round(input)
  count = count_occupied(input)
  if prev_count == count:
    break
  else:
    prev_count = count
  counter += 1

print(f'part 2: {count}')